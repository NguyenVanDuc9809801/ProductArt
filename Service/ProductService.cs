using Main_project.Data;
using Main_project.Dtos;
using Main_project.Models;
using Microsoft.EntityFrameworkCore;

namespace Main_project.Service
{
    public class ProductService
    {
        private readonly ApplicationDbContext dbContext;

        public ProductService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task UploadProduct(ProductsArt productsArt)
        {
            await dbContext.ProductsArts.AddAsync(productsArt);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<ProductInfoDtos>> GetProductsInfo()
        {
            var result = (from product in dbContext.ProductsArts
                          select new ProductInfoDtos()
                          {
                              ProductName = product.Name,
                              AuthorName = product.AuthorName,
                              filePath = product.FilePath,
                              Price = product.Price,
                              likes = product.Users.Count(),
                              Comments = product.Comments.Count()
                          })
                            ;
            return await result.ToListAsync();
        }
        public async Task<ProductsArt?> GetProductIdAsync(int Id) => await dbContext.ProductsArts.FirstOrDefaultAsync(pro => pro.Id == Id);

        ///<summary>
        ///This method add likes product with user
        ///<example>
        ///<code>
        ///LikeAsync(user1, 2)
        ///</code>
        ///result void
        ///</example>
        ///</summary>
        public async Task<bool> LikeAsync(User user, int ProductId)
        {
            var product = await dbContext.ProductsArts.FirstOrDefaultAsync(pro => pro.Id == ProductId);
            if (product != null)
            {
                product.Users.Add(user);
                await dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        ///<summary>
        ///This method add dis likes product with user
        ///<example>
        ///<code>
        ///DisLikeAsync(User user1,ProductID 2)
        ///</code>
        ///result void
        ///</example>
        ///</summary>
        public async Task DisLikeAsync(User user, int ProductId)
        {
            var product = await dbContext.ProductsArts.FirstOrDefaultAsync(pro => pro.Id == ProductId);
            if (product != null) product.Users.Remove(user);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Comment>> GetCommentAsync(int ProductId)
        {

            var result = await dbContext.ProductsArts.Include(pro => pro.Comments).FirstOrDefaultAsync(pro => pro.Id == ProductId);
            if(result==null){
                result = new ProductsArt();
            }
            return result.Comments.ToList();
        }

        public async Task AddCommnetAsync(Comment comment)
        {
            await dbContext.Comments.AddAsync(comment);
            await dbContext.SaveChangesAsync();
        }
    }
}
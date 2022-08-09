using Main_project.Data;
using Main_project.Dtos;
using Main_project.Models;
using Microsoft.EntityFrameworkCore;

namespace Main_project.Service
{
    public class UserService
    {
        private readonly ApplicationDbContext dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // public async Task<User> GetUserIdAsync(string UserId) => 
        //                                 await dbContext.Users.Where(user => user.Id == UserId)
        //                                 .SingleOrDefaultAsync();
        public async Task<InfoUpdateDtos?> GetUserInfoIdAsync(string UserId) =>
                                        await dbContext.Users.Where(user => user.Id == UserId)
                                        .Select(user => new InfoUpdateDtos
                                        {
                                            Name = user.UserName,
                                            PhoneNumber = user.PhoneNumber,
                                            Address = user.Address??"No",
                                            Sex = user.Sex??"No"
                                        })
                                        .SingleOrDefaultAsync();


        public async Task UpdateUserAsync(InfoUpdateDtos info, string UserId)
        {
            var result = await dbContext.Users.FirstOrDefaultAsync(user => user.Id == UserId);
            if (result != null)
            {
                result.PhoneNumber = info.PhoneNumber;
                result.Address = info.Address;
                result.Sex = info.Sex;
                result.UserName = info.Name;
            }
            await dbContext.SaveChangesAsync();
        }
    }
}
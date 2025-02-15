using Microsoft.EntityFrameworkCore.Metadata;
using SocialMediaFriendsApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaFriendsApp.Data.Helpers
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(AppDbContext appDbContext)
        {
            if (!appDbContext.Users.Any() && !appDbContext.Posts.Any())
            {
                var newUser = new User()
                {
                    FullName = "Jurijs Grigorjevs",
                    ProfilePictureUrl = "file:///D:/SocialMediaApp/Jurijs_Grigorjevs.jpg"
                };
                await appDbContext.Users.AddAsync(newUser);
                await appDbContext.SaveChangesAsync();

                var newPostWithoutImage = new Post()
                {
                    Content = "This is going to be our first post which is being loaded from the database and it has been created using our test user.",
                    ImageUrl = "",
                    NrOfReports = 0,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow,

                    UserId = newUser.Id
                };

                var newPostWithImage = new Post()
                {
                    Content = "This is going to be our second post which is being loaded from the database and it has been created using our test user. This post has an image.",
                    ImageUrl = "file:///D:/SocialMediaApp/Jurijs_Grigorjevs.jpg",
                    NrOfReports = 0,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow,

                    UserId = newUser.Id
                };

                await appDbContext.Posts.AddRangeAsync(newPostWithoutImage, newPostWithImage);
                await appDbContext.SaveChangesAsync();
            }
        }
    }
}

using RetroRides.DTOs.User;
using RetroRides.Models;
using RetroRides.Models.DbConfiguration;
using RetroRides.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RetroRides.Services;
using RetroRides.Data;

namespace RetroRides.Services
{
    public class UserService : BaseService ,IUserService
    {
        private readonly MuseumContext dbContext;

        private User? loggedInUser;

        public UserService(MuseumContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> AuthenticateUserAsync(string username, string password)
        {
            var user = await dbContext.Users
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                loggedInUser = user; 
                return true;
            }

            return false;
        }

        public async Task RegisterUserAsync(RegisterUserInputModel registrationModel)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = registrationModel.Username,
                Password = registrationModel.Password,
                Age = registrationModel.Age,
                Email = registrationModel.Email,
                AvatarUrl = registrationModel.AvatarUrl
            };

            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();
        }

        public User? GetLoggedInUserAsync()
        {
            return loggedInUser;
        }

        public async Task<bool> UpdateUserAsync(EditProfileInputModel userModel)
        {
            if (loggedInUser == null) return false;

            var user = await dbContext.Users.FindAsync(userModel.Id);
            if (user == null) return false;

            user.Username = userModel.Username;
            user.Email = userModel.Email;
            user.Age = userModel.Age;
            user.AvatarUrl = userModel.AvatarUrl;

            dbContext.Users.Update(user);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            if (userId == null) return false;

            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null) return false;

            dbContext.Users.Remove(user);
            await dbContext.SaveChangesAsync();

            return true;
        }
        public async Task<bool> IsUserAdminAsync(Guid userId)
        {
            return await dbContext.UserRoles
                .AnyAsync(ur => ur.UserId == userId && ur.Role.Name == "Admin");
        }
        public void LogoutUser()
        {
            loggedInUser = null; 
        }
        public async Task<bool> IsUsernameTaken(string username)
        {
            return await dbContext.Users.AnyAsync(u => u.Username == username);
        }
        public async Task<IEnumerable<UserDataViewModel>> GetUsersAsync()
        {
            var users = await dbContext.Users.ToListAsync();
            return users.Select(user => new UserDataViewModel
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Age = user.Age,
                AvatarUrl = user.AvatarUrl,
            });
        }
        public async Task<bool> MakeUserAdminAsync(Guid userId)
        {
            var user = await dbContext.Users.FindAsync(userId);
            if (user == null)
            {
                return false;
            }

            var adminRole = await dbContext.Roles.FirstOrDefaultAsync(r => r.Name == "Admin");
            if (adminRole == null)
            {
                return false;
            }

            if(dbContext.UserRoles.Any(ur => ur.UserId == userId && ur.RoleId == adminRole.Id))
            {
                return false;
            }

            var userRole = new UserRole
            {
                UserId = userId,
                RoleId = adminRole.Id
            };

            dbContext.UserRoles.Add(userRole);
            await dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> RemoveAdminRoleAsync(Guid userId)
        {
            var adminRole = await dbContext.Roles.FirstOrDefaultAsync(r => r.Name == "Admin");
            if (adminRole == null)
            {
                return false;
            }

            var userRole = await dbContext.UserRoles
                .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == adminRole.Id);

            if (userRole == null)
            {
                return false;
            }

            dbContext.UserRoles.Remove(userRole);
            await dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<User?> FindUserByIdAsync(Guid userId)
        {
            return await dbContext.Users.FindAsync(userId);
        }

    }
}

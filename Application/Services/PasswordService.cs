using InfosecLearningSystem_Backend.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace InfosecLearningSystem_Backend.Services
{
    public class PasswordService
    {
        private readonly IPasswordHasher<User> _passwordHasher;

        public PasswordService(IPasswordHasher<User> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public User CreateUserWithHashedPassword(User user, string password)
        {
            user.PasswordHash = _passwordHasher.HashPassword(user, password);
            return user;
        }

        public bool VerifyUserPassword(User user, string password)
        {
            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}

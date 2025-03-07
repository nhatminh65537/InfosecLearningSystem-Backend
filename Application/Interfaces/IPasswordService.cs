using InfosecLearningSystem_Backend.Domain.Models;

namespace InfosecLearningSystem_Backend.Application.Interfaces
{
    public interface IPasswordService
    {
        User CreateUserWithHashedPassword(User user, string password);
        bool VerifyUserPassword(User user, string password);
    }
}

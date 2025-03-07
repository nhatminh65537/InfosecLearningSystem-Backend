using InfosecLearningSystem_Backend.Domain.DTOs;

namespace InfosecLearningSystem_Backend.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse?> LoginAsync(LoginRequest request);
        Task<bool> RegisterAsync(RegisterRequest request);
        Task<AuthResponse> RefreshTokenAsync(RefreshTokenRequest request);
        Task LogoutAsync();
        Task<bool> VerifyEmailAsync(string token);
        Task SendPasswordResetEmailAsync(string email);
        Task<bool> ResetPasswordAsync(ResetPasswordRequest request);
    }
}
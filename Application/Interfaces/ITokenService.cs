namespace InfosecLearningSystem_Backend.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateJwtToken(int userId);
        Task RevokeTokenAsync(string jti);
        Task<bool> IsTokenRevokedAsync(string jti);
    }
}

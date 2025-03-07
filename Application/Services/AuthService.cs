using InfosecLearningSystem_Backend.Domain.DTOs;
using InfosecLearningSystem_Backend.Application.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using InfosecLearningSystem_Backend.Domain.Interfaces;
using InfosecLearningSystem_Backend.Domain.Models;

namespace InfosecLearningSystem_Backend.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly ITokenService _tokenService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(
            IRepository<User> userRepository,
            IPasswordService passwordService, 
            ITokenService tokenService,
            IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
            _tokenService = tokenService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<AuthResponse?> LoginAsync(LoginRequest request)
        {
            var user = await _userRepository.GetFirstWhereAsync(u => u.UserName == request.UserName);
            if (user == null)
            {
                return null;
            }
            if (_passwordService.VerifyUserPassword(user, request.Password))
            {
                var token = _tokenService.GenerateJwtToken(user.Id);
                return new AuthResponse { Token = token };
            }
            else
            {
                return null;
            }
        }

        public async Task LogoutAsync()
        {
            var jti = _httpContextAccessor.HttpContext?.User?.FindFirstValue(JwtRegisteredClaimNames.Jti);

            await _tokenService.RevokeTokenAsync(jti!);
        }

        public Task<AuthResponse> RefreshTokenAsync(RefreshTokenRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterAsync(RegisterRequest request)
        {
            var testUserName = await _userRepository.GetFirstWhereAsync(u => u.UserName == request.UserName);
            var testEmail = await _userRepository.GetFirstWhereAsync(u => u.Email == request.Email);

            if (testUserName != null || testEmail != null)
            {
                return false;
            }

            var newUser = _passwordService.CreateUserWithHashedPassword(
                new User { UserName = request.UserName, Email = request.Email },
                request.Password);
            await _userRepository.AddAsync(newUser);
            await _userRepository.SaveAsync();
            return true;
        }

        public async Task<bool> ResetPasswordAsync(ResetPasswordRequest request)
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdClaim, out int userId))
            {
                throw new Exception("Invalid userId");
            }
            User user = (await _userRepository.GetByIdAsync(userId))!;
            if (_passwordService.VerifyUserPassword(user, request.OldPassword))
            {
                await _userRepository.UpdateAsync(
                    _passwordService.CreateUserWithHashedPassword(user, request.NewPassword)   
                );
                await _userRepository.SaveAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Task SendPasswordResetEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerifyEmailAsync(string token)
        {
            throw new NotImplementedException();
        }

    }
}

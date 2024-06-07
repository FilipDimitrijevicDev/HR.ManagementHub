using Core.Application.Common.Models.Identity;
using Microsoft.AspNetCore.Authentication;

namespace Core.Application.Common.Identity;

public interface IAuthService
{
    Task<AuthResponse> Login(AuthRequest request);
    Task<RegistrationResponse> Register(RegistrationRequest request);
}

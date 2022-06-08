using Application.DTOs.Account;
using Application.DTOs.Email;
using Application.Wrappers;
using Infrastructure.Identity.Models;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAccountService
    {
        Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress);
        Task<Response<string>> RegisterAsync(RegisterRequest request, string origin);
        Task<Response<string>> ConfirmEmailAsync(string userId, string code);
        Task<Response<EmailRequest>> ForgotPassword(ForgotPasswordRequest model, string origin);
        Task<Response<string>> ResetPassword(ResetPasswordRequest model);
        Task<Response<AuthenticationResponse>> GetUserWithId(string userId);
        Task<Response<ApplicationUser>> UpdateUser(UpdateUserRequest request, string userId);
    }
}

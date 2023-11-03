using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.Core.Services.Interface;
using ThinkEMR_Care.DataAccess.Models.Authentication.Login;
using ThinkEMR_Care.DataAccess.Models.Authentication.SignUp;
using ThinkEMR_Care.DataAccess.Repository.Interface;

namespace ThinkEMR_Care.Core.Services
{
    public class AuthenticationServices:IAuthenticationServices
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        public AuthenticationServices(IAuthenticationRepository authenticationRepository) 
        {
            _authenticationRepository = authenticationRepository;
        }

        public async Task<string> RegisterNewUser(RegisterUser registerUser, string role)
        {
            return await _authenticationRepository.RegisterNewUser(registerUser,role);
        }

        public async Task<string> LoginUser(LoginModel loginModel)
        {
            return await _authenticationRepository.LoginUser(loginModel);
        }

        public async Task<string> ForgotPassword(string email)
        {
            return await _authenticationRepository.ForgotPassword(email);
        }

        public async Task<string> ConformEmail()
        {
            return await _authenticationRepository.ConformEmail();
        }

        public async Task<string> ConformUserDB(string token,string email)
        {
            return await _authenticationRepository.ConformUserDB(token,email);
        }

        public async Task<string> ResetPassword(string email)
        {
            return await _authenticationRepository.ResetPassword(email);
        }

        public async Task<string> ResetPassword(string Email,string Token)
        {
            return await _authenticationRepository.ResetPassword(Email, Token);
        }
    }
}

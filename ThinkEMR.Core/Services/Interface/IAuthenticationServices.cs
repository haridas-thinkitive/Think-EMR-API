using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.DataAccess.Models.Authentication.Login;
using ThinkEMR_Care.DataAccess.Models.Authentication.SignUp;

namespace ThinkEMR_Care.Core.Services.Interface
{
    public interface IAuthenticationServices
    {
        Task<string> RegisterNewUser(RegisterUser registerUser, string role);

        Task<string> LoginUser(LoginModel loginModel);

        Task<string> ForgotPassword(string email);

        Task<string> ConformEmail();

        Task<string> ConformUserDB(string token,string email);

        Task<string> ResetPassword(string email);

        Task<string> ResetPassword(string email, string token);


    }
}

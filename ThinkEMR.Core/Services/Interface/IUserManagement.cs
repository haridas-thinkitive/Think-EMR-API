using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.DataAccess.Models;
using ThinkEMR_Care.DataAccess.Models.Authentication.Login;
using ThinkEMR_Care.DataAccess.Models.Authentication.SignUp;

namespace ThinkEMR_Care.Core.Services.Interface
{
    public interface IUserManagement
    {
        Task<APIResponce<string>> RegisterUser(RegisterUser registerUser,string Role);
        Task<APIResponce<string>> LoginUser(LoginModel loginModel);
    }
}

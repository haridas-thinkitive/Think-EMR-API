using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.DataAccess.Models.EmailConfig;

namespace ThinkEMR_Care.DataAccess.Repository.Interface
{
    public interface IEmail
    {
        Task  SendEmail(Message message);

    }
}

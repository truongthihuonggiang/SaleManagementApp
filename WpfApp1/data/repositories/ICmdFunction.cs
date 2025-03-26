using SalesManagementApp.domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementApp.data.repositories
{
     
    public interface ICmdFunction
    {
        Task<List<User>> GetCmdFunctionsAsync();
        Task AddCmdFunctionAsync(User user);
        Task UpdateCmdFunctionAsync(User user);
        Task DeleteCmdFunctionAsync(int id);
    }
}

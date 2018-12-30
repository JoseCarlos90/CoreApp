using System.Collections.Generic;
using System.Threading.Tasks;
using CoreApp.API.Models;

namespace CoreApp.API.Data
{
    public interface IDatingRepository
    {
        void Add<T>(T entity ) where T: class;
        void Delete<T>(T entity ) where T: class;
        Task<bool> SaveAll();
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentSearcher.Models.DatabaseAccess.RepositoryInterface
{
    public interface IUserRepository
    {
        void InsertUser(User user);

        User[] GetUsers();
    }
}

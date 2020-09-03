using LibraryManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DAL.Repositories
{
    public class RoleRepository : Repository<Role>
    {
        public RoleRepository(LibraryDbContext context) : base(context)
        {

        }

        public async Task<Role> GetRoleAsync(string role)
        {
            return (await FindByConditionAsync(r => r.Name == role)).Single();
        }
    }
}

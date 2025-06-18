using TaskApi.Domain.Interface.Repository;
using TaskApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext): base(appDbContext)
        {
            _appDbContext = appDbContext;   
        }
    }
}

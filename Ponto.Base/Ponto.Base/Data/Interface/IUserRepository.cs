using Ponto.Base.Data.Common;
using Ponto.Base.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ponto.Base.Data.Interface
{
    public interface IUserRepository : ICoreRepository<User>
    {
        User GetByEmail(string email);       
        
        void InsertUser(string nome, string email, string senha);
    }
}

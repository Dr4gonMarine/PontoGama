using Ponto.Base.Context;
using Ponto.Base.Data.Common;
using Ponto.Base.Data.Interface;
using Ponto.Base.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ponto.Base.Data.Repository
{
    public class UserRepository : CoreRepository<User>, IUserRepository
    {
        public UserRepository()
        {
            DbContext = PontoContext.Current;
        }

        public User GetByEmail(string email)
        {
            try
            {
                var user = _dbContext.Conexao.FindWithQuery<User>("SELECT * FROM USER WHERE EMAIL_USER = ?", email);

                return user;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertUser(string nome, string email, string senha, bool estagiario)
        {
            try
            {
                User user = new User() { Nome = nome, Email = email, Senha = senha, IsEstagiario = estagiario};
                _dbContext.Conexao.Insert(user);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

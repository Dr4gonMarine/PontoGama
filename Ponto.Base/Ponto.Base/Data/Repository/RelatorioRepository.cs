using Ponto.Base.Context;
using Ponto.Base.Data.Common;
using Ponto.Base.Data.Interface;
using Ponto.Base.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ponto.Base.Data.Repository
{
    public class RelatorioRepository : CoreRepository<Relatorio>, IRelatorioRepository
    {
        public RelatorioRepository()
        {
            DbContext = PontoContext.Current;
        }

        public Relatorio GetRelatorioAtual()
        {
            try
            {
                return _dbContext.Conexao.FindWithQuery<Relatorio>("SELECT * FROM RELATORIO WHERE Inclusao = ?", DateTime.Now.Date);              
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }       
        }

        public void InserirIdUsuario(Guid IdUser)
        {
            try
            {
                Relatorio relatorioAtual = new Relatorio() { IdUser = IdUser}; //criando o relatorio
                _dbContext.Conexao.Insert(relatorioAtual);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}

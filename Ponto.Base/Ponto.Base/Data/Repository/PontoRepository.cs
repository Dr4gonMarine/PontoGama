using Ponto.Base.Context;
using Ponto.Base.Data.Common;
using Ponto.Base.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ponto.Base.Data.Repository
{
    public class PontoRepository : CoreRepository<Models.Ponto>, IPontoRepository
    {
        public PontoRepository()
        {
            DbContext = PontoContext.Current;
        }        

        public void InsertPontoHrInicial(DateTime HoraAtual, Guid IdUser)
        {
            try
            {
                Models.Ponto ponto = new Models.Ponto() { HrInicio = HoraAtual, IdUser = IdUser};
                _dbContext.Conexao.Insert(ponto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void InsertPontoHrFinal(DateTime HoraAtual, Guid IdUser)
        {
            try
            {
                _dbContext.Conexao.Query<Models.Ponto>("UPDATE PONTO SET HR_FINAL = ? WHERE ID_USER = ?", HoraAtual,IdUser);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Models.Ponto GetLastPonto(Guid IdUser)
        {
            try
            {
                var lastPonto = _dbContext.Conexao.FindWithQuery<Models.Ponto>("SELECT * FROM PONTO WHERE HR_FINAL IS NULL AND HR_INICIO IS NOT NULL AND ID_USER = ? AND Inclusao = ?", IdUser, DateTime.Now);
                
                if(lastPonto != null)
                {
                    return lastPonto;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }
    }
}

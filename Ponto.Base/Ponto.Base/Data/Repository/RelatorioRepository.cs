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

        public void AtualizaSaldo(TimeSpan? Saldo, Guid IdRelatorio)
        {
            try
            {
                _dbContext.Conexao.Query<Relatorio>("UPDATE RELATORIO SET SALDO = ? WHERE Id = ?", Saldo, IdRelatorio);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void AtualizaHrJornada(TimeSpan? HrJornada, Guid IdRelatorio)
        {
            try
            {                
                _dbContext.Conexao.Query<Relatorio>("UPDATE RELATORIO SET HR_JORNADA = ? WHERE Id = ?", HrJornada, IdRelatorio);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Relatorio> GetAllRelatorios(Guid IdUser)
        {
            try
            {
                return _dbContext.Conexao.Query<Relatorio>("SELECT * FROM RELATORIO WHERE ID_USER = ? ORDER BY Inclusao DESC", IdUser);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
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

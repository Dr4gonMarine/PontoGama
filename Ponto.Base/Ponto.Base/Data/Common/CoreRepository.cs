using Ponto.Base.Context;
using Ponto.Base.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ponto.Base.Data.Common
{
    public class CoreRepository<T> : ICoreRepository<T> where T : CoreEntity, new()
    {
        protected PontoContext _dbContext;

        public PontoContext DbContext
        {
            get { return _dbContext; }
            set { _dbContext = value; }
        }

        public void Delete(T model)
        {
            try
            {
                var rs = _dbContext.Conexao.Delete(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteAll(List<T> model)
        {
            try
            {
                _dbContext.Conexao.BeginTransaction();

                foreach (var _model in model)
                {
                    var rs = _dbContext.Conexao.Delete(_model);

                    if (rs == 0)
                        throw new Exception("Erro ao excluir registro");
                }

                _dbContext.Conexao.Commit();
            }
            catch (Exception ex)
            {
                _dbContext.Conexao.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public void DeleteAll()
        {
            _dbContext.Conexao.DeleteAll<T>();
        }

        public void DeleteById(Guid? Id)
        {
            try
            {
                var rs = _dbContext.Conexao.Delete<T>(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<T> GetAll()
        {
            try
            {
                return _dbContext.Conexao.Table<T>().ToList();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<T> GetUsers()
        {
            try
            {
                return _dbContext.Conexao.Table<T>().ToList();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<T> GetAllAtivos()
        {
            try
            {
                return _dbContext.Conexao.Table<T>().Where(t => t.Ativo == 1).ToList();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public T GetById(Guid Id)
        {
            try
            {
                return _dbContext.Conexao.Get<T>(Id);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public DateTime? GetLastUpdate()
        {
            try
            {
                var result = _dbContext.Conexao.Table<T>();
                if (result.Count() > 0)
                    return result.Max(t => t.Alteracao);
                else
                    return DateTime.MinValue;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void InsertOrReplace(T Model)
        {
            try
            {
                var rs = _dbContext.Conexao.InsertOrReplace(Model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertOrReplace(List<T> Model)
        {
            try
            {
                _dbContext.Conexao.BeginTransaction();

                foreach (var model in Model)
                {
                    var rs = _dbContext.Conexao.InsertOrReplace(model);

                    if (rs == 0)
                        throw new Exception("Erro ao inserir registro");
                }

                _dbContext.Conexao.Commit();
            }
            catch (Exception ex)
            {
                _dbContext.Conexao.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public void Update(T model)
        {
            try
            {
                var rs = _dbContext.Conexao.Update(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

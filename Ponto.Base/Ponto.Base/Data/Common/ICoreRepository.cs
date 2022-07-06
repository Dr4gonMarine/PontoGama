using Ponto.Base.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ponto.Base.Data.Common
{
    public interface ICoreRepository <T> where T : CoreEntity
    {
        T GetById(Guid Id);

        void InsertOrReplace(T Model);

        void InsertOrReplace(List<T> Model);

        List<T> GetAll();

        DateTime? GetLastUpdate();

        void DeleteById(Guid? Id);

        void Delete(T model);

        void DeleteAll(List<T> model);

        void DeleteAll();

        void Update(T model);

        List<T> GetAllAtivos();
    }
}

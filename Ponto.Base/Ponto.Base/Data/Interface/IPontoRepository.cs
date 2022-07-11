using Ponto.Base.Data.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Ponto.Base.Models;

namespace Ponto.Base.Data.Interface
{
    public interface IPontoRepository: ICoreRepository<Models.Ponto>
    {
        void InsertPontoHrInicial(DateTime HoraAtual, Guid IdUser, Guid IdRelatorio);       
        void InsertPontoHrFinal(DateTime HoraAtual, Models.Ponto lastPonto);
        Models.Ponto GetLastPonto(Guid IdUser);
        List<Models.Ponto> GetPontosDoDia(Guid IdUser, DateTime Data);
    }
}

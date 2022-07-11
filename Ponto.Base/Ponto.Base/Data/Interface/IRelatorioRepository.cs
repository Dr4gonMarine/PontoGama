using Ponto.Base.Data.Common;
using Ponto.Base.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ponto.Base.Data.Interface
{
    public interface IRelatorioRepository : ICoreRepository<Relatorio>
    {
        Relatorio GetRelatorioAtual();

        void InserirIdUsuario(Guid IdUser);

        List<Relatorio> GetAllRelatorios(Guid IdUser);

        void AtualizaHrJornada(TimeSpan? Jornada, Guid IdRelatorio);
        void AtualizaSaldo(TimeSpan? Saldo, Guid IdRelatorio);
    }
}

using Ponto.Base.Data.Interface;
using Ponto.Base.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Ponto.Base.Context
{
    public class PontoContext
    {
        private static SQLiteConnection _sqliteConnection;

        public static PontoContext _lazy;

        public static PontoContext Current
        {
            get
            {
                if (_lazy == null)
                    _lazy = new PontoContext();

                return _lazy;
            }
        }

        public PontoContext()
        {
            _sqliteConnection = new SQLiteConnection(DependencyService.Get<IDBPath>().GetDbPath());
            _sqliteConnection.CreateTable<User>();
            _sqliteConnection.CreateTable<Models.Ponto>();
        }

        public SQLiteConnection Conexao
        {
            get { return _sqliteConnection; }
            set { _sqliteConnection = value; }
        }
    }
}

using Ponto.Base.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ponto.Base.Models
{
    [SQLite.Table("USER")]
    public class User : CoreEntity
    {
        [SQLite.Column("ID_USER")]        
        public Guid Id_User { get; set; }

        [SQLite.Column("NOME_USER")]
        public string Nome { get; set; }

        [SQLite.Column("EMAIL_USER")]
        [SQLite.MaxLength(150)]
        public string Email { get; set; }

        [SQLite.Column("SENHA_USER")]
        [SQLite.MaxLength(20)]
        public string Senha { get; set; }
    }
}

using Ponto.Base.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ponto.Base.Models
{
    [SQLite.Table("USER")]
    public class User : CoreEntity
    {       
        [SQLite.Column("EMAIL_USER")]
        [SQLite.MaxLength(150)]
        public string Email { get; set; }

        [SQLite.Column("SENHA_USER")]
        [SQLite.MaxLength(20)]
        public string Senha { get; set; }
    }
}

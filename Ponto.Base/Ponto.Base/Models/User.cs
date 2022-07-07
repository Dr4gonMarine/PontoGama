using Ponto.Base.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Ponto.Base.Models
{
    [Table("USER")]
    public class User : CoreEntity
    {       
        [Column("NOME_USER")]
        public string Nome { get; set; }

        [Column("EMAIL_USER")]
        [MaxLength(150)]
        public string Email { get; set; }

        [Column("SENHA_USER")]
        [MaxLength(20)]
        public string Senha { get; set; }
    }
}

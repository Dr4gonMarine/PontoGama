using Ponto.Base.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Ponto.Base.Models
{
    [Table("RELATORIO")]
    public class Relatorio : CoreEntity
    {        
        [Column("HR_JORNADA")]
        public TimeSpan? HrJornada { get; set; }

        [Column("SALDO")]
        public TimeSpan? Saldo { get; set; }       

        [Column("ID_USER")]
        public Guid IdUser { get; set; }
    }
}

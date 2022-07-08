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
        public DateTime HrJornada { get; set; }

        [Column("RE_SALDO")]
        public TimeSpan? HrFinal { get; set; }       

        [Column("ID_USER")]
        public Guid IdUser { get; set; }
    }
}

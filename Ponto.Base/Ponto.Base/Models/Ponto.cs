using Ponto.Base.Models.Base;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ponto.Base.Models
{
    [Table("PONTO")]
    public class Ponto : CoreEntity
    {
        [Column("HR_INICIO")]
        public DateTime HrInicio { get; set; }

        [Column("HR_FINAL")]
        public DateTime? HrFinal{ get; set; }

        [Column("HR_JORNADA")]
        public TimeSpan? HrJornada { get; set; }

        [Column("ID_USER")]
        public Guid IdUser { get; set; }

        [Column("ID_RELATORIO")]
        public Guid IdRelatorio { get; set; }
    }
}

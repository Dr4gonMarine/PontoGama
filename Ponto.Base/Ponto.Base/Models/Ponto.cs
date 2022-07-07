using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ponto.Base.Models
{
    [Table("PONTO")]
    public class Ponto
    {
        [Column("HR_INICIO")]
        public DateTime HrInicio { get; set; }

        [Column("HR_FINAL")]
        public DateTime? HrFinal{ get; set; }

        [Column("SALDO")]
        public TimeSpan? Saldo { get; set; }

        [Column("ID_USER")]
        public Guid IdUser { get; set; }

    }
}

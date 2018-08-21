using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SanApp.Models
{
    public class San
    {
        public San()
        {
            Participantes = new List<Participante>();
        }

        public int SanId { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaApertura { get; set; }
        public bool Cerrado { get; set; }

        [DataType(DataType.Currency)]
        public decimal Monto { get; set; }

        public List<Participante> Participantes { get; set; }
    }
}

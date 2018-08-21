using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SanApp.Models
{
    public class Pago
    {
        public int PagoId { get; set; }

        [DataType(DataType.Currency)]
        public decimal Monto { get; set; }

        public DateTime FechaPago { get; set; }

        public Participante Participante { get; set; }
        public int ParticipanteId { get; set; }
    }
}

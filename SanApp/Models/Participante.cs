using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SanApp.Models
{
    public class Participante
    {
        public Participante()
        {
            Pagos = new List<Pago>();
        }

        public int ParticipanteId { get; set; }
        public string Nombre { get; set; }
        [DataType(DataType.Currency)]
        public decimal Deuda { get; set; }
        public DateTime FechaEntrega { get; set; }
        public bool HaCobrado { get; set; }

        public San San { get; set; }
        public int SanId { get; set; }

        public List<Pago> Pagos { get; set; }
    }
}

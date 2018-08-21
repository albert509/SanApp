using SanApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SanApp.ViewModels.SanViewModel
{
    public class SanViewModel
    {
        public SanViewModel()
        {
            Participantes = new List<Participante>();
        }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public int SanId { get; set; }
        public DateTime FechaApertura { get; set; }

        public List<Participante> Participantes { get; set; }

    }
}

using SanApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SanApp.ViewModels.HomeViewModel
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            SanList = new List<San>();
        }
        public string SanDescripcion { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaInicio { get; set; }

        public List<San> SanList { get; set; }
    }
}

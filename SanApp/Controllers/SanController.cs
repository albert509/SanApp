using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SanApp.Data;
using SanApp.Models;
using SanApp.ViewModels.HomeViewModel;
using SanApp.ViewModels.SanViewModel;

namespace SanApp.Controllers
{
    public class SanController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;
        public SanController(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NuevoSan(HomeViewModel viewModel)
        {
            var sanToSave = new San
            {
                Descripcion = viewModel.SanDescripcion,
                Monto = viewModel.Monto,
                FechaApertura = viewModel.FechaInicio,
                Cerrado = false
            };

            _dbcontext.San.Add(sanToSave);
            _dbcontext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpDelete]
        public IActionResult DeleteSan(int id)
        {
            var sanToDelete = _dbcontext.San.SingleOrDefault(s => s.SanId == id);

            if(sanToDelete != null)
            {
                _dbcontext.San.Remove(sanToDelete);
                _dbcontext.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            else return NotFound();
        }

        public IActionResult SanInfo(int sanId)
        {
            var sanViewModel = _dbcontext.San
                .Include(s => s.Participantes)
                .Where(s => s.SanId == sanId)
                .Select(s => new SanViewModel { Descripcion = s.Descripcion, Monto = s.Monto, Participantes = s.Participantes, SanId = s.SanId,FechaApertura = s.FechaApertura })
                .FirstOrDefault();

            return View(sanViewModel);
        }

        [HttpPost]
        public IActionResult AddParticipante(SanViewModel viewModel,int SanId)
        {
            var currentSan = _dbcontext.San.Include(s => s.Participantes).SingleOrDefault(s => s.SanId == SanId);

            var newParticipante = new Participante
            {
                Nombre = viewModel.Nombre,
                HaCobrado = false,
                SanId = SanId,
                FechaEntrega = currentSan.FechaApertura.AddMonths(currentSan.Participantes.Count + 1),
                Deuda = currentSan.Monto
            };

            _dbcontext.Participantes.Add(newParticipante);
            _dbcontext.SaveChanges();

            return RedirectToAction("SanInfo",new { sanId=SanId});
        }

        [HttpGet]
        public IActionResult ParticipanteInfo(int id)
        {
            var participante = _dbcontext.Participantes.Include(p => p.Pagos).SingleOrDefault(p => p.ParticipanteId == id);
            if (participante != null)
            {
                var viewModel = new ParticipanteViewModel { Participante = participante };
                return View(viewModel);
            }
                
            else return NotFound();
        }

        [HttpPost]
        public IActionResult RegistrarPago(ParticipanteViewModel ViewModel,int partId)
        {
            var participante = _dbcontext.Participantes.SingleOrDefault(p => p.ParticipanteId == partId);
            participante.Deuda -= ViewModel.PagoTotal;

            var pago = new Pago
            {
                Monto = ViewModel.PagoTotal,
                FechaPago = DateTime.Today,
                ParticipanteId = partId
            };

            _dbcontext.Pagos.Add(pago);
            _dbcontext.SaveChanges();

            return RedirectToAction("ParticipanteInfo", new { id = partId });

        }
    }
}
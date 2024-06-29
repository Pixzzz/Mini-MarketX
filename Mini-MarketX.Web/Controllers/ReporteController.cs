using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mini_MarketX.Data.Entities;
using Mini_MarketX.Data.Interfaces;

namespace Mini_MarketX.Web.Controllers
{
    public class ReporteController : Controller
    {
        private readonly IReporteRepository reporteRepository;

        public ReporteController(IReporteRepository reporteRepository)
        {
            this.reporteRepository = reporteRepository;
        }

        // GET: ReporteController
        public ActionResult Index()
        {
            var reportes = this.reporteRepository.TraerTodos();
            return View(reportes);
        }

        // GET: ReporteController/Details/5
        public ActionResult Details(int id)
        {
            var reporte = this.reporteRepository.ObtenerPorId(id);
            return View(reporte);
        }

        // GET: ReporteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReporteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reporte reporte)
        {
            try
            {
                this.reporteRepository.Agregar(reporte);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReporteController/Edit/5
        public ActionResult Edit(int id)
        {
            var reporte = this.reporteRepository.ObtenerPorId(id);
            return View(reporte);
        }

        // POST: ReporteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Reporte reporte)
        {
            try
            {
                this.reporteRepository.Actualizar(reporte);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

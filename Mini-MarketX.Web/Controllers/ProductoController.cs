using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mini_MarketX.Data.Entities;
using Mini_MarketX.Data.Interfaces;

namespace Mini_MarketX.Web.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoMMXRepository productoMMXRepository;

        public ProductoController(IProductoMMXRepository productoMMXRepository)
        {
            this.productoMMXRepository = productoMMXRepository;
        }

        // GET: ProductoController
        public ActionResult Index()
        {
            var productos = this.productoMMXRepository.TraerTodos();
            return View(productos);
        }

        // GET: ProductoController/Details/5
        public ActionResult Details(int id)
        {
            var producto = this.productoMMXRepository.ObtenerporId(id);
            return View(producto);
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Producto producto)
        {
            try
            {
                this.productoMMXRepository.Agregar(producto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Edit/5
        public ActionResult Edit(int id)
        {
            var producto = this.productoMMXRepository.ObtenerporId(id);
            return View(producto);
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Producto producto)
        {
            try
            {
                this.productoMMXRepository.Actualizar(producto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(producto);
            }
        }
    }
}

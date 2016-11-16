using Calamari.Models;
using Calamari.Service.Contracts;
using System.Net;
using System.Web.Mvc;

namespace Calamari.ClientPortal.Controllers
{
    public class ProductController : Controller
    {
        public ProductController(IProductService productService)
        {
            _ProductService = productService;
        }

        // GET: Product
        public ActionResult Index()
        {
            return View(_ProductService.GetAll());
        }

        // GET: /Product/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Product = _ProductService.GetById(id.Value);
            if (Product == null)
            {
                return HttpNotFound();
            }
            return View(Product);
        }

        // GET: /Product/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(_ProductService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: /Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Phone,Address,State,CountryId")] Product Product)
        {
            if (ModelState.IsValid)
            {
                _ProductService.Create(Product);
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(_ProductService.GetAll(), "Id", "Name", Product.Id);
            return View(Product);
        }

        // GET: /Product/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product Product = _ProductService.GetById(id.Value);
            if (Product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(_ProductService.GetAll(), "Id", "Name", Product.Id);
            return View(Product);
        }

        // POST: /Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price")] Product Product)
        {
            if (ModelState.IsValid)
            {
                _ProductService.Update(Product);
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(_ProductService.GetAll(), "Id", "Name", Product.Id);
            return View(Product);
        }

        // GET: /Product/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product Product = _ProductService.GetById(id.Value);
            if (Product == null)
            {
                return HttpNotFound();
            }
            return View(Product);
        }

        // POST: /Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Product product = _ProductService.GetById(id);
            _ProductService.Delete(product);
            return RedirectToAction("Index");
        }

        #region Class Fields

        private IProductService _ProductService;

        #endregion Class Fields
    }
}
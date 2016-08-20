using RedCamel.Domain.Abstract;
using RedCamel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedCamel.WebUI.Controllers
{
    public class AdminController : Controller
    {

        private IProductRepository repository;
        private IShopSearchRepository shopRepository;

        public AdminController(IProductRepository repo, IShopSearchRepository shopRepo)
        {
            repository = repo;
            shopRepository = shopRepo;
        }


        // GET: Admin
        public ViewResult Index()
        {
            return View(repository.Products);
        }

        public ViewResult Edit(int ID)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ID == ID);
            return View(product); }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase Image1, HttpPostedFileBase Image2)
        {
            if (ModelState.IsValid) {

                if (Image1 != null && Image1.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(Image1.FileName);
                    var path = Path.Combine(Server.MapPath("~/images/uploads"), fileName);
                    Image1.SaveAs(path);
                    var pathDB = String.Format("/images/uploads/{0}", fileName);
                    product.Image1Name = fileName;
                    product.Image1Path = pathDB;
                }

                if (Image2 != null && Image2.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(Image2.FileName);
                    var path = Path.Combine(Server.MapPath("~/images/uploads"), fileName);
                    Image2.SaveAs(path);
                    var pathDB = String.Format("/images/uploads/{0}", fileName);
                    product.Image2Name = fileName;
                    product.Image2Path = pathDB;
                }

                repository.SaveProduct(product);

                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index"); }
            else
            {
                // there is something wrong with the data values    
                return View(product);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Product());
        }
    }
}
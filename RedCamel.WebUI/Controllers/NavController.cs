using RedCamel.Domain.Abstract;
using RedCamel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedCamel.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository repository;

        public NavController(IProductRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu(CategoryEnum category = CategoryEnum.All, bool horizontalLayout = false)
        {
            ViewBag.SelectedCategory = category;
            /*
            IEnumerable<string> categories = repository.Products
                .Select(x => x.Category.ToString())
                .Distinct()
                .OrderBy(x => x);
                */

            IEnumerable<string> categories = repository.Categories
                    .Select(x => x.Name)
                    .Distinct()
                    .OrderBy(x => x);



            string viewName = horizontalLayout ? "MenuHorizontal" : "Menu";

            return PartialView(viewName,categories);
        }
    }
}
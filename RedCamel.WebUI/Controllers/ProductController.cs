using RedCamel.Domain.Abstract;
using RedCamel.Domain.Entities;
using RedCamel.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedCamel.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 3;

        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        [Route("Product/List")]
        [Route("Product/{Subject}/{category}/{page}")]
        public ViewResult List(int? Subject = null, CategoryEnum category = CategoryEnum.All,int page = 1)
        {
            //var publisher = repository.Products.First().Publisher; //nudge lazy loader


            ProductsListViewModel model = new ProductsListViewModel();
            

            if(Subject != null)
            {
                model = new ProductsListViewModel
                {
                    Products = repository.Products
                                .Where(p=>p.Subject== Subject)
                               .OrderBy(p => p.ID)
                               .Skip((page - 1) * PageSize)
                               .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = repository.Products.Count()
                    },
                    CurrentCategory = ((CategoryEnum)category).ToString()
                };

                return View(model);
            }

            if (category == CategoryEnum.All)
            {
                model = new ProductsListViewModel
                {
                    Products = repository.Products
                               .OrderBy(p => p.ID)
                               .Skip((page - 1) * PageSize)
                               .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = repository.Products.Count()
                    },
                    CurrentCategory = ((CategoryEnum)category).ToString()
                };

            }
            else
            {

                model = new ProductsListViewModel
                {
                    Products = repository.Products
                                .Where(p => p.Category == category)
                               .OrderBy(p => p.ID)
                               .Skip((page - 1) * PageSize)
                               .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = repository.Products.Where(e => e.Category == category).Count()
                    },
                    CurrentCategory = ((CategoryEnum)category).ToString()
                };
            };

            return View(model);

        }
        //
        // GET: /Product/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Greet(Greeting g)
        {
            return Content(g.Greet);
        }
	}
}
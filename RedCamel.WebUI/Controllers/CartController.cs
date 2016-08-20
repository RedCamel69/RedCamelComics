﻿using RedCamel.Domain.Abstract;
using RedCamel.Domain.Entities;
using RedCamel.WebUI.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedCamel.WebUI.Controllers
{
    public class CartController : Controller
    {

        private IProductRepository repository;
        private IOrderProcessor orderProcessor;

        public CartController(IProductRepository repo, IOrderProcessor proc)
        {
            repository = repo;
            orderProcessor = proc;
        }

       public RedirectToRouteResult AddToCart(Cart cart, int Id, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ID == Id);
            if (product != null) {
                //GetCart().AddItem(product, 1); 
                cart.AddItem(product, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart,int productId, string returnUrl) {
            Product product = repository.Products.FirstOrDefault(p => p.ID == productId);
            if (product != null) {
                cart.RemoveLine(product); }
            return RedirectToAction("Index", new { returnUrl });
        }

        private Cart GetCart() {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null) {
                cart = new Cart(); Session["Cart"] = cart;
            }
            return cart;
        }

        public ViewResult Index(Cart cart,string returnUrl) {
            return View(new CartIndexViewModel {
                Cart = cart, //GetCart(),
                ReturnUrl = returnUrl
            });
        }

        public PartialViewResult Summary(Cart cart) {
            return PartialView(cart);
        }

        [HttpGet]
        public ViewResult Checkout(ShippingDetails shippingDetails)
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails) {

            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty");
            }

            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(new ShippingDetails());
            }
        }

    }
}
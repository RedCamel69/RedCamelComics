using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RedCamel.Domain.Abstract;
using RedCamel.Domain.Entities;
using RedCamel.WebUI.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace RedCamel.UnitTests
{
    [TestClass]
    public class AdminTests
    {
        [TestMethod]
        public void Test_Index_Contains_All_Products()
        {
            //arrange - create mock repository
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            Mock<IShopSearchRepository> mocksearch = new Mock<IShopSearchRepository>();

            mock.Setup(m => m.Products).Returns(new Product[] {

                new Product() {  ID=1,Name="P1"},
                new Product() { ID=2,Name="P2"},
                new Product() { ID=3,Name="P3"}
            });

            //arrange - create a controller
            AdminController target = new AdminController(mock.Object, mocksearch.Object);

            // Action           
            Product[] result = ((IEnumerable<Product>)target.Index().ViewData.Model).ToArray();


            //assert
            Assert.AreEqual(result.Length, 3);
            Assert.AreEqual("P1", result[0].Name);
        }
    }
}

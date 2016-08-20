using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedCamel.Domain.Abstract;
using RedCamel.Domain.Entities;
using System.Linq;
using Moq;
using RedCamel.WebUI.Controllers;
using System.Collections.Generic;
using System.Web.Mvc;
using RedCamel.WebUI.Models;
using RedCamel.WebUI.HtmlHelpers;


namespace RedCamel.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            //arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ID = 1, Name = "P1"},
                new Product {ID = 2, Name = "P2"},
                new Product {ID = 3, Name = "P3"},
                new Product {ID = 4, Name = "P4"},
                new Product {ID = 5, Name = "P5"}
            });
            ProductController controller = new ProductController(mock.Object);

            controller.PageSize = 2;

            // Act
            ProductsListViewModel result = (ProductsListViewModel)controller.List(null,CategoryEnum.All,2).Model;



            //assert
            Assert.IsTrue(true);
            Assert.IsTrue(result.Products.Count() == 2);

        }

        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            // Arrange - define an HTML helper - we need to do this
            // in order to apply the extension method
            HtmlHelper myHelper = null;
            // Arrange - create PagingInfo data
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };
            // Arrange - set up the delegate using a lambda expression
            Func<int, string> pageUrlDelegate = i => "Page" + i;
            // Act
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);
            // Assert
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
            + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
            + @"<a class=""btn btn-default"" href=""Page3"">3</a>",
            result.ToString());
        }

        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {

            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ID = 1, Name = "P1"},
                new Product {ID = 2, Name = "P2"},
                new Product {ID = 3, Name = "P3"},
                new Product {ID = 4, Name = "P4"},
                new Product {ID = 5, Name = "P5"}
                });
            // Arrange
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;
            // Act
            ProductsListViewModel result = (ProductsListViewModel)controller.List(null,CategoryEnum.All,2).Model;
            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
        }

        [TestMethod]
        public void Can_Filter_Products()
        {
            //arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {  ID= 1, Name = "P1", Category = CategoryEnum.Comic },
                new Product { ID = 2, Name = "P2", Category = CategoryEnum.Comic },
                new Product { ID = 3, Name = "P3", Category = CategoryEnum.Comic },
                new Product { ID = 4, Name = "P4", Category = CategoryEnum.Comic },
                new Product { ID = 5, Name = "P5", Category = CategoryEnum.Comic } });

            //arrange
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            //action
            Product[] result = ((ProductsListViewModel)controller.List(null,CategoryEnum.Comic, 1).Model).Products.ToArray();


            //assert
            Assert.AreEqual(result.Length, 2); Assert.IsTrue(result[0].Name == "P2" && result[0].Category == CategoryEnum.Comic); Assert.IsTrue(result[1].Name == "P4" && result[1].Category == CategoryEnum.Comic);
        }

        [TestMethod]
        public void Can_Create_Categories()
        {
            //arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product {ID=1, Category=CategoryEnum.Hardback, Name="P1" },
                new Product {ID=2, Category=CategoryEnum.Hardback, Name="P2" },
                new Product {ID=3, Category=CategoryEnum.Hardback, Name="P3" },
                new Product {ID=4, Category=CategoryEnum.Hardback, Name="P4" }
            });

            //arrange- create controller
            NavController controller = new NavController(mock.Object);

            //act - get results
            string[] res = ((IEnumerable<string>)controller.Menu().Model).ToArray();

            //assert
            Assert.AreEqual(res.Length, 3);
            Assert.AreEqual(res[1], CategoryEnum.Hardback);



        }
    }
}
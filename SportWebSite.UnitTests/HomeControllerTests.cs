using Microsoft.AspNetCore.Mvc;
using SportWebSite.Controllers;
using Xunit;

namespace SportWebSite.UnitTests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexViewResultNotNull()
        {
            var controller = new HomeController();
            var result = controller.Index() as ViewResult;

            Assert.NotNull(result);
        }

        [Fact]
        public void IndexViewDataTitle()
        {
            var controller = new HomeController();
            var result = controller.Index() as ViewResult;

            Assert.Equal("Football", result?.ViewData["Title"]);
        }

        [Fact]
        public void IndexViewNameEqualIndex()
        {
            var controller = new HomeController();
            var result = controller.Index() as ViewResult;

            Assert.Equal("Index", result?.ViewName);
        }
    }
}
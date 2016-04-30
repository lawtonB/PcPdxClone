using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using PcPdx.Controllers;
using PcPdx.Models;
using Xunit;

namespace PcPdx.Tests.ControllerTests
{
    public class ShowsControllerTest
    {
        [Fact]
        public void Get_ViewResult_Index_Test()
        {
            //Arrange
            ShowsController controller = new ShowsController();

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
        }
    }
}

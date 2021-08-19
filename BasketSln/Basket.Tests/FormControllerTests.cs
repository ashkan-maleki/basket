using System;
using System.Collections.Generic;
using System.Linq;
using Basket.Controllers;
using Basket.Models.Entities;
using Basket.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Basket.Tests
{
    public class FormControllerTests
    {

        private void setup()
        {
            
        }
        [Fact]
        public void Can_Use_Repository()
        {
            // Arrange
            Mock<IBasketRepository> mock = new Mock<IBasketRepository>();
            mock.Setup(m => m.Forms).Returns((new Form[]
            {
                new Form {FormID = 1, Name = "F1"},
                new Form {FormID = 2, Name = "F2"}
            }).AsQueryable<Form>());
            
            FormController controller = new FormController(mock.Object);
            
            // Act
            IEnumerable<Form> result = (controller.Index() as ViewResult)?.ViewData.Model
                as IEnumerable<Form>;
            
            // Assert
            Form[] formArray = (result ?? new List<Form>()).ToArray();
            Assert.True(formArray.Length == 2);
            Assert.Equal("F1", formArray[0].Name);
            Assert.Equal("F2", formArray[1].Name);
        }

        [Fact]
        public void Can_Paginate()
        {
            // Arrange
            Mock<IBasketRepository> mock = new Mock<IBasketRepository>();
            mock.Setup(m => m.Forms).Returns((new Form[]
            {
                new Form {FormID = 1, Name = "F1"},
                new Form {FormID = 2, Name = "F2"},
                new Form {FormID = 3, Name = "F3"},
                new Form {FormID = 4, Name = "F4"},
                new Form {FormID = 5, Name = "F5"}
            }).AsQueryable<Form>());

            FormController controller = new FormController(mock.Object) {PageSize = 3};

            // Act
            IEnumerable<Form> result = (controller.Index(2) as ViewResult)?.ViewData.Model
                as IEnumerable<Form>;
            
            // Assert
            Form[] formArray = (result ?? new List<Form>()).ToArray();
            Assert.True(formArray.Length == 2);
            Assert.Equal("F4", formArray[0].Name);
            Assert.Equal("F5", formArray[1].Name);
        }
    }
}

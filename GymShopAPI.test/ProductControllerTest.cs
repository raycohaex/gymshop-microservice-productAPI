using System;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using GymShopAPI.DAL.Classes;
using GymShopAPI.DAL.Models;
using GymShopAPI.DAL.Controllers;
using GymShopAPI.DAL.Interfaces;
using GymShopAPI.BLL.Controllers;
using Grumpy.Common.Threading;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace GymShopAPI.test
{
    public class ProductControllerTest
    {
        private readonly ProductsController _pc;
        private readonly Mock<IProductsDbAccess> _pdba = new Mock<IProductsDbAccess>();

        public ProductControllerTest()
        {
            _pc = new ProductsController(_pdba.Object);
        }

        /// <summary>
        /// Check to see if a product gets returned
        /// </summary>
        [Fact]
        public async void GetByIdAsync_ExpectsReturnOfProduct_IfProductExists()
        {
            // Arrange
            var id = 1;
            var product = new Product
            {
                Id = 1,
                Sku = "abc",
                Name = "Whey protein",
                Description = "Protein powder",
                Price = 5

            };
            _pdba.Setup(x => x.GetProduct(1))
                .ReturnsAsync(product);

            // Act
            var result = await _pc.GetProduct(1);

            // Assert
            Assert.Equal(id, result.Value.Id);
        }

        /// <summary>
        /// Id is not valid so it should return a null
        /// </summary>
        [Fact]
        public async void GetByIdAsync_ExpectsFail_IdDoesntExist()
        {
            // Arrange
            var id = 2;
            var product = new Product
            {
                Id = 1,
                Sku = "abc",
                Name = "Whey protein",
                Description = "Protein powder",

            };
            _pdba.Setup(x => x.GetProduct(id))
                .ReturnsAsync(product);

            // Act
            var result = await _pc.GetProduct(id);

            // Assert
            Assert.Null(result.Result);
        }
    }
}

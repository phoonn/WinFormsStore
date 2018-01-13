using BusinessLogic;
using DataModel.Entities;
using Interfaces.Repositories;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.UnitTesting.LogicTests
{
    [TestFixture]
    public class ProductLogicTests
    {
        private IUnitOfWork StubUnit;
        private IProductRepository StubProductRepo;
        private IProviderRepository StubProviderRepo;
        private IProductTypeRepository StubProductTypeRepo;
        private ISerialNumberRepository StubSerialNumberRepo;
        [SetUp]
        public void SetUpMethod()
        {
            StubUnit = Substitute.For<IUnitOfWork>();
            StubProductRepo = Substitute.For<IProductRepository>();
            StubProviderRepo = Substitute.For<IProviderRepository>();
            StubProductTypeRepo = Substitute.For<IProductTypeRepository>();
            StubSerialNumberRepo = Substitute.For<ISerialNumberRepository>();
        }
        [Test]
        public void AddProduct_NUllProductType_AddingNewProductType()
        {
            //Arrange
            Product product = new Product {
                Number = "10", ProductName = "Asus",
                ProductTypeId = 0, Quantity = 10,
                PricePaid = 200, PriceWithoutVat = 180,
                Price = 220, Provider = null,
                ProductTypeName = "laptop", ProductType=null
            };
            List<SerialNumber> serialnums = new List<SerialNumber> { new SerialNumber { SerialNum="123456789"} };
                //fakes
            IProductRepository MockProductRepo = Substitute.For<IProductRepository>();

            ProductLogic logictesting = new ProductLogic(MockProductRepo, StubUnit, StubProviderRepo, StubProductTypeRepo, StubSerialNumberRepo);

            //Act
            logictesting.Add(product, serialnums);

            //Assert
            MockProductRepo.Received().Save(Arg.Is<Product>(p => p.ProductType.Type == product.ProductTypeName));
        }
        
        [Test]
        public void EditSerialNumbers_ModifiedNumbers_UpdateCalled()
        {
            //Arrange
            Product product = new Product
            {
                Number = "10",
                ProductName = "Asus",
                ProductTypeId = 0,
                Quantity = 10,
                PricePaid = 200,
                PriceWithoutVat = 180,
                Price = 220,
                Provider = null,
                ProductTypeName = "laptop",
                ProductType = null
            };
            List<SerialNumber> serialnums = new List<SerialNumber> {
                new SerialNumber { Id=2,SerialNum = "123456789", Modified = true },
                new SerialNumber { Id=3,SerialNum = "45313231", Modified = false } ,
                new SerialNumber { Id=4,SerialNum = "4531313124", Modified = true } };
            product.SerialNumbers = serialnums;
            //fakes
            ISerialNumberRepository MockSerialNumberRepo = Substitute.For<ISerialNumberRepository>();

            ProductLogic logictesting = new ProductLogic(StubProductRepo, StubUnit, StubProviderRepo, StubProductTypeRepo, MockSerialNumberRepo);

            //Act
            logictesting.EditSerialNumbers(product, serialnums);

            //Assert
            MockSerialNumberRepo.Received(2).Update(Arg.Any<SerialNumber>());
        }

        [Test]
        public void EditSerialNumbers_SaveSerial_SaveCalled()
        {
            //Arrange
            Product product = new Product
            {
                Number = "10",
                ProductName = "Asus",
                ProductTypeId = 0,
                Quantity = 10,
                PricePaid = 200,
                PriceWithoutVat = 180,
                Price = 220,
                Provider = null,
                ProductTypeName = "laptop",
                ProductType = null
            };
            List<SerialNumber> serialnums = new List<SerialNumber> {
                new SerialNumber { SerialNum = "123456789", Modified = true },
                new SerialNumber { Id=3,SerialNum = "45313231", Modified = false } ,
                new SerialNumber { Id=4,SerialNum = "4531313124", Modified = true } };
            product.SerialNumbers = serialnums;

            ISerialNumberRepository MockSerialNumberRepo = Substitute.For<ISerialNumberRepository>();

            ProductLogic logictesting = new ProductLogic(StubProductRepo, StubUnit, StubProviderRepo, StubProductTypeRepo, MockSerialNumberRepo);
            //Act
            logictesting.EditSerialNumbers(product, serialnums);

            //Assert
            MockSerialNumberRepo.Received().Save(Arg.Is<SerialNumber>(s=>(s.SerialNum==serialnums[0].SerialNum && s.ProductId==product.Id)));
        }
    }
}

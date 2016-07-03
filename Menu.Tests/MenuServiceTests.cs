using System.Collections.Generic;
using System.Linq;
using Menu.Business.Exceptions;
using Menu.Business.Managers;
using Menu.Contracts.DataContracts;
using Menu.Data;
using Menu.DAL.Core.Interfaces;
using Menu.DAL.RepositoryInterfaces;
using Menu.Service.Mappings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Assert = NUnit.Framework.Assert;

namespace Menu.Tests
{
    [TestClass]
    public class MenuServiceTests
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Mock<IMenuItemRepository> _mockMenuRepo;

        [TestInitialize]
        public void MenuServiceTestsInit()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMenuRepo = new Mock<IMenuItemRepository>();
            _mockUnitOfWork.SetupProperty(uow => uow.MenuItems, _mockMenuRepo.Object);

            AutoMapperConfiguration.Configure();
        }

        [TestMethod]
        public void GetMenuItem_Should_Return_MenuItem_By_Id_If_Item_Exist()
        {
            //Arrange
            var testMenuItem = new MenuItem()
            {
                Id = 5,
                Name = "Вода",
                Amount = "0.5л",
                Price = 100.00M,
            };

            _mockMenuRepo.Setup(repo => repo.Get(testMenuItem.Id)).Returns(testMenuItem);
            var menuManager = new MenuManager(_mockUnitOfWork.Object);

            //Act
            var returnedItem = menuManager.GetMenuItem(testMenuItem.Id);

            //Assert
            Assert.IsTrue(returnedItem.Name == "Вода");
            Assert.IsTrue(returnedItem.Amount == "0.5л");
            Assert.IsTrue(returnedItem.Price == 100.00M);
        }

        [TestMethod]
        public void GetMenuItem_Should_Throw_ObjectNotFoundException_If_Item_Is_Not_Exist()
        {
            //Arrange
            var menuManager = new MenuManager(_mockUnitOfWork.Object);

            //Act
            var ex = Assert.Throws<ObjectNotFoundException>(() => { menuManager.GetMenuItem(100); });

            //Assert
            Assert.AreEqual(ex.GetType(), typeof(ObjectNotFoundException));
        }

        [TestMethod]
        public void AddMenuItem_Should_Add_MenuItem()
        {
            //Arrange
            var testMenuItems = new List<MenuItem>();

            _mockMenuRepo.Setup(r => r.Add(It.IsAny<MenuItem>()))
                .Callback<MenuItem>(m => testMenuItems.Add(m));
            _mockMenuRepo.Setup(r => r.GetAll()).Returns(testMenuItems);
                
            var menuManager = new MenuManager(_mockUnitOfWork.Object);

            //Act
            menuManager.AddMenuItem(new MenuItemData());
            var testItemsCount = menuManager.GetMenuItems().Count();

            //Assert
            Assert.IsTrue(testItemsCount == 1);
        }

        [TestMethod]
        public void DeleteMenuItem_Should_Delete_MenuItem()
        {
            //Arrange
            var testMenuItems = new List<MenuItem>() {new MenuItem() { Id = 5 }};

            _mockMenuRepo.Setup(r => r.Delete(It.IsAny<MenuItem>()))
                .Callback<MenuItem>(m => testMenuItems
                .Remove(testMenuItems.First(mi => mi.Id == m.Id)));

            _mockMenuRepo.Setup(r => r.Get(It.IsAny<int>()))
                .Returns((int id) => { return testMenuItems.FirstOrDefault(m => m.Id == id); });

            _mockMenuRepo.Setup(r => r.GetAll()).Returns(testMenuItems);

            var menuManager = new MenuManager(_mockUnitOfWork.Object);

            //Act
            menuManager.DeleteMenuItem(5);
            var testItemsCount = menuManager.GetMenuItems().Count();

            //Assert
            Assert.IsTrue(testItemsCount == 0);
        }

        [TestMethod]
        public void DeleteMenuItem_Should_Throw_ObjectNotFoundException_If_Item_Is_Not_Exist()
        {
            //Arrange
            var menuManager = new MenuManager(_mockUnitOfWork.Object);

            //Act
            var ex = Assert.Throws<ObjectNotFoundException>(() => { menuManager.DeleteMenuItem(100); });

            //Assert
            Assert.AreEqual(ex.GetType(), typeof(ObjectNotFoundException));
        }
    }

}

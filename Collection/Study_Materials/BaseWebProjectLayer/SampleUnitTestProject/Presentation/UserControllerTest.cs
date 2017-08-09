using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseWebProjectLayer.Controllers;
using SampleUnitTestProject.ServiceMock;
using Model;

namespace SampleUnitTestProject
{
    [TestClass]
    public class UserControllerTest
    {
        private static UserController _userController;

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            _userController = new UserController(new UserServiceMock());
        }

        [TestMethod]
        public void GetUserTest()
        {
            var result = _userController.GetUser("karthik");
            Assert.IsTrue(result.Data is User);
            Assert.IsTrue((result.Data as User).Name == "karthik");
        }
    }
}

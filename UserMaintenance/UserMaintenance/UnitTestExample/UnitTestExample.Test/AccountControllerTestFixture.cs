using NUnit.Framework;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestExample;
using UnitTestExample.Controllers;

namespace UnitTestExample.Test
{
    public class AccountControllerTestFixture
    {
        [
            Test,
            TestCase("abcd", "false"),
             TestCase("abcd@xyz.com", "true"),
            ]
        public void TestValidateEmail(string email, bool expectedResult)
        {
            var accountController = new AccountController();

            var result = accountController.ValidateEmail(email);

            Assert.AreEqual(result, expectedResult);


        }

        [
            Test,
            TestCase("abcd1234", "false"),
            TestCase("ABCD1234", "false"),
            TestCase("Abcd1234", "true")
            ]
        public void TestValidatePassword(string password, bool expectedResult)
        {
            var accountController = new AccountController();

            var result = accountController.ValidatePassword(password);

            Assert.AreEqual(result, expectedResult);
        }

        [
Test,
TestCase("irf@uni-corvinus", "Abcd1234"),
TestCase("irf.uni-corvinus.hu", "Abcd1234"),
TestCase("irf@uni-corvinus.hu", "abcd1234"),
TestCase("irf@uni-corvinus.hu", "ABCD1234"),
TestCase("irf@uni-corvinus.hu", "abcdABCD"),
TestCase("irf@uni-corvinus.hu", "Ab1234"),
]
        public void TestRegisterValidateException(string email, string password)
        {
            // Arrange
            var accountController = new AccountController();

            // Act
            try
            {
                var actualResult = accountController.Register(email, password);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOf<ValidationException>(ex);
            }
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qobuz;

namespace UnitTestDLL
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Login()
        {
            Service service = new Service();
            try
            {
                User user = service.Login("saif@gmail.com", "testpwd");

                Assert.IsTrue(user != null && !string.IsNullOrEmpty(user.UserAuthToken));
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Задание_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_1.Tests
{
    [TestClass()]
    public class UserTests
    {
        [DataTestMethod()]
        
        public void FillingObjectFromStringTest()
        {
            var user1 = new User("WildLandowner", "Mikhail", "Saltykov-Shchedrin", "wild@gmail.com",
                     Functions.StringToDateTime("27-01-1826"),
                     Functions.StringToDateTime("10-05-1889"));


            Assert.Fail();
        }
    }
}
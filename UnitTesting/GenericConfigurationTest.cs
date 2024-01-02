using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    [TestClass]
    public class GenericConfigurationTest
    {
        [TestMethod]
        public void GetStringValueTest()
        {
            var conf = new SimpleConfigLoader.GenericConfiguration();

            conf.Add("Foo", "Bar");

            var val = conf.GetValue<string>("Foo");

            Assert.AreEqual("Bar", val);
        }

        [TestMethod]
        public void GetIntegerValueTest()
        {
            var conf = new SimpleConfigLoader.GenericConfiguration();

            conf.Add("Foo", 1234);

            var val = conf.GetValue<int>("Foo");

            Assert.AreEqual(1234, val);
        }
    }
}

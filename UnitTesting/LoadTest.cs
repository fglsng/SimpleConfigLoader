namespace UnitTesting
{
    [TestClass]
    public class LoadTest
    {
        [TestMethod]
        public void GenericConfigLoadFromPathTest()
        {
            var path = Environment.CurrentDirectory;

            var config = SimpleConfigLoader.Load.FromPath(Path.Combine(path, "TestData", "generic-config.json"));

            Assert.IsNotNull(config);
            
            Assert.IsTrue(config.ContainsKey("DbConnectionString"));
            Assert.AreEqual("FOO", config.GetValue<string>("DbConnectionString"));

            Assert.IsTrue(config.ContainsKey("MailServer"));
            Assert.AreEqual("BAR", config.GetValue<string>("MailServer"));

            Assert.IsTrue(config.ContainsKey("MailServerPort"));
            Assert.AreEqual(1234, config.GetValue<int>("MailServerPort"));

            Assert.IsTrue(config.ContainsKey("NoReplyPassword"));
            Assert.AreEqual("Something", config.GetValue<string>("NoReplyPassword"));

            Assert.IsTrue(config.ContainsKey("ListOfStrings"));
            Assert.AreEqual(3, config.GetValue<IEnumerable<string>>("ListOfStrings").Count());
            Assert.AreEqual(1, config.GetValue<IEnumerable<string>>("ListOfStrings").Where(x => x == "a").Count());
            Assert.AreEqual(1, config.GetValue<IEnumerable<string>>("ListOfStrings").Where(x => x == "b").Count());
            Assert.AreEqual(1, config.GetValue<IEnumerable<string>>("ListOfStrings").Where(x => x == "c").Count());

            Assert.IsTrue(config.ContainsKey("ObjectOfStrings"));
            Assert.AreEqual("Bar", config.GetValue<TestClass>("ObjectOfStrings").Foo);

            Assert.IsNotNull(SimpleConfigLoader.ActiveConfiguration.Generic);
        }
        
        [TestMethod]
        public void GenericConfigLoadFromRootTest()
        {
            var config = SimpleConfigLoader.Load.FromRoot("root-generic-config.json");

            Assert.IsNotNull(config);

            Assert.IsTrue(config.ContainsKey("DbConnectionString"));
            Assert.AreEqual("FOO", config.GetValue<string>("DbConnectionString"));

            Assert.IsTrue(config.ContainsKey("MailServer"));
            Assert.AreEqual("BAR", config.GetValue<string>("MailServer"));

            Assert.IsTrue(config.ContainsKey("MailServerPort"));
            Assert.AreEqual(1234, config.GetValue<int>("MailServerPort"));

            Assert.IsTrue(config.ContainsKey("NoReplyPassword"));
            Assert.AreEqual("Something", config.GetValue<string>("NoReplyPassword"));

            Assert.IsTrue(config.ContainsKey("ListOfStrings"));
            Assert.AreEqual(3, config.GetValue<IEnumerable<string>>("ListOfStrings").Count());
            Assert.AreEqual(1, config.GetValue<IEnumerable<string>>("ListOfStrings").Where(x => x == "a").Count());
            Assert.AreEqual(1, config.GetValue<IEnumerable<string>>("ListOfStrings").Where(x => x == "b").Count());
            Assert.AreEqual(1, config.GetValue<IEnumerable<string>>("ListOfStrings").Where(x => x == "c").Count());

            Assert.IsTrue(config.ContainsKey("ObjectOfStrings"));
            Assert.AreEqual("Bar", config.GetValue<TestClass>("ObjectOfStrings").Foo);

            Assert.IsNotNull(SimpleConfigLoader.ActiveConfiguration.Generic);
        }

        [TestMethod]
        public void SpecificConfigLoadFromPathTest()
        {
            var path = Environment.CurrentDirectory;

            var config = SimpleConfigLoader.Load.FromPath<TestSpecificConfig>(Path.Combine(path, "TestData", "specific-config.json"));

            Assert.IsNotNull(config);

            Assert.AreEqual("Bar", config.FooStr);
            Assert.AreEqual(1234, config.FooInt);

            Assert.AreEqual(3, config.FooList.Count());
            Assert.AreEqual(1, config.FooList.Where(x => x == "a").Count());
            Assert.AreEqual(1, config.FooList.Where(x => x == "b").Count());
            Assert.AreEqual(1, config.FooList.Where(x => x == "c").Count());

            Assert.AreEqual("Bar", config.FooObj.Foo);

            Assert.IsNotNull(SimpleConfigLoader.ActiveConfiguration.Specific);
        }

        [TestMethod]
        public void SpecificConfigLoadFromRootTest()
        {
            var config = SimpleConfigLoader.Load.FromRoot<TestSpecificConfig>("root-specific-config.json");

            Assert.IsNotNull(config);

            Assert.AreEqual("Bar", config.FooStr);
            Assert.AreEqual(1234, config.FooInt);

            Assert.AreEqual(3, config.FooList.Count());
            Assert.AreEqual(1, config.FooList.Where(x => x == "a").Count());
            Assert.AreEqual(1, config.FooList.Where(x => x == "b").Count());
            Assert.AreEqual(1, config.FooList.Where(x => x == "c").Count());

            Assert.AreEqual("Bar", config.FooObj.Foo);

            Assert.IsNotNull(SimpleConfigLoader.ActiveConfiguration.Specific);
        }


        private class TestSpecificConfig
        {
            public string? FooStr { get; set; }
            public int? FooInt { get; set; }
            public List<string>? FooList { get; set; }
            public TestClass? FooObj { get; set; }
        }

        private class TestClass
        {
            public string? Foo { get; set; }
        }
    }
}
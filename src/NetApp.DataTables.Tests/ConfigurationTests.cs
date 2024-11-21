//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Linq;
//using NetApp.DataTables;
//using NetApp.DataTables.Core;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.AspNetCore.Mvc.ModelBinding;
//using Microsoft.Extensions.Options;

//namespace NetApp.DataTables.Tests
//{
//    [TestClass]
//    public class ConfigurationTestsTest
//    {
//        [TestMethod]
//        public void TestDefaultRegistration()
//        {
//            // Arrange
//            var serviceCollection = new ServiceCollection();
//            Configuration.RegisterDataTables(serviceCollection);
//            serviceCollection.AddMvc();
//            var provider = serviceCollection.BuildServiceProvider();
//            var modelBinder = provider.GetServices<IModelBinder>().FirstOrDefault();


//            // Assert
//            Assert.IsNotNull(modelBinder);
//            Assert.IsNotNull(modelBinder as ModelBinder);
//            Assert.IsNull((modelBinder as ModelBinder).ParseAdditionalParameters);
//        }

//        [TestMethod]
//        public void TestRegistrationWithCustomOptions()
//        {
//            // Arrange
//            var options = TestHelper.MockOptions().UseHungarianNotation();
//            var serviceCollection = new ServiceCollection();

//            // Act
//            Configuration.RegisterDataTables(serviceCollection, options);

//            // Assert
//            Assert.AreEqual(options, Configuration.Options);
//        }

//        [TestMethod]
//        public void TestRegistrationWithCustomBinder()
//        {
//            // Arrange
//            var requestBinder = TestHelper.MockModelBinder();
//            var serviceCollection = new ServiceCollection();

//            // Act
//            Configuration.RegisterDataTables(serviceCollection, requestBinder);
//            serviceCollection.AddMvc();
//            var provider = serviceCollection.BuildServiceProvider();
//            var modelBinder = provider.GetServices<IModelBinder>().FirstOrDefault();

//            // Assert
//            Assert.AreEqual(requestBinder, modelBinder);
//        }

//        [TestMethod]
//        public void TestRegistrationWithParseAdditionalParameters()
//        {
//            // Arrange
//            var serviceCollection = new ServiceCollection();

//            // Act
//            Configuration.RegisterDataTables(serviceCollection, TestHelper.ParseAdditionalParameters, true);
//            serviceCollection.AddMvc();
//            var provider = serviceCollection.BuildServiceProvider();
//            var modelBinder = provider.GetServices<IModelBinder>().FirstOrDefault();

//            // Assert
//            Assert.IsTrue(Configuration.Options.IsRequestAdditionalParametersEnabled);
//            Assert.IsTrue(Configuration.Options.IsResponseAdditionalParametersEnabled);
//            Assert.IsNotNull((modelBinder as ModelBinder).ParseAdditionalParameters);
//        }
//    }
//}
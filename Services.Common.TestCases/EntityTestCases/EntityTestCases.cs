using Services.Common.Entity;
using Services.Common.Logging.CloudWatch;
using Xunit;

namespace Services.Common.TestCases.EntityTestCases
{
    public class EntityTestCases
    {
        [Fact]
        public void FileDetailsEntityGetSetPropertyTests()
        {
            var model = new FileDetailsEntity();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        [Fact]
        public void CloudWatchConfigurationGetSetPropertyTests()
        {
            var model = new CloudWatchConfiguration();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        [Fact]
        public void SinksConfigurationGetSetPropertyTests()
        {
            var model = new SinksConfiguration();
            var resultGet = GetModelTestData(model);
            var resultSet = SetModelTestData(model);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        /// <summary>
        /// Gets the model test data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="newModel">The new model.</param>
        /// <returns></returns>
        private T GetModelTestData<T>(T newModel)
        {
            var type = newModel.GetType();
            var properties = type.GetProperties();
            foreach (var prop in properties)
            {
                var propTypeInfo = type.GetProperty(prop.Name.Trim());
                if (propTypeInfo != null && propTypeInfo.CanRead)
                    prop.GetValue(newModel);
            }
            return newModel;
        }

        /// <summary>
        /// Sets the model test data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="newModel">The new model.</param>
        /// <returns></returns>
        private T SetModelTestData<T>(T newModel)
        {
            var type = newModel.GetType();
            var properties = type.GetProperties();
            foreach (var prop in properties)
            {
                var propTypeInfo = type.GetProperty(prop.Name.Trim());

                if (propTypeInfo != null && propTypeInfo.CanWrite)
                {
                    prop.SetValue(newModel, prop.PropertyType.Name == "String" ? string.Empty : null);
                }
            }
            return newModel;
        }
    }
}

using Services.ElasticSearch.Entity;
using Xunit;

namespace Services.ElasticSearch.TestCases.EntityTestCases
{
    public class EntityTestCases
    {
        [Fact]
        public void ElasticAdvancedSearchEntityGetSetPropertyTests()
        {
            var entity = new ElasticAdvancedSearchEntity();
            var resultGet = GetModelTestData(entity);
            var resultSet = SetModelTestData(entity);
            Assert.NotNull(resultGet);
            Assert.NotNull(resultSet);
        }

        [Fact]
        public void ElasticGlobalSearchEntityGetSetPropertyTests()
        {
            var entity = new ElasticGlobalSearchEntity();
            var resultGet = GetModelTestData(entity);
            var resultSet = SetModelTestData(entity);
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

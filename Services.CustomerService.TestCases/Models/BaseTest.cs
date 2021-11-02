namespace Services.CustomerService.TestCases.Models
{
    public class BaseTest
    {
        /// <summary>
        /// Gets the model test data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="newModel">The new model.</param>
        /// <returns></returns>
        protected T GetModelTestData<T>(T newModel)
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
        protected T SetModelTestData<T>(T newModel)
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

using System.Reflection;

namespace BookStoreApi.ViewModels.Helpers
{
    public static class PropertyUtil
    {
        public static T CopyProperties<T, T2>(this T targerObject, T2 sourceObject)
        {
            foreach (var property in typeof(T).GetProperties().Where(p => p.CanWrite))
            {
                Func<PropertyInfo, bool> ChecckIfPropertyExistInSource =
                    prop => string.Equals(property.Name, prop.Name, StringComparison.InvariantCultureIgnoreCase)
                    && prop.PropertyType.Equals(property.PropertyType);

                if (sourceObject.GetType().GetProperties().Any(ChecckIfPropertyExistInSource))
                {
                    property.SetValue(targerObject, sourceObject.GetPropertyValue(property.Name), null);
                }
            }

            return targerObject;
        }

        private static object GetPropertyValue<T>(this T source, string propertyName)
        {
            return source.GetType().GetProperty(propertyName).GetValue(source, null);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Hotel.Core.Extensions
{
    public static class DbContextExtension
    {
        public static List<PropertyInfo> GetDbSetProperties(this DbContext dbContext, Type[] typesProperty) // if (gggg1[0].IsSubclassOf(typeof(BaseEntity)))
        {
            Type bdType = dbContext.GetType();
            PropertyInfo[] properties = bdType.GetProperties();
            List<PropertyInfo> result = new();
            foreach (PropertyInfo property in properties)
            {
                Type propertyType = property.PropertyType;
                if (propertyType.IsGenericType == true)
                {
                    if (propertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                    {
                        Type[] genericArguments = propertyType.GetGenericArguments();
                        if (genericArguments.SequenceEqual(typesProperty) == true)
                        {
                            result.Add(property);
                        }
                    }
                }
            }
            return result;
        }
    }
}
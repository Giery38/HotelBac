using HotChocolate.Types;
using System.Linq.Expressions;

namespace Hotel.API.GraphQL.Extensions
{
    public static class IObjectTypeDescriptorExtension 
    {
        public static IObjectTypeDescriptor<T> Name<T>(this IObjectTypeDescriptor<T> descriptor, Expression<Func<T, string>> expression) // требует дополнительных проверок 
        {
            ConstantExpression body = expression.Body as ConstantExpression;
            if (body is null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            descriptor.Name(body.Value.ToString());
            return descriptor;
        }
               
    }
}

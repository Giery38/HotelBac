using System.Linq.Expressions;

namespace Hotel.API.GraphQL.Extensions
{
    public static class IObjectFieldDescriptorExtension
    {
        public static IObjectFieldDescriptor Name<T>(this IObjectFieldDescriptor descriptor, Expression<Func<T, string>> expression)
        {
            ConstantExpression body = expression.Body as ConstantExpression;
            if (body is null)
            {
                throw new ArgumentNullException(nameof(expression));
            }
            string name = body.Value.ToString();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            descriptor.Name(name);
            return descriptor;
        }      
    }
}

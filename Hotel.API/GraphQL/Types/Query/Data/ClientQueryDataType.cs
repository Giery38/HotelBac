using HotChocolate.Language;
using HotChocolate.Types.Descriptors;
using Hotel.API.GraphQL.Queries.Data;
using Hotel.API.GraphQL.Queries.Data.Attributes;
using Hotel.API.GraphQL.Types.Models.Input;
using Hotel.Data.Models;
using Hotel.Data.Models.Users.Guests;
using System.Reflection;

namespace Hotel.API.GraphQL.Types.Query.Data
{
    public class ClientQueryDataType : ObjectType<QueryData>
    {
        protected override void Configure(IObjectTypeDescriptor<QueryData> descriptor)
        {
            base.Configure(descriptor);
            Type type = typeof(QueryData);            
            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            foreach (MethodInfo method in methods)
            {
                AddAttribute? addAttribute = method.GetCustomAttribute<AddAttribute>();               
                if (addAttribute != null)
                {
                    ParameterInfo[] parametrs = method.GetParameters();
                    ParameterInfo? argument = parametrs.FirstOrDefault(p => p.Name == "item");
                    if (argument == null)
                    {
                        throw new Exception(@"Argument ""item"" not found");
                    }                    
                    Type inputClientType = typeof(InputClientType<>).MakeGenericType(argument.ParameterType);
                    Type nonNullType = typeof(NonNullType<>).MakeGenericType(inputClientType);
                    descriptor.Field(method).Argument("item", a => a.Type(nonNullType));
                }
            }           
        }
    }
}

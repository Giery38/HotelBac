namespace Hotel.API.GraphQL.Types.Models.Input.Common
{
    public class BaseInputObjectType<T> : InputObjectType<T>
        where T : class
    {
        protected override void Configure(IInputObjectTypeDescriptor<T> descriptor)
        {
            Type inputType = GetType();
            Type ginericType = typeof(T);
            string name = inputType.Name.Substring(0, inputType.Name.Length - 2) + $"Of{ginericType.Name}";
            descriptor.Name(name);
            base.Configure(descriptor);
        }
    }
}

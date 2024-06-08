using HotChocolate.Language;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using Hotel.API.GraphQL.Types.Models.Input.Client;
using Hotel.Data.Models;
using Hotel.Data.Models.Users.Guests;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;
using System.Reflection;

namespace Hotel.API.GraphQL.Types.Models.Input.Common
{
    public class BaseInputObjectType<T> : InputObjectType<T>
        where T : class
    {
        public bool IsList { get; protected set; }
        protected Expression<Func<T, object>>[] ignorFields;
        protected List<(Expression<Func<T, object>>[] fields, Type newType)> typedFields;
        protected List<(Expression<Func<T, object>>[] fields, IInputType newType, bool isListType)> typedInputFields;
        public BaseInputObjectType()
        {
            typedFields = new List<(Expression<Func<T, object>>[] fields, Type newType)>();
            typedInputFields = new List<(Expression<Func<T, object>>[] fields, IInputType newType, bool isListType)>();
        }
        private readonly string additionalName;
        public BaseInputObjectType(string additionalName)
        {
            this.additionalName = additionalName;
            typedFields = new List<(Expression<Func<T, object>>[] fields, Type newType)>();
            typedInputFields = new List<(Expression<Func<T, object>>[] fields, IInputType newType, bool isListType)>();
        }
        public BaseInputObjectType<T> SetIgnorFields(params Expression<Func<T, object>>[] ignorFields)
        {
            this.ignorFields = ignorFields;
            return this;
        }
        public BaseInputObjectType<T> SetTypeFields<TType>(params Expression<Func<T, object>>[] field)
        {
            typedFields.Add((field, typeof(TType)));
            return this;
        }
        public BaseInputObjectType<T> SetTypeFields(Type newType, params Expression<Func<T, object>>[] field)
        {
            typedFields.Add((field, newType));
            return this;
        }
        public BaseInputObjectType<T> SetTypeFields(IInputType inputType, bool isListType, params Expression<Func<T, object>>[] field)
        {
            typedInputFields.Add((field, inputType, isListType));
            return this;
        }
        protected override void Configure(IInputObjectTypeDescriptor<T> descriptor)
        {
            Type inputType = GetType();
            Type ginericType = typeof(T);
            string name = inputType.Name.Substring(0, inputType.Name.Length - 2) + $"Of{ginericType.Name}";
            if (additionalName != null)
            {
                name = name += additionalName;
            }
            descriptor.Name(name);
            if (ignorFields != null)
            {
                foreach (Expression<Func<T, object>> item in ignorFields)
                {
                    descriptor.Field(item).Ignore();
                }
            }
            foreach (var item in typedFields)
            {
                foreach (var field in item.fields)
                {
                    descriptor.Field(field).Type(item.newType);
                }
            }
            foreach (var item in typedInputFields)
            {
                foreach (var field in item.fields)
                {
                    IInputType result = item.newType;
                    if (item.isListType == true)
                    {
                        result = new ListType(item.newType);
                    }
                    descriptor.Field(field).Type(result);
                }
            }
            base.Configure(descriptor);
        }
    }   
}
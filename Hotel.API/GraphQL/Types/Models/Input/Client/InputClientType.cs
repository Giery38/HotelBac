using HotChocolate.Configuration;
using HotChocolate.Types.Descriptors;
using HotChocolate.Types.Relay;
using Hotel.API.GraphQL.Types.Models.Input.Common;
using Hotel.Data.Models;
using Hotel.Data.Models.Users.Guests;
using System;
using System.Linq.Expressions;

namespace Hotel.API.GraphQL.Types.Models.Input.Client
{
    public class InputClientType<TEntity> : BaseInputObjectType<TEntity>
       where TEntity : Entity
    {
        protected override void Configure(IInputObjectTypeDescriptor<TEntity> descriptor)
        {
            descriptor.Field(f => f.Id).Ignore();
            base.Configure(descriptor);
        }
    }    
}

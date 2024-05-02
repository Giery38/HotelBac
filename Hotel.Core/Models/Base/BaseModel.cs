using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Models.Base
{
    public abstract class BaseModel : IModel
    {
        public Guid Id { get; private set; }             
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Models.Common
{
    public abstract class Model : IModel
    {
        public Guid Id { get; private set; }             
    }
}

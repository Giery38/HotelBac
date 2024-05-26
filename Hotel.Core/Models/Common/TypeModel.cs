using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Models.Common
{
    public abstract class TypeModel : Model
    {
        public string Name { get; private set; } = string.Empty;
        protected TypeModel(Guid id, string name) : base(id)
        {
            Name = name;
        }
    }
}

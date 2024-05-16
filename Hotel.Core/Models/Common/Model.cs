﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Models.Common
{
    public class Model : IModel
    {     
        public Guid Id { get; private set; }
        public Model(Guid id)
        {
            Id = id;
        }

    }
}

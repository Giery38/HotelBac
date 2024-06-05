using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Services.Data
{
    class A
    {

    }
    class B
    {

    }
    public class Test
    {
        public Test() {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg => cfg.CreateMap<A,B>());
        }

    }
}

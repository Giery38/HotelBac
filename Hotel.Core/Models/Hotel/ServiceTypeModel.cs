using Hotel.Core.Models.Common;

namespace Hotel.Core.Models.Hotel
{
    public class ServiceTypeModel : TypeModel
    {
        public List<ServiceModel> Services {  get; private set; }
        public ServiceTypeModel(Guid id, string name, List<ServiceModel> services) : base(id, name)
        {
            Services = services;
        }
    }
}
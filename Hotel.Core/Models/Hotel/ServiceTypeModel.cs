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
        public ServiceTypeModel(Guid id, string name) : base(id, name)
        {
            Services = new List<ServiceModel>();
        }
        public void AddService(ServiceModel service)
        {
            Services.Add(service);
        }
    }
}
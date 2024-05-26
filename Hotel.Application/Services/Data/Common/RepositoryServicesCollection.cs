using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Services.Data.Common
{
    public class RepositoryServicesCollection : IList<IRepositoryServiceAsync>, IRepositoryServicesCollection
    {
        private List<IRepositoryServiceAsync> repositoryServices;
        public RepositoryServicesCollection()
        {
            repositoryServices = new List<IRepositoryServiceAsync>();
        }
        public IRepositoryServiceAsync this[int index]
        {
            get => repositoryServices[index];
            set => repositoryServices[index] = value;
        }

        public int Count => repositoryServices.Count;

        public bool IsReadOnly => false;

        public void Add(IRepositoryServiceAsync item)
        {
            repositoryServices.Add(item);
        }

        public void Clear()
        {
            repositoryServices.Clear();
        }

        public bool Contains(IRepositoryServiceAsync item)
        {
            return repositoryServices.Contains(item);
        }

        public void CopyTo(IRepositoryServiceAsync[] array, int arrayIndex)
        {
            repositoryServices.CopyTo(array, arrayIndex);
        }

        public IEnumerator<IRepositoryServiceAsync> GetEnumerator()
        {
            return repositoryServices.GetEnumerator();
        }

        public int IndexOf(IRepositoryServiceAsync item)
        {
            return repositoryServices.IndexOf(item);
        }

        public void Insert(int index, IRepositoryServiceAsync item)
        {
            repositoryServices.Insert(index, item);
        }

        public bool Remove(IRepositoryServiceAsync item)
        {
            return repositoryServices.Remove(item);
        }

        public void RemoveAt(int index)
        {
            repositoryServices.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return repositoryServices.GetEnumerator();
        }
    }
}

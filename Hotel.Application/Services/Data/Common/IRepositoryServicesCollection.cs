
namespace Hotel.Application.Services.Data.Common
{
    public interface IRepositoryServicesCollection
    {
        IRepositoryServiceAsync this[int index] { get; set; }

        int Count { get; }
        bool IsReadOnly { get; }

        void Add(IRepositoryServiceAsync item);
        void Clear();
        bool Contains(IRepositoryServiceAsync item);
        void CopyTo(IRepositoryServiceAsync[] array, int arrayIndex);
        IEnumerator<IRepositoryServiceAsync> GetEnumerator();
        int IndexOf(IRepositoryServiceAsync item);
        void Insert(int index, IRepositoryServiceAsync item);
        bool Remove(IRepositoryServiceAsync item);
        void RemoveAt(int index);
    }
}
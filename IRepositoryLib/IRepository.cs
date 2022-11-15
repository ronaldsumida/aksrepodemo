namespace IRepositoryLib
{
    public interface IRepository<T, U> : IDisposable
    {
        IEnumerable<T>? Get();
        T? GetById(U id);
        void Add(T item);
        bool Update(U id, T item);
        T? Delete(U id);
    }
}
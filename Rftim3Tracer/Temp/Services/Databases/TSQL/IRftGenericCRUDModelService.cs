namespace Rftim3Tracer.Temp.Services.Databases.TSQL
{
    public interface IRftGenericCRUDModelService<T>
    {
        Task<T> Create(T entity);

        Task<T?> ReadOne(uint id);

        Task<List<T>> ReadAll();

        Task<T> Update(uint id, T entity);

        Task<bool> Delete(uint id);
    }
}

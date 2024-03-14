namespace Common.Interfaces;

public interface IFunctions
{
    void Add<T>(T item) where T : class;

    void Update<T>(T item) where T : class, IEntity;

    void Delete<T>(int id) where T : class, IEntity;

    void ListAll<T>() where T : class;

    void Find<T>(int id) where T : class, IEntity;
}

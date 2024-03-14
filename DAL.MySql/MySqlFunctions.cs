using Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.MySql;

public class MySqlFunctions : IFunctions
{
    public void Add<T>(T item) where T : class
    {
        using var context = new MySqlContext();
        var dbSet = context.Set<T>();

        dbSet.Add(item);
        context.SaveChanges();
    }

    public void Update<T>(T item) where T : class, IEntity
    {
        using var context = new MySqlContext();
        var dbSet = context.Set<T>();
        var itemFound = dbSet.FirstOrDefault(ifo => ifo.Id == item.Id);

        if (itemFound != null)
        {
            context.Entry(itemFound).CurrentValues.SetValues(item);
            context.SaveChanges();
        }
    }

    public void Delete<T>(int id) where T : class, IEntity
    {
        using var context = new MySqlContext();
        var dbSet = context.Set<T>();
        var itemFound = dbSet.FirstOrDefault(ifo => ifo.Id == id);

        if (itemFound != null)
        {
            dbSet.Remove(itemFound);
            context.SaveChanges();
        }
    }

    public void ListAll<T>() where T : class
    {
        using var context = new MySqlContext();
        var dbSet = context.Set<T>().AsNoTracking();

        dbSet.ToList().ForEach(i =>
            Console.WriteLine(i));
    }

    public void Find<T>(int id) where T : class, IEntity
    {
        using var context = new MySqlContext();
        var dbSet = context.Set<T>().AsNoTracking();
        string itemFound = dbSet.FirstOrDefault(i => i.Id == id)?.ToString() ?? "Item não encontrado";

        Console.WriteLine(itemFound);
    }
}

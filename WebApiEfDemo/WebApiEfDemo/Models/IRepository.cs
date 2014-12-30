using Breeze.ContextProvider;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
namespace WebApiEfDemo.Models
{
    public interface IRepository
    {
        string MetaData { get; }
        SaveResult SaveChanges(JObject saveBundle);

        IQueryable<Book> Books();
        IQueryable<Order> Orders();
    }
}

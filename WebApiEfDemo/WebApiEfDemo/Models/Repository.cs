using Breeze.ContextProvider.EF6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiEfDemo.Models
{
    public class Repository : WebApiEfDemo.Models.IRepository
    {
        private readonly EFContextProvider<WebApiEfDemoContext> _contextProvider = new EFContextProvider<WebApiEfDemoContext>();

        public string MetaData
        {
            get { return _contextProvider.Metadata(); }
        }

        public Breeze.ContextProvider.SaveResult SaveChanges(Newtonsoft.Json.Linq.JObject saveBundle)
        {
            return _contextProvider.SaveChanges(saveBundle);
        }

        public IQueryable<Book> Books()
        {
            return _contextProvider.Context.Books;
        }

        public IQueryable<Order> Orders()
        {
            return _contextProvider.Context.Orders;
        }
    }
}
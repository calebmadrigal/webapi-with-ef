using System;
namespace WebApiEfDemo.Models
{
    interface IRepository
    {
        System.Linq.IQueryable<Order> GetAllOrders();
        System.Linq.IQueryable<Order> GetAllOrdersWithDetails();
        Order GetOrder(int id);
    }
}

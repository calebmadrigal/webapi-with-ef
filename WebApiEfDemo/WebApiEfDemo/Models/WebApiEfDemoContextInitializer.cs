using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApiEfDemo.Models
{
    public class WebApiEfDemoContextInitializer : DropCreateDatabaseAlways<WebApiEfDemoContext>
    {
        protected override void Seed(WebApiEfDemoContext context)
        {
            var books = new List<Book>
            {
                new Book() {Name = "Phantastes", Author = "George MacDonald", Price = 4.00m},
                new Book() {Name = "Ulysses", Author = "James Joyce", Price = 89.99m},
                new Book() {Name = "Lilith", Author = "George MacDonald", Price = 4.00m},
                new Book() {Name = "The Picture of Dorian Gray", Author = "Oscar Wilde", Price = 12.99m},
                new Book() {Name = "I, Robot", Author = "Isaac Asimov", Price = 7.99m},
                new Book() {Name = "Blue Like Jazz", Author = "Donald Miller", Price = 8.00m}
            };

            books.ForEach(b => context.Books.Add(b));
            context.SaveChanges();

            var order = new Order()
            {
                Customer = "Caleb Madrigal",
                OrderDate = new DateTime(2014,12,29)
            };
            var details = new List<OrderDetail>()
            {
                new OrderDetail() { Book = books[0], Quantity = 1, Order = order},
                new OrderDetail() { Book = books[1], Quantity = 2, Order = order},
                new OrderDetail() { Book = books[2], Quantity = 3, Order = order}
            };

            context.Orders.Add(order);
            details.ForEach(d => context.OrderDetails.Add(d));
            context.SaveChanges();

            order = new Order()
            {
                Customer = "Whitney Madrigal",
                OrderDate = new DateTime(2015, 01, 01)
            };
            details = new List<OrderDetail>()
            {
                new OrderDetail() { Book = books[1], Quantity = 1, Order = order},
                new OrderDetail() { Book = books[1], Quantity = 1, Order = order},
                new OrderDetail() { Book = books[3], Quantity = 5, Order = order}
            };

            context.Orders.Add(order);
            details.ForEach(d => context.OrderDetails.Add(d));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
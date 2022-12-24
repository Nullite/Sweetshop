using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop.Model
{
    internal class UsersDB
    {
        private static UsersDB _context;
        private UsersDB()
        {
            Orders = new ObservableCollection<Order>()
            {
                new Order()
                {
                    Client = "Игорь", ID = 1, Date = new DateTime(2022, 12, 10),
                    Products = new ObservableCollection<OrderProduct>()
                    {
                        new OrderProduct() {Product = Products.First(x => x.ID == 1), Quantity = 1},
                        new OrderProduct() {Product = Products.First(x => x.ID == 4), Quantity = 1},
                        new OrderProduct() {Product = Products.First(x => x.ID == 8), Quantity = 3},
                    }
                },
                new Order()
                {
                    Client = "Вася", ID = 2, Date = new DateTime(2022, 10, 11),
                    Products = new ObservableCollection<OrderProduct>()
                    {
                        new OrderProduct() {Product = Products.First(x => x.ID == 2), Quantity = 2},
                        new OrderProduct() {Product = Products.First(x => x.ID == 3), Quantity = 1},
                        new OrderProduct() {Product = Products.First(x => x.ID == 6), Quantity = 1},
                    }
                },
                new Order()
                {
                    Client = "Петя", ID = 3, Date = new DateTime(2022, 11, 11),
                    Products = new ObservableCollection<OrderProduct>()
                    {
                        new OrderProduct() {Product = Products.First(x => x.ID == 1), Quantity = 2},
                        new OrderProduct() {Product = Products.First(x => x.ID == 5), Quantity = 2},
                    }
                },
                new Order()
                {
                    Client = "Маша", ID = 4, Date = new DateTime(2022, 11, 10),
                    Products = new ObservableCollection<OrderProduct>()
                    {
                        new OrderProduct() {Product = Products.First(x => x.ID == 4), Quantity = 1},
                        new OrderProduct() {Product = Products.First(x => x.ID == 6), Quantity = 1},
                    }
                },
                new Order()
                {
                    Client = "Юля", ID = 5, Date = new DateTime(2022, 12, 10),
                    Products = new ObservableCollection<OrderProduct>()
                    {
                        new OrderProduct() {Product = Products.First(x => x.ID == 5), Quantity = 4},
                    }
                },
            };
            Folders = new List<Folder>()
            {
                new Folder 
                {
                    Name = "Шоколад", 
                    nodes= new List<INode>() 
                    {
                        new Folder 
                        {
                            Name = "Подпапка", 
                            nodes = new List<INode>()
                            {
                                new ProductNode(Products.First(p=> p.ID == 8)),
                                new ProductNode(Products.First(p => p.ID == 9)) 
                            } 
                        }
                    }
                },
                new Folder
                {
                    Name = "Напитки", 
                    nodes= new List<INode>()
                    {
                        new Folder
                        {
                            Name = "Подпапка", 
                            nodes = new List<INode>()
                            {
                                new ProductNode(Products.First(p=> p.ID == 3)),
                                new ProductNode(Products.First(p => p.ID == 4)),
                                new ProductNode(Products.First(p =>p.ID == 5))
                            }
                        }
                    }
                },
                new Folder
                {
                    Name = "Торты", 
                    nodes= new List<INode>()
                    {
                        new Folder
                        {
                            Name = "Подпапка", 
                            nodes = new List<INode>()
                            {
                                new ProductNode(Products.First(p=> p.ID == 2)),
                                new ProductNode(Products.First(p => p.ID == 7))
                            }
                        }
                    }
                },
                new Folder
                {
                    Name = "Пирожные", 
                    nodes= new List<INode>()
                    {
                        new Folder 
                        {
                            Name = "Подпапка", 
                            nodes = new List<INode>()
                            {
                                new ProductNode(Products.First(p=> p.ID == 1)),
                                new ProductNode(Products.First(p => p.ID == 6))
                            }
                        }
                    }
                }
            };
        }
        public static UsersDB Context => _context ?? (_context = new UsersDB());
        public ObservableCollection<Order> Orders { get; set; }
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>()
        {
            new User ("Anonimus","12345","anon"),
            new User ("User","uSeR","user"),
            new User ("Null","password","login"),
            new User ("Human","102030","hum"),
            new User ("Vasja","gop","stop"),
        };
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>()
        {
            new Product() {ID = 1, Name = "Пирожное Полет", Price = 100M},
            new Product() {ID = 2, Name = "Торт Наполеон", Price = 600M},
            new Product() {ID = 3, Name = "Капуччино", Price = 75M},
            new Product() {ID = 4, Name = "Латте", Price = 75M},
            new Product() {ID = 5, Name = "Чай", Price = 60M},
            new Product() {ID = 6, Name = "Эклер", Price = 110M},
            new Product() {ID = 7, Name = "Вафельный торт", Price = 350M},
            new Product() {ID = 8, Name = "Шоколад темный", Price = 150M},
            new Product() {ID = 9, Name = "Шоколад белый", Price = 120M},
        };
        public List<Folder> Folders { get; set; }
        
    }
}

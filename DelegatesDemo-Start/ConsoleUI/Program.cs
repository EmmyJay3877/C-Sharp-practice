﻿using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static ShoppingCartModel cart = new ShoppingCartModel();

        static void Main(string[] args)
        {
            PopulateCartWithDemoData();

            Console.WriteLine($"The total for the cart is {cart.GenerateTotal(ReturnDiscount, CalculateDiscount, DisplayDiscountAction):C2}");

            Console.WriteLine();

            //writing the delgate functions directly in to the method.
            decimal total = cart.GenerateTotal((subTotal) => Console.WriteLine($"The subtotal for cart2 is {subTotal:C2}"),
                (products, subTotal) =>
                {
                    if (products.Count > 3)
                    {
                        return subTotal * 0.5M;
                    }
                    else return subTotal;
                },
                (message) => Console.WriteLine(message)
                );

            Console.WriteLine($"The total for cart2 is {total:C2}");

            Console.WriteLine();
            Console.Write("Please press any key to exit the application...");
            Console.ReadKey();
        }

        private static void DisplayDiscountAction(string message)
        {
            Console.WriteLine(message);
        }

        private static decimal CalculateDiscount(List<ProductModel> items, decimal subTotal)
        {
            if (subTotal > 100)
            {
                return subTotal * 0.80M;
            }
            else if (subTotal > 50)
            {
                return subTotal * 0.85M;
            }
            else if (subTotal > 10)
            {
                return subTotal * 0.90M;
            }
            else return subTotal;
        }

        private static void ReturnDiscount(decimal subTotal)
        {
            Console.WriteLine($"The subtotal is {subTotal:C2}");
        }

        private static void PopulateCartWithDemoData()
        {
            cart.Items.Add(new ProductModel { ItemName = "Cereal", Price = 3.63M });
            cart.Items.Add(new ProductModel { ItemName = "Milk", Price = 2.95M });
            cart.Items.Add(new ProductModel { ItemName = "Strawberries", Price = 7.51M });
            cart.Items.Add(new ProductModel { ItemName = "Blueberries", Price = 8.84M });
        }
    }
}

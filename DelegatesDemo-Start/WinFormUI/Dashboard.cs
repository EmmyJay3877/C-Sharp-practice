using DemoLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormUI
{
    public partial class Dashboard : Form
    {
        ShoppingCartModel cart = new ShoppingCartModel();

        public Dashboard()
        {
            InitializeComponent();
            PopulateCartWithDemoData();
        }

        private void PopulateCartWithDemoData()
        {
            cart.Items.Add(new ProductModel { ItemName = "Cereal", Price = 3.63M });
            cart.Items.Add(new ProductModel { ItemName = "Milk", Price = 2.95M });
            cart.Items.Add(new ProductModel { ItemName = "Strawberries", Price = 7.51M });
            cart.Items.Add(new ProductModel { ItemName = "Blueberries", Price = 8.84M });
        }

        private void messageBoxDemoButton_Click(object sender, EventArgs e)
        {
            decimal total = cart.GenerateTotal(ShowDiscount, CalculateLeveledDiscount, DisplayDiscountMsg);

            MessageBox.Show($"The total for the cart is {total:C2}");
        }

        private void PrintOutDiscountAlert(string discountMessage)
        {
            MessageBox.Show(discountMessage);
        }

        private void textBoxDemoButton_Click(object sender, EventArgs e)
        {
            decimal total = cart.GenerateTotal((subTotal) => subTotalTextBox.Text = $"{subTotal:C2}",
                (products, subTotal) => subTotal - (products.Count() * 2),
                (message) => { }
                );

            totalTextBox.Text = $"{total:C2}";
        }

        private static void DisplayDiscountMsg(string message)
        {
            MessageBox.Show(message);
        }

        private static decimal CalculateLeveledDiscount(List<ProductModel> products, decimal subTotal)
        {
            return subTotal - products.Count;
        }

        private static void ShowDiscount(decimal subTotal)
        {
            MessageBox.Show($"The subtotal is {subTotal:C2}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class ShoppingCartModel
    {

        public delegate void MentionDiscount(decimal subTotal);

        public List<ProductModel> Items { get; set; } = new List<ProductModel>();

         
        public decimal GenerateTotal(MentionDiscount mentionSubtotal,
            Func<List<ProductModel>, decimal, decimal> calculateSubtotal, 
            Action<string> displayDiscountMsg
            )
        {
            decimal subTotal = Items.Sum(x => x.Price);

            mentionSubtotal(subTotal);

            displayDiscountMsg("We are applying discount right now!");

            return calculateSubtotal(Items, subTotal);
        }
    }
}

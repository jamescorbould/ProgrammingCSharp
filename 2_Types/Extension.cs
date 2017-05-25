using System;

namespace _2_Types
{
    public class Product
    {
        public decimal Price { get; set; }
    }

    public static class MyExtensions
    {
        public static decimal Discount(this Product product)
        {
            return product.Price * 0.9M;
        }
    }

    public class Calculator
    {
        public decimal CalculateDiscount(Product p)
        {
            return p.Discount();
        }
    }
}

using System;

namespace _2_CreateTypes
{
    public class Product
    {
        public decimal Price { get; set; }
    }

    public static class MyExtensions  // Static class.
    {
        // Static method.  Use of this keyword in method parameter.  Extension method for the Product class.
        public static decimal Discount(this Product product) => product.Price * 0.9M;
    }

    public class Calculator
    {
        public decimal CalculateDiscount(Product p)
        {
            // Here we are calling a 3rd party extension method on the Product class.
            return p.Discount();
        }
    }

    class Base
    {
        public virtual int MyMethod()
        {
            return 39;
        }
    }

    class Derived : Base
    {
        public sealed override int MyMethod()
        {
            return base.MyMethod() * 2;
        }
    }

    class Derived2 : Derived
    {
        // This line gives a compiler error since MyMethod() is declared sealed.
        //public override int MyMethod()
        //{
        //    return 1;
        //}
    }

    class Money
    {
        public decimal Amount { get; set; }

        public Money(decimal amount)
        {
            Amount = amount;
        }

        public static implicit operator decimal(Money money) // no cast required.
        {
            return money.Amount;
        }

        public static explicit operator int(Money money) // cast required.
        {
            return (int)money.Amount;
        }
    }

        // Class for extension methods.
        public static class MyExtensions2  // Static class.
        {
            public static int WordCount(this String str)  // Static method.  Use of this keyword in parameter.
            {
                return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
            }
        }
}

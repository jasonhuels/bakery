using System;
using System.Linq;
using System.Collections.Generic;
using BreadNS;
using PastryNS;

class Program
{
    static void Main()
    {
        string InputString;
        Dictionary<string, int> Cart = new Dictionary<string, int>() { {"bread", 0}, {"pastry", 0} };   
        bool Shopping = true;

        Console.WriteLine("\nWelcome to Pierre's Bakery!\n");
        ShowMenu();
        while(Shopping)
        {
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("[menu, cart, shop, checkout, leave]\n");
            InputString = Console.ReadLine();
            switch(InputString.ToLower())
            {
                case "leave":
                    Console.WriteLine("Thanks for coming to Pierre's Bakery! Goodbye.");
                    Shopping = false;
                    break;
                case "menu":
                    ShowMenu();
                    break;
                case "cart":
                    ShowCart(Cart);
                    break;
                case "shop":
                    Cart = Shop(Cart);
                    break;
                case "checkout":
                    Checkout(Cart);
                    Cart["bread"] = 0;
                    Cart["pastry"] = 0;
                    ShowCart(Cart);
                    break;
                case "steal":
                    Console.WriteLine("Pierre does not take kindly to shoplifters. You are kicked out of the Bakery.");
                    Shopping = false;
                    break;
                default:
                    Console.WriteLine("I don't understand that command.\n");
                    break;
            }           
        }       
    }

    static void ShowMenu()
    {   
        Console.WriteLine("\n*_*_*_*_*_*_*_ Menu _*_*_*_*_*_*_*\n");
        Console.WriteLine("Bread                     Pastries");
        Console.WriteLine("1 for $5                  1 for $2");
        Console.WriteLine("Buy 2 Get 1 Free          3 for $5");
        Console.WriteLine("\n*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*");
        // Console.WriteLine("Bread: 1 Loaf: $5 /// Buy 2 get 1 Free.");
        // Console.WriteLine("Pastries: 1 Pastry: $2 /// 3 Pastries: $5\n");        
    }

    static void ShowCart(Dictionary<string, int> Cart)
    {
        Console.WriteLine("\nYou have {0} bread and {1} pastry in your cart.\n", Cart["bread"], Cart["pastry"]);
    }    

    static Dictionary<string, int> Shop(Dictionary<string, int> Cart)
    {
        string InputString;
        int Quantity;

        for(int i=0; i<Cart.Count; i++)
        {
            Console.WriteLine("How many {0} would you like?", Cart.ElementAt(i).Key);
            InputString = Console.ReadLine();
            
            if(int.TryParse(InputString, out Quantity))
            {
      
                if(Cart[Cart.ElementAt(i).Key] + Quantity > 0)
                {
                    Cart[Cart.ElementAt(i).Key] += Quantity;
                    ShowCart(Cart);
                }
                else if(Cart[Cart.ElementAt(i).Key] + Quantity == 0)
                {
                    Console.WriteLine("Ok, you don't want any {0}.", Cart.ElementAt(i).Key);
                }
                else
                {
                    Console.WriteLine("You can't have a negative amount of {0} in your cart.", Cart.ElementAt(i).Key);
                }
                
            } 
            else
            {
                Console.WriteLine("Quantity must be an integer.");
            }
        }

        return Cart;
    }

    static void Checkout(Dictionary<string, int> Cart)
    {
        int total = 0;
        Bread bread = new Bread();
        Pastry pastry = new Pastry();
        total = bread.GetCost(Cart["bread"]) + pastry.GetCost(Cart["pastry"]);
        Console.WriteLine("Your total for {0} bread and {1} pastry will be ${2}.", Cart["bread"], Cart["pastry"], total);
    }
}
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
        while(Shopping)
        {
            Console.WriteLine("Would you like to do?");
            Console.WriteLine("[menu, cart, shop, checkout, leave]");
            InputString = Console.ReadLine();
            switch(InputString.ToLower())
            {
                case "leave":
                    Shopping = false;
                    break;
                case "menu":
                    PrintMenu();
                    break;
                case "cart":
                    ShowCart(Cart);
                    break;
                case "shop":
                    Cart = Shop(Cart);
                    break;
                case "checkout":
                    break;
                default:
                    Console.WriteLine("I don't understand that command.\n");
                    break;

            }           
        }
        
    }

    static void PrintMenu()
    {   
        Console.WriteLine("\n*_*_*_*_*_*_*_Menu_*_*_*_*_*_*_*");
        Console.WriteLine("Bread: 1 Loaf: $5 /// Buy 2 get 1 Free.");
        Console.WriteLine("Pastries: 1 Pastry: $2 /// 3 Pastries: $5\n");        
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

}
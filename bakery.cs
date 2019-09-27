using System;
using System.Collections.Generic;
using BreadNS;
using PastryNS;

class Program
{
    static void Main()
    {
        
        bool shopping = true;

        Console.WriteLine("\nWelcome to Pierre's Bakery!\n");
        while(shopping)
        {
            Console.WriteLine("Would you like to see our menu? (y/n)");
            ConsoleKey inputKey = Console.ReadKey(true).Key;
            if(inputKey == ConsoleKey.N)
            {
                shopping = false;
                break;
            }
            else if(inputKey == ConsoleKey.Y)
            {
                PrintMenu();
            }
            
           
        }
        
    }

    static void PrintMenu()
    {       
        Console.WriteLine("\n*_*_*_*_*_*_*_Menu_*_*_*_*_*_*_*");
        Console.WriteLine("Bread: 1 Loaf: $5 /// Buy 2 get 1 Free.");
        Console.WriteLine("Pastries: 1 Pastry: $2 /// 3 Pastries: $5");        
    }

    

    static int AddToCart(string itemToAdd)
    {
        int Count = 0;
        string inputString;
        Console.WriteLine("How many {0} would you like?", itemToAdd);
        inputString = Console.ReadLine();
        try
        {
            Count = int.Parse(inputString);
        }
        catch(FormatException)
        {
            Console.WriteLine("That is not a valid quantity ") ;
        }

        return Count;
    }


}
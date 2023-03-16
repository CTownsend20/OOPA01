using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    public class Card
    {
        // Base for the Card class.
        //Value: numbers 1 - 13
        //Suit: numbers 1 - 4
        // The 'set' methods for these properties could have some validation
        
        public int Value { get; set; } 
        public int Suit { get; set; }

        public static void NamingRules() //lets the user know how cards are named
        {
            Console.WriteLine("The format for cards is (number) suit of (number) value");
            Console.WriteLine("E.g. 4 of 13 means the King of Diamonds");
            Console.WriteLine("Values: 1 = Ace, 11 = Jack, 12 = Queen and 13 = King");
            Console.WriteLine("Suits: 1 = Clubs, 2 = Spades, 3 = Hearts and 4 = Diamonds");
        }

    }
    
        
}       
     



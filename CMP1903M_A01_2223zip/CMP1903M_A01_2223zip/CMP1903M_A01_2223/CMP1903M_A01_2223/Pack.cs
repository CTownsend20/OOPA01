using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    public class Pack
    {
        private static List<Card> cards; //base for pack of cards
        private int typeOfShuffle;
        private static int amount;
        private static string[] pack;

        public Pack()
        {
            

            cards = new List<Card>(); //creates a new list for the cards
            int[] suits = { 1, 2, 3, 4 }; // list of suits
            int[] values = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }; //list of values
            foreach (int suit in suits) //loops through all of the suits
            {
                foreach (int value in values) //loops through all of the values
                {
                    cards.Add( new Card { Suit = suit, Value = value });

                   
                   
                }


            }

          //  for (int i = 0; i < cards.Count; i++) // debugging: make sure the Suit and Value are the same!
            //{
              //  Console.WriteLine(cards[i].Suit + " Suit " + cards[i].Value + " value");

               // if (cards[i].Suit == cards[50].Suit)
                //{ 
                  //  if (cards[i].Value == cards[50].Value)
                   // {
                    //    Console.WriteLine("Got Cards!");
                   // }
               // }

            
          //  }

             shuffleCardPack(typeOfShuffle);


        }

        public List<Card> GetCards()
        {   
            Console.WriteLine("Cards: " + cards.Count);
            return cards;
        }
      
        
        public static bool shuffleCardPack(int typeOfShuffle)//Shuffles the pack based on the type of shuffle
        {
            bool pick = true; // keeps the while loop going until shuffle_select is correct
            Console.WriteLine("Select the shuffle you want: 1 = Fisher yates, 2 = Riffle or 3 = No"); //player selection
            while (pick == true)
            {

                String shuffle_select = typeOfShuffle.ToString(); 
                   shuffle_select = Console.ReadLine();
                switch (shuffle_select)
                {
                    case "1":
                        Console.WriteLine("You have selected: Fisher Shuffle");
                        FisherYates(pack); 
                        pick = false;
                        break;
                        
                    case "2":
                        Console.WriteLine("You have selected: Riffle Shuffle");
                        Riffle();
                        pick = false;
                        break;

                    case "3":
                        Console.WriteLine("You have selected: No Shuffle");
                        Noshuffle();
                        pick = false;
                        break;

                    default:
                        Console.WriteLine("Make sure the spelling is correct"); // error handling
                        pick = true;
                        break;
                }

            }
            return true;
        }

        public static void FisherYates(string[] pack)//random card shuffle (needs fixing) 
        {
            Random rnd = new Random();
            for (int i = pack.Length - 1; i > 0; i--) //keeps track of the amount of cards 
            {
                int j = rnd.Next(i + 1); //shuffles the cards
                string temp = pack[i];
                pack[i] = pack[j];
                pack[j] = temp;

            }


            bool pick = true;
            Console.WriteLine("deal a single card (type 1) or certain amount (type 2)"); //player selection
            while (pick == true)
            {

                string cardpick = Console.ReadLine();
                switch (cardpick)
                {
                    case "1":
                        Console.WriteLine("single card");
                        deal();
                        pick = false;
                        break;

                    case "2":
                        Console.WriteLine("How many cards would you like?");

                        dealCard(amount);
                        pick = false;
                        break;

                    default:
                        Console.WriteLine("Make sure the spelling is correct"); // error handling
                        pick = true;
                        break;

                }
            }

            
            //draws one card from the pack (fisher yates shuffle only)
           // string card = pack[rnd.Next(pack.Length)];
            //Console.WriteLine("The {0} card has been drawn from the pack"); //{0} represents the card
        }

        public static void Riffle() //needs finishing
        {

        }

        public static void Noshuffle()
        {
            bool pick = true;
            Console.WriteLine("deal a single card (type 1) or certain amount (type 2)"); //player selection
            while (pick == true)
            {

               string cardpick = Console.ReadLine();
                switch (cardpick)
                {
                    case "1":
                        Console.WriteLine("single card");
                       deal();
                        pick = false;
                        break;

                    case "2":
                        Console.WriteLine("How many cards would you like?");
                        
                        dealCard(amount);
                        pick = false;
                        break;

                    default:
                        Console.WriteLine("Make sure the spelling is correct"); // error handling
                        pick = true;
                        break;

                }
            }

        }
        public static Card deal()//Deals one card
         {  
           if (cards.Count == 0)
            {
                throw new InvalidOperationException("empty deck"); //makes sure that there are cards left
            }
            Card card = cards[0];
            Console.WriteLine(cards[0].Suit + " of " + cards[0].Value);
            cards.RemoveAt(0);
            
            return card;
         }
        public static List<Card> dealCard(int amount) //needs finishing
         {
            //Deals the number of cards specified by 'amount'
            Console.WriteLine("Enter the amount of cards you would like to be dealt");
            int numofcards = int.Parse(Console.ReadLine());

            if(numofcards > pack.Length) //error handling
            {
                Console.WriteLine("There aren't enough cards in the pack"); 
            }
            return null;
         }
    }
}

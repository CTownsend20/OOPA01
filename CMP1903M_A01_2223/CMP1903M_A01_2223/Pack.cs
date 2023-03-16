using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    public class Pack
    {
        public static List<Card> cards = new List<Card>(); //base for pack of cards
        private int typeOfShuffle;
        private static int amount;
        public static string[] pack = new string[52];

        

        public Pack()
        {
            cards = new List<Card>(); //creates a new list for the cards
            int[] suits = { 1, 2, 3, 4 }; // list of suits
            int[] values = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }; //list of values
            foreach (int suit in suits) //loops through all of the suits
            {
                foreach (int value in values) //loops through all of the values
                {
                    cards.Add( new Card { Suit = suit, Value = value }); //adds each card to the pack

                   
                   
                }


            }
            

          //  for (int i = 0; i < cards.Count; i++) // debugging: make sure the Suit and Value are unique to each card
            //{
              //  Console.WriteLine(cards[i].Suit + " Suit " + cards[i].Value + " value");

               // if (cards[i].Suit == cards[50].Suit)
                //{ 
                  //  if (cards[i].Value == cards[50].Value)
                   // {
                    //    Console.WriteLine("Got Cards");
                   // }
               // }

            
          //  }

             shuffleCardPack(typeOfShuffle); //lets the user pick what type of shuffle they want


        }

        public List<Card> GetCards() 
        {   
            Console.WriteLine("Cards: " + cards.Count); //tells the user how many cards there are in total
            return cards;
        }
      
        
        public static bool shuffleCardPack(int typeOfShuffle)//shuffles the pack based on the type of shuffle
        {
            bool pick = true; // keeps the while loop going until shuffle_select is correct
            Console.WriteLine("Select the shuffle you want: 1 = Fisher-Yates, 2 = Riffle or 3 = No Shuffle"); //user selection
            while (pick == true)
            {

                String shuffle_select = typeOfShuffle.ToString(); 
                   shuffle_select = Console.ReadLine();
                switch (shuffle_select) //switch while loop, ends when a valid answer is inputted
                {
                    case "1":
                        Console.WriteLine("You have selected: Fisher-Yates Shuffle");
                        FisherYates(cards); 
                        pick = false; //ends loop
                        break;
                        
                    case "2":
                        Console.WriteLine("You have selected: Riffle Shuffle");
                        Riffle(cards);
                        pick = false; 
                        break;

                    case "3":
                        Console.WriteLine("You have selected: No Shuffle");
                        Noshuffle();
                        pick = false;
                        break;

                    default:
                        Console.WriteLine("Make sure the number you entered is valid"); // error handling
                        pick = true;
                        break;
                }

            }
            return true;
        }
        public static void DealChoice() //lets the user pick how many cards they want to deal
        {
            bool pick = true;
            Console.WriteLine("deal a single card (type 1) or certain amount (type 2)"); //user selection
            while (pick == true) //switch while loop, ends when a valid answer is inputted
            {

                string cardpick = Console.ReadLine();
                switch (cardpick)
                {
                    case "1":
                        Console.WriteLine("single card");
                        deal();
                        pick = false; //ends loop
                        break;

                    case "2":
                        Console.WriteLine("How many cards would you like?");

                        dealCard(amount); //activates the dealCard method
                        pick = false;
                        break;

                    default:
                        Console.WriteLine("Make sure the number you entered is valid"); //error handling
                        pick = true;
                        break;

                }
            }

        }

        public static void FisherYates(List<Card> pack)//random card shuffle 
        {                    
                Random rnd = new Random(); //imports a new random object
                
            for (int i = 0; i < pack.Count; i++) //keeps track of the amount of cards 
                {
                    int j = rnd.Next(i, pack.Count); //generates a number between 0 and the amount of cards in the array
                    Card temp = pack[i]; //creates a temporary pack to store the randomly generated cards in
                    cards[i] = pack[j]; 
                    cards[j] = temp; //replaces the original card values with those from the randomly generated temporary pack

                }
           
                DealChoice(); //lets the user pick how many cards they want to deal                          


        }

        public static void Riffle(List<Card> pack) 
        {
            int half = pack.Count / 2; //splits pack in two
            List<Card> firstPart = pack.GetRange(0, half); //contains the first half of the pack
            List<Card> secondPart = pack.GetRange(half, pack.Count - half); //contains second half
            pack.Clear(); //makes sure that the pack is empty
           
            while (firstPart.Count > 0 && secondPart.Count > 0) //checks if there are still cards left to shuffle
            {
                pack.Add(firstPart[0]); //adds the top card from the first half to the new pack
                firstPart.RemoveAt(0);  //removes the top card from the first half
                pack.Add(secondPart[0]); //same as the above but for the second half
                secondPart.RemoveAt(0);                                  
            }
            pack.AddRange(firstPart);   //adds any cards that haven't been dealt from the first half to the new pack
            pack.AddRange(secondPart);  //same as the above but for the second half
            DealChoice(); //lets the user pick how many cards they want to deal


        }

        public static void Noshuffle() //doesn't shuffle the pack
        {
            DealChoice(); //lets the user pick how many cards they want to deal
            
        }
        public static Card deal()//Deals one card
         {  
           if (cards.Count == 0)
            {
                throw new InvalidOperationException("empty deck"); //makes sure that there are cards left
            }
            Card card = cards[0];
            Console.WriteLine(cards[0].Suit + " of " + cards[0].Value); //outputs dealt card
            cards.RemoveAt(0);
            
            return card;
         }
        public static List<Card> dealCard(int amount) //deals a certain amount of cards based on user input
         {
            
            //Deals the number of cards specified by 'amount'
            Console.WriteLine("Enter the amount of cards you would like to be dealt");
            int NumOfCards = int.Parse(Console.ReadLine()); //reads inputted number, turns it into an integer
          
            if (NumOfCards > pack.Length) //error handling
            {
                Console.WriteLine("There aren't enough cards in the pack");
            }
            
            else
            {
                List<Card> dealCard = cards.Take(NumOfCards).ToList(); //takes the inputted number of cards and puts them in another list
                foreach (Card cards in dealCard) //loops through the cards in the new list
                {
                    Console.WriteLine(cards.Suit + " of " + cards.Value); //prints each card 
                    
                }
            }
            return null;
         }
    }
}

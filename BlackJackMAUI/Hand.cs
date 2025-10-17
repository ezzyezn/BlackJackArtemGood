using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackMAUI
{
    internal class Hand
    {
        public List<Card> cards;
        public Hand() 
        {
            cards = new List<Card>();
        }
        /// <summary>
        /// Metoda która wkłada do ręki kartę
        /// </summary>
        /// <param name="card">Karta wyciągnięta z zasobnika</param>
        public void AddCard(Card card)
        {
            cards.Add(card);
        }
        public int Value()
        {
            //zaczynamy od zera punktów
            int value = 0;
            //iterujemy po kartach w ręce
            foreach (Card card in cards)
            {
                switch(card.Rank)
                {
                    case Rank.Ace:
                        value += 11; //Asy liczymy na razie jako 11
                        break;
                    case Rank.Two:
                        value += 2;
                        break;
                    case Rank.Three:
                        value += 3;
                        break;
                    case Rank.Four:
                        value += 4;
                        break;
                    case Rank.Five:
                        value += 5;
                        break;
                    case Rank.Six:
                        value += 6;
                        break;
                    case Rank.Seven:
                        value += 7;
                        break;
                    case Rank.Eight:
                        value += 8;
                        break;
                    case Rank.Nine:
                        value += 9;
                        break;
                    case Rank.Ten:  
                    case Rank.Jack: 
                    case Rank.Queen:
                    case Rank.King:
                        value += 10;
                        break;
                }
            }
            return value;
        }
    }
}

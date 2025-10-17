using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackMAUI
{
    internal class Shoe
    {
        //lista kart w zasobniku
        List<Card> cards;
        /// <summary>
        /// Konstruktor - tworzy nowy zasób kart (Shoe)
        /// </summary>
        public Shoe()
        {
            cards = new List<Card>();
            //dodaje 4 talie kart do zasobnika
            for (int i=0;i<4;i++)
                AddDeck();
            //potastuj karty
            Shuffle();
        }
        /// <summary>
        /// Dodaje do zasobnika 52 karty
        /// </summary>
        public void AddDeck()
        {
            //dodaje do zasobnika 52 karty
            // Pobranie listy nazw rang jako stringi
            List<string> rankNames = Enum.GetNames(typeof(Rank)).ToList();

            // Pobranie listy nazw kolorów jako stringi
            List<string> suitNames = Enum.GetNames(typeof(Suit)).ToList();

            foreach (string suit in suitNames)
            {
                foreach (string rank in rankNames)
                {
                    // Tworzenie nowej karty z odpowiednią rangą i kolorem
                    Card newCard = new Card
                    {
                        Rank = (Rank)Enum.Parse(typeof(Rank), rank),
                        Suit = (Suit)Enum.Parse(typeof(Suit), suit)
                    };
                    // Dodanie karty do zasobnika
                    cards.Add(newCard);
                }
            }
        }
        public void Shuffle()
        {
            //tasuje karty w zasobniku
            List<Card> shuffled = new List<Card>();
            Random r = new Random();
            while (cards.Count > 0)
            {
                int randomIndex = r.Next(0, cards.Count);
                shuffled.Add(cards[randomIndex]);
                cards.RemoveAt(randomIndex);
            }
            cards = shuffled;
        }
        public Card Draw()
        {
            //zwraca wylosowaną kartę z zasobnika
            if (cards.Count == 0)
                throw new Exception("Brak kart w zasobniku!");
            Card drawn = cards[0];
            cards.RemoveAt(0);
            if(cards.Count < 104)
            {
                AddDeck();
                Shuffle();
            }
            return drawn;
        }
    }
}

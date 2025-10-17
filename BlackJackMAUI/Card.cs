using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackMAUI
{
    enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }
    enum Rank
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }
    internal class Card
    {
        /// <summary>
        /// Każda karta posiada rangę i kolor
        /// Zostawiamy je publicznie dostępne dla wygody
        /// TODO: Zmienić na prywatne?
        /// </summary>
        public Rank Rank;
        public Suit Suit;
        /// <summary>
        /// Uproszczony konstruktor - zwraca losową kartę
        /// </summary>
        public Card()
        {
            //Tworzymy sobie generator liczb losowych
            Random r = new Random();
            //losujemy rangę z zakresu 0-12 (13 wartości)
            int randomInt = r.Next(0, 13);
            //rzutujemy liczbę losową na Enum - dostajemy losową rangę
            Rank = (Rank)randomInt;
            //losujemy kolor z zakresu 0-3 (4 wartości)
            randomInt = r.Next(0, 4);
            //rzutujemy liczbę losową na Enum - dostajemy losowy kolor
            Suit = (Suit)randomInt;
        }
        /// <summary>
        /// Domyślny konstruktor - tworzy kartę o podanej randze i kolorze
        /// </summary>
        /// <param name="rank">Ranga karty</param>
        /// <param name="suit">Kolor karty</param>
        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }
        /// <summary>
        /// Zwraca czytelny opis karty, np. "Ace of Spades"
        /// </summary>
        /// <returns>Opis karty</returns>
        public override string ToString()
        {
            return Rank + " of " + Suit;
        }
        /// <summary>
        /// Metoda zwracająca nazwę pliku z obrazkiem karty
        /// </summary>
        /// <returns>Nazwa pliku z folderu Images</returns>
        public string GetFileName()
        {
            //każda nazwa pliku zaczyna się od "card_"
            string filename = "card_";
            //używamy switcha do dopisania odpowiedniego stringa określającego rangę
            switch (Rank)
            {
                case Rank.Ace:
                    filename += "ace";
                    break;
                case Rank.Two:
                    filename += "2";
                    break;
                case Rank.Three:
                    filename += "3";
                    break;
                case Rank.Four:
                    filename += "4";
                    break;
                case Rank.Five:
                    filename += "5";
                    break;
                case Rank.Six:
                    filename += "6";
                    break;
                case Rank.Seven:
                    filename += "7";
                    break;
                case Rank.Eight:
                    filename += "8";
                    break;
                case Rank.Nine:
                    filename += "9";
                    break;
                case Rank.Ten:
                    filename += "10";
                    break;
                case Rank.Jack:
                    filename += "jack";
                    break;
                case Rank.Queen:
                    filename += "queen";
                    break;
                case Rank.King:
                    filename += "king";
                    break;
            }
            //dodajemy podłogę pomiędzy rangą a kolorem
            filename += "_";
            //używamy switcha do dopisania odpowiedniego stringa określającego kolor
            switch (Suit)
            {
                case Suit.Hearts:
                    filename += "hearts";
                    break;
                case Suit.Diamonds:
                    filename += "diamonds";
                    break;
                case Suit.Clubs:
                    filename += "clubs";
                    break;
                case Suit.Spades:
                    filename += "spades";
                    break;
            }
            //na końcu dopisujemy rozszerzenie pliku
            filename += ".png";
            //zwracamy nazwę pliku
            return filename;
        }
    }
}

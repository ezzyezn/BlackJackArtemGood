namespace BlackJackMAUI
{
    public partial class MainPage : ContentPage
    {
        Shoe Shoe;
        Hand PlayerHand;
        Hand DealerHand;
        //defin flagi dla stanu gry
        bool PlayerTurn;
        public MainPage()
        {
            InitializeComponent();
            Shoe = new Shoe();
            PlayerHand = new Hand();
            DealerHand = new Hand();
            this.BackgroundImageSource = "table_background.jpg";
            PlayerTurn = true;
        }

        private void NewGame(object sender, EventArgs e)
        {   
            PlayerTurn = true;
            StartGameButton.IsVisible = false;
            //pokazywanie guzików Hit i Stand
            HitButton.IsVisible = true;
            StandButton.IsVisible = true;
            //pokazywanie rąk gracza i dealera
            DealerCardsHLayout.IsVisible = true;
            PlayerCardsHLayout.IsVisible = true;
            //czyścimy ręce
            PlayerHand.cards.Clear();
            DealerHand.cards.Clear();
            //dwie karty dla dealera i gracza
            DealerHand.AddCard(Shoe.Draw());
            DealerHand.AddCard(Shoe.Draw());
            PlayerHand.AddCard(Shoe.Draw());
            PlayerHand.AddCard(Shoe.Draw());
            RenderCards();
            if (PlayerHand.Value() == 21)
            {
                DisplayAlert("Wygrana", "Masz dokładnie 21 punktów! Wygrałeś rundę.", "OK");
                StartGameButton.IsVisible = true;
                HitButton.IsVisible = false;
                StandButton.IsVisible = false;
            }
        }
        //test losowania karty z puli
        //private void PullRandomCard(object sender, EventArgs e)
        //{
        //    Card card = Shoe.Draw();
        //    RandomCard.Text = card.ToString();
        //    CardImage.Source = ImageSource.FromFile(card.GetFileName());
        //}
        //private void TestHand(object sender, EventArgs e)
        //{

        //    //dodanie do ręki dwóch kart
        //    PlayerHand.AddCard(Shoe.Draw());
        //    PlayerHand.AddCard(Shoe.Draw());
        //    //wykorzystamy sobie labelke od random card zeby wyświetlić wynik
        //    RandomCard.Text = "Wartość kart: " + PlayerHand.Value();
        //    //renderujemy karty na ekranie
        //    RenderCards();
        //}
        private void RenderCards()
        {
            //tutaj będziemy renderować karty na ekranie
            //najpierw czyścimi stare karty
            PlayerCardsHLayout.Children.Clear();
            DealerCardsHLayout.Children.Clear();
            //reka gracza - PlayerCardsHLayout
            foreach (Card card in PlayerHand.cards)
            {
                Image cardImage = new Image();
                cardImage.Source = ImageSource.FromFile(card.GetFileName());
                cardImage.VerticalOptions = LayoutOptions.Fill;
                cardImage.HorizontalOptions = LayoutOptions.Fill;
                cardImage.Aspect = Aspect.AspectFill;
                PlayerCardsHLayout.Add(cardImage);

            }
            PlayerScore.Text = "Wartość kart: " + PlayerHand.Value();
            //reka dealera - DealerCardsHLayout
            foreach (Card card in DealerHand.cards)
            {
                Image cardImage = new Image();
                cardImage.Source = ImageSource.FromFile(card.GetFileName());
                cardImage.HeightRequest = 150;
                DealerCardsHLayout.Add(cardImage);
                cardImage.VerticalOptions = LayoutOptions.Fill;
                cardImage.HorizontalOptions = LayoutOptions.Fill;
                cardImage.Aspect = Aspect.AspectFill;
            }
            if (PlayerTurn)
            {
                if (DealerCardsHLayout.Children.Count > 1)
                {
                    Image backCardImage = new Image();
                    backCardImage.Source = ImageSource.FromFile("back_karty.jpg");
                    backCardImage.HeightRequest = 150;
                    backCardImage.VerticalOptions = LayoutOptions.Fill;
                    backCardImage.HorizontalOptions = LayoutOptions.Fill;
                    backCardImage.Aspect = Aspect.AspectFill;
                    DealerCardsHLayout.Children[1] = backCardImage;
                }
            }
            DealerScore.Text = "Wartość kart: " + DealerHand.Value();
        }
        private void HitButtonClick(object sender, EventArgs e)
        {
            PlayerHand.AddCard(Shoe.Draw());
            RenderCards();

            if (PlayerBust())
            {
                DisplayAlert("Przegrana", "Przekroczyłeś 21 punktów! Przegrałeś rundę.", "OK");
                StartGameButton.IsVisible = true;
                //ukrywanie guz Hit i Stand
                HitButton.IsVisible = false;
                StandButton.IsVisible = false;
                //ukrywanie rąk gracza i dealera
                PlayerTurn = false;
            } 
            if (PlayerHand.Value() == 21)
            {
                DisplayAlert("Wygrana", "Masz dokładnie 21 punktów! Wygrałeś rundę.", "OK");
                StartGameButton.IsVisible = true;
                HitButton.IsVisible = false;
                StandButton.IsVisible = false;
            }
        }
        private bool PlayerBust()
        {
                       return PlayerHand.Value() > 21;
        }

        private void StandButtonClick(object sender, EventArgs e)
        {
            while(DealerHand.Value() < 17)
            PlayerTurn = false;
            
            while(DealerHand.Value() < 17)
            {
                DealerHand.AddCard(Shoe.Draw());
            }
            if (DealerHand.Value() > 21)
            {
                DisplayAlert("Wygrana", "Krupier przekroczył 21 punktów! Wygrałeś rundę.", "OK");
            }
            else if (DealerHand.Value() == PlayerHand.Value())
            {
                DisplayAlert("Remis", "Masz tyle samo punktów co krupier! Remis.", "OK");
            }
            else if (DealerHand.Value() > PlayerHand.Value())
            {
                DisplayAlert("Przegrana", "Krupier ma więcej punktów! Przegrałeś rundę.", "OK");
            }
            else
            {
                DisplayAlert("Wygrana", "Masz więcej punktów niż krupier! Wygrałeś rundę.", "OK");
            }
            StartGameButton.IsVisible = true;
            HitButton.IsVisible = false;
            StandButton.IsVisible = false;
            RenderCards();
        }
    }
}

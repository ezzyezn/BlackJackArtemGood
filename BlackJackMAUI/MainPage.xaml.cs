namespace BlackJackMAUI
{
    public partial class MainPage : ContentPage
    {
        Shoe Shoe;
        Hand PlayerHand;
        Hand DealerHand;
        public MainPage()
        {
            InitializeComponent();
            Shoe = new Shoe();
            PlayerHand = new Hand();
            DealerHand = new Hand();
            this.BackgroundImageSource = "table_background.jpg";

        }

        private void NewGame(object sender, EventArgs e)
        {   
            StartGameButton.IsVisible = false;
            //pokazywanie guzików Hit i Stand
            HitButton.IsVisible = true;
            StandButton.IsVisible = true;
            //czyścimy ręce
            PlayerHand.cards.Clear();
            DealerHand.cards.Clear();
            //dwie karty dla dealera i gracza
            DealerHand.AddCard(Shoe.Draw());
            DealerHand.AddCard(Shoe.Draw());
            PlayerHand.AddCard(Shoe.Draw());
            PlayerHand.AddCard(Shoe.Draw());
            RenderCards();
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
                cardImage.HeightRequest = 150;
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
            }
        }
        private bool PlayerBust()
        {
                       return PlayerHand.Value() > 21;
        }
    }
}

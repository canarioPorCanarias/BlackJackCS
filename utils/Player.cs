using System.Windows.Controls;

namespace BlackJackCS.utils
{
    internal class Player
    {
        private readonly string NamePlayer;
        private double LeftImageDistance = 30d;
        private double TopImageDistance = 25d;
        private readonly MainWindow win;
        private readonly Deck deck;
        public Player(MainWindow mw, string name)
        {
            NamePlayer = name;
            win = mw;
            deck = new Deck(Globals.DeckAmmount);


        }
        public void start()
        {

        }
        public void GetHandPlayer()
        {

            LeftImageDistance += 13;
            TopImageDistance -= 13;
            Image toadd = win.GetImage(deck.Card("player1"));
            _ = win.UserHand.Children.Add(toadd);
            toadd.SetValue(Canvas.LeftProperty, LeftImageDistance);
            toadd.SetValue(Canvas.TopProperty, TopImageDistance);

        }
        public void ButtonHit()
        {

        }
        public void ButtonStand()
        {

        }

        public void ButtonDouble()
        {

        }
        public void ButtonSplit()
        {

        }

        public void SetCardsPoints()
        {

            win.Player1CardCount.Text = Globals.CountCardsByUser("player1").ToString();


        }

    }
}

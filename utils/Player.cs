using System.Windows.Controls;

namespace BlackJackCS.utils
{
    internal class Player
    {
        private readonly string NamePlayer;
        private double LeftImageDistance = 30d;
        private double TopImageDistance = 25d;
        private readonly MainWindow win;
        public Player(MainWindow mw, string name)
        {
            NamePlayer = name;
            win = mw;


        }
        public void start()
        {
            GetHandPlayer();
            GetHandPlayer();
        }
        public void GetHandPlayer()
        {

            LeftImageDistance += 13;
            TopImageDistance -= 13;
            Image toadd = win.GetImage(Globals.deck.Card("player1"));
            _ = win.UserHand.Children.Add(toadd);
            toadd.SetValue(Canvas.LeftProperty, LeftImageDistance);
            toadd.SetValue(Canvas.TopProperty, TopImageDistance);
            SetCardsPoints();
        }


        public void SetCardsPoints()
        {

            win.Player1CardCount.Text = Globals.CountCardsByUser("player1").ToString();


        }

    }
}

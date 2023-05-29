using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BlackJackCS.utils
{
    internal class Dealer
    {
        private MainWindow win;
        public Dealer(MainWindow mw)
        {
            win = mw;
            setInitialCards();
        }
        public void start()
        {

            KeepDrawwingCards();
        }
        public void getResults() 
        {
            //todo check winner 
            win.StartGame.Visibility = Visibility.Visible;
        }
        private void getCard()
        {
            Image dealerImage = win.GetImage(Globals.deck.Card("dealer"));
            Grid.SetColumn(dealerImage, win.DealerHand.Children.Add(dealerImage));
            SetCardsPoints();
        }
        private void _getCard()
        {
            Image dealerImage = win.GetImage(Globals.deck.Card("dealer"));
            Grid.SetColumn(dealerImage, win.DealerHand.Children.Add(dealerImage)-1);
            SetCardsPoints();
        }

        private void setInitialCards()
        {

            getCard();
            Image backCard = win.GetImage("gray_back");

            Grid.SetColumn(backCard, win.DealerHand.Children.Add(backCard));

        }
        private void SetCardsPoints()
        {
            win.DealerHandCount.Text = Globals.CountCardsByUser("dealer").ToString();
        }
        public async void KeepDrawwingCards()
        {
            Image dealerImage = win.GetImage(Globals.deck.Card("dealer"));
            win.DealerHand.Children.Add(dealerImage);
            Grid.SetColumn(dealerImage, 1);
            SetCardsPoints();
            int playerPoints = int.Parse( win.Player1CardCount.Text);
            while (true)
            {
                await Task.Delay(1000);
                if (playerPoints > int.Parse(win.DealerHandCount.Text) & int.Parse(win.DealerHandCount.Text) < 17)
                {
                    _getCard();
                }else if (int.Parse(win.DealerHandCount.Text) == 17)
                {
                    break;
                }else if(int.Parse(win.DealerHandCount.Text) == 16 & playerPoints == 16)
                {
                    break;
                }
                else
                {
                    getResults();
                    break;
                }
            }
           
           
        }

    }
}

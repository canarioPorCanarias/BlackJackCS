using System.Windows.Controls;

namespace BlackJackCS.utils
{
    internal class Dealer
    {
        private readonly MainWindow win;
        public Dealer(MainWindow mw)
        {
            win = mw;
            DefineDealerGrid();
        }
        private void DefineDealerGrid()
        {

            Image dealerImage = win.GetImage(Globals.deck.Card("dealer"));
            Grid.SetColumn(dealerImage, win.DealerHand.Children.Add(win.GetImage("gray_back")));
            Grid.SetColumn(dealerImage, win.DealerHand.Children.Add(dealerImage));
            SetCardsPoints();

        }
        private void SetCardsPoints()
        {
            win.DealerHandCount.Text = Globals.CountCardsByUser("dealer").ToString();
        }

    }
}

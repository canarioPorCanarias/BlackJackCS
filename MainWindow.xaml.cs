using BlackJackCS.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace BlackJackCS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double handX = 35d;
        private double handY = 70d;
        private Deck deck;


        public MainWindow()
        {
            InitializeComponent();
            NewGameStart();

        }
        public void NewGameStart()
        {
            handX = 35d;
            handY = 70d;
            deck = new Deck(2);

            Globals.PlayersCardsValue.Add("dealer", new List<int>() { 0 });
            Globals.PlayersCardsValue.Add("player1", new List<int>() { 0 });
            Globals.players.Add("dealer");
            Globals.players.Add("player1");

            GetHandPlayer();
            GetHandPlayer();


            DefineDealerGrid();
            // add players 

        }
        public void GetHandPlayer()
        {
            handX += 10;
            handY -= 10;
            Image toadd = GetImage(deck.Card("player1"));
            _ = UserHand.Children.Add(toadd);
            toadd.SetValue(Canvas.LeftProperty, handX);
            toadd.SetValue(Canvas.TopProperty, handY);
            SetCardsPoints();
        }
        public Image GetImage(string cardname)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri($"./images/deck/{cardname}.png", UriKind.Relative);
            bitmap.DecodePixelWidth = 55;
            bitmap.DecodePixelHeight = 95;
            bitmap.EndInit();
            Image toadd = new Image
            {
                Source = bitmap,
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch
            };


            return toadd;
        }

        private void DefineDealerGrid()
        {

            Image dealerImage = GetImage(deck.Card("dealer"));
            Grid.SetColumn(dealerImage, DealerHand.Children.Add(GetImage("gray_back")));
            Grid.SetColumn(dealerImage, DealerHand.Children.Add(dealerImage));
            SetCardsPoints();

        }
        private void HitButton_Click(object sender, RoutedEventArgs e)
        {
            _ = MessageBox.Show("hit");

        }
        private void StayButton_Click(object sender, RoutedEventArgs e)
        {
            _ = MessageBox.Show("stay");

        }

        private void DoubleButton_Click(object sender, RoutedEventArgs e)
        {
            _ = MessageBox.Show("dobule");

        }

        private void SetCardsPoints()
        {

            Player1CardCount.Text = Globals.PlayersCardsValue["player1"].Sum().ToString();
            DealerHandCount.Text = Globals.PlayersCardsValue["dealer"].Sum().ToString();


        }
    }
}

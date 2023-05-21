using BlackJackCS.utils;
using System;
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
        public MainWindow()
        {
            InitializeComponent();
            Deck deck = new Deck(); 
            Image toadd = GetImage(deck.Card());
            UserHand.Children.Add(toadd);
            toadd.SetValue(Canvas.LeftProperty, 33d);
            toadd.SetValue(TopProperty, 70d);



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
                Source = bitmap
            };
            return toadd;
        }



    }
}

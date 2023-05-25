using BlackJackCS.utils;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace BlackJackCS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Player player1;
        private readonly Dealer dealer;
        public MainWindow()
        {
            InitializeComponent();
            SourceInitialized += Window_SourceInitialized;
            NewGameStart();

        }
        public void NewGameStart()
        {

            Globals.deck = new Deck(Globals.DeckAmmount);

            Globals.PlayersCardsValue.Add("dealer", new List<int>() { 0 });
            Globals.PlayersCardsValue.Add("player1", new List<int>() { 0 });
            Globals.players.Add("dealer");
            Globals.players.Add("player1");
            Player player1 = new Player(this, "player1");
            _ = new Dealer(this);

            player1.start();


        }



        private void HitButton_Click(object sender, RoutedEventArgs e)
        {
            player1.ButtonHit();
        }
        private void StayButton_Click(object sender, RoutedEventArgs e)
        {
            player1.ButtonStand();

        }

        private void DoubleButton_Click(object sender, RoutedEventArgs e)
        {
            player1.ButtonDouble();

        }

        public Image GetImage(string cardname)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri($"./images/deck/{cardname}.png", UriKind.Relative);
            bitmap.DecodePixelWidth = 55;
            bitmap.DecodePixelHeight = 100;
            bitmap.EndInit();
            Image toadd = new Image
            {
                Source = bitmap,
            };


            return toadd;
        }

        #region aspec ratio
        // keep aspect ratio
        private double _aspectRatio;
        private bool? _adjustingHeight = null;

        internal enum SWP
        {
            NOMOVE = 0x0002
        }
        internal enum WM
        {
            WINDOWPOSCHANGING = 0x0046,
            EXITSIZEMOVE = 0x0232,
        }


        [StructLayout(LayoutKind.Sequential)]
        internal struct WINDOWPOS
        {
            public IntPtr hwnd;
            public IntPtr hwndInsertAfter;
            public int x;
            public int y;
            public int cx;
            public int cy;
            public int flags;
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(ref Win32Point pt);

        [StructLayout(LayoutKind.Sequential)]
        internal struct Win32Point
        {
            public int X;
            public int Y;
        };

        public static Point GetMousePosition() // mouse position relative to screen
        {
            Win32Point w32Mouse = new Win32Point();
            _ = GetCursorPos(ref w32Mouse);
            return new Point(w32Mouse.X, w32Mouse.Y);
        }


        private void Window_SourceInitialized(object sender, EventArgs ea)
        {
            HwndSource hwndSource = (HwndSource)HwndSource.FromVisual((Window)sender);
            hwndSource.AddHook(DragHook);

            _aspectRatio = Width / Height;
        }

        private IntPtr DragHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch ((WM)msg)
            {
                case WM.WINDOWPOSCHANGING:
                    {
                        WINDOWPOS pos = (WINDOWPOS)Marshal.PtrToStructure(lParam, typeof(WINDOWPOS));

                        if ((pos.flags & (int)SWP.NOMOVE) != 0)
                        {
                            return IntPtr.Zero;
                        }

                        Window wnd = (Window)HwndSource.FromHwnd(hwnd).RootVisual;
                        if (wnd == null)
                        {
                            return IntPtr.Zero;
                        }

                        // determine what dimension is changed by detecting the mouse position relative to the 
                        // window bounds. if gripped in the corner, either will work.
                        if (!_adjustingHeight.HasValue)
                        {
                            Point p = GetMousePosition();

                            double diffWidth = Math.Min(Math.Abs(p.X - pos.x), Math.Abs(p.X - pos.x - pos.cx));
                            double diffHeight = Math.Min(Math.Abs(p.Y - pos.y), Math.Abs(p.Y - pos.y - pos.cy));

                            _adjustingHeight = diffHeight > diffWidth;
                        }

                        if (_adjustingHeight.Value)
                        {
                            pos.cy = (int)(pos.cx / _aspectRatio); // adjusting height to width change
                        }
                        else
                        {
                            pos.cx = (int)(pos.cy * _aspectRatio); // adjusting width to heigth change
                        }

                        Marshal.StructureToPtr(pos, lParam, true);
                        handled = true;
                    }
                    break;
                case WM.EXITSIZEMOVE:
                    _adjustingHeight = null; // reset adjustment dimension and detect again next time window is resized
                    break;
            }

            return IntPtr.Zero;

        }

    }
    #endregion
}

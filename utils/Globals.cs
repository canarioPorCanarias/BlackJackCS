using System.Collections.Generic;

namespace BlackJackCS.utils
{
    public static class Globals
    {
        public static List<string> UsedCards = new List<string>();
        public static Dictionary<string, List<int>> PlayersCardsValue = new Dictionary<string, List<int>>();
        public static List<string> players = new List<string>();
        public static int CountCardsByUser(string user)
        {
            int num = 0;
            if (PlayersCardsValue[user].Count >= 2)
            {
                if ((PlayersCardsValue[user][0] == 1 && PlayersCardsValue[user][1] == 10) || (PlayersCardsValue[user][0] == 10 && PlayersCardsValue[user][1] == 1))
                {
                    return 21;
                }

            }

            foreach (int card in PlayersCardsValue[user])
            {
                if (card == 1)
                {
                    if (num <= 11)
                    {
                        num += 11;
                    }
                    else
                    {
                        num++;
                    }
                }
                else
                {
                    num += card;
                }
            }
            return num;

        }
        public static int DeckAmmount = 1;
        public static Deck deck;
    }
}

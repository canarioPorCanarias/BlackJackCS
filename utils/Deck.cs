using System;
using System.Linq;


namespace BlackJackCS.utils
{
    internal class Deck
    {
        public int DecksAmmount;
        public Deck(int DeckNum)
        {
            DecksAmmount = DeckNum;

        }
        public string Card(string playername)
        {
            string newcard;
            int cardNum;
            do
            {
                string cardletter = string.Empty;

                int typeCard = GetRandomNumInRange(1, 4);
                cardNum = GetRandomNumInRange(1, 13);

                string bigCardChar = string.Empty;

                switch (typeCard)
                {
                    case 1:
                        cardletter = "C";
                        break;
                    case 2:
                        cardletter = "D";
                        break;
                    case 3:
                        cardletter = "H";
                        break;
                    case 4:
                        cardletter = "S";
                        break;
                }
                if (cardNum >= 11)
                {

                    switch (cardNum)
                    {
                        case 11:
                            bigCardChar = "J";
                            break;
                        case 12:
                            bigCardChar = "Q";
                            break;
                        case 13:
                            bigCardChar = "K";
                            break;
                    }
                    cardNum = 10;
                }
                newcard = bigCardChar != string.Empty ? bigCardChar : cardNum.ToString();

                newcard += cardletter;
                if (NeedToGetNewDeck())
                {
                    Globals.UsedCards.Clear();
                }

            } while (!CanUseCard(newcard));
            Globals.UsedCards.Add(newcard);

            Globals.PlayersCardsValue[playername].Add(cardNum);
            return newcard;

        }
        private int GetRandomNumInRange(int min, int max)
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());
            int rInt = r.Next(min, max + 1);
            return rInt;
        }
        public int CountUsedCards()
        {
            return Globals.UsedCards.Count;
        }
        private bool NeedToGetNewDeck()
        {
            return (CountUsedCards() / (DecksAmmount * 40) * 100) > 60;
        }
        private bool CanUseCard(string card)
        {
            return Globals.UsedCards.Where(val => val.Equals(card)).Count() < DecksAmmount;
        }
        public static int CardToNumber(string card)
        {
            _ = card.Last();
            return 0;
        }

    }

}

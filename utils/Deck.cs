using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJackCS.utils
{
    internal class Deck
    {
        private Random rand;
        
        public string Card()
        {
            rand = new Random();

            List<int[]> vect = new List<int[]>(){
            new int []{1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13},
            new int []{1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13},
            new int []{1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13},
            new int []{1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13}
            };

            int typeofcard = rand.Next(1, 13) % 4;
            int numofcard = rand.Next(1, 13) % vect[typeofcard].Where(x => x > 0).ToArray().Length;
            while (numofcard < 0)
            {
                numofcard = rand.Next(1, 13) % vect[typeofcard].Where(x => x > 0).ToArray().Length;
            }
            vect[typeofcard][numofcard] = -1;
            numofcard += 1;
            typeofcard += 1;

            string tipo;
            switch (typeofcard)
            {
                case 1:
                    tipo = "C";
                    break;
                case 2:
                    tipo = "D";
                    break;
                case 3:
                    tipo = "H";
                    break;
                case 4:
                    tipo = "S";
                    break;
                default:
                    tipo = "";
                    break;
            }

            if (numofcard >= 11)
            {
                string grande;
                switch (numofcard)
                {
                    case 11:
                        grande = "J";
                        break;
                    case 12:
                        grande = "Q";
                        break;
                    case 13:
                        grande = "K";
                        break;
                    default:
                        grande = "";
                        break;
                }

                return grande + tipo + ".png";
            }
            else
            {

                return numofcard.ToString() + tipo + ".png";
            }
        }

    }
}

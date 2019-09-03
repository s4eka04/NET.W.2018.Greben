using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AddTaskEvent;

namespace Roulette
{
    class Program
    {
        static void Main(string[] args)
        {
            RouletteMeneger rouletteMeneger = new RouletteMeneger();
            NumberDrawnOut drawnOut = new NumberDrawnOut(rouletteMeneger);
            int numberRandom;
            int colorRandom;
            Random rand = new Random();

            while(true)
            {
                numberRandom = rand.Next(100);
                colorRandom = rand.Next(1, 3);

                if(colorRandom == (int)Color.Green)
                {
                    if (numberRandom % 2 == 0)
                        {
                        rouletteMeneger.SupplementInfo(numberRandom, Parity.Even, Color.Green);
                    }
                    if(numberRandom % 2 != 0)
                    {
                        rouletteMeneger.SupplementInfo(numberRandom, Parity.Odd, Color.Green);
                    }
                }
                else if (colorRandom == (int)Color.Red)
                {
                    if (numberRandom % 2 == 0)
                    {
                        rouletteMeneger.SupplementInfo(numberRandom, Parity.Even, Color.Red);
                    }
                    if (numberRandom % 2 != 0)
                    {
                        rouletteMeneger.SupplementInfo(numberRandom, Parity.Odd, Color.Red);
                    }
                }

                Thread.Sleep(2500);
            }
        }
    }
}

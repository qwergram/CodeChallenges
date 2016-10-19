using System.Diagnostics;
using System.Linq;

namespace KeyPresses
{

    class Program
    {
        static int Presses(string phrase)
        {
            string[] pressMap = {"ADGJMPTW1*# ", "QBEHKNWUX0", "CFILORVY", "SZ234568", "79"};
            int result = 0;
            foreach (char letter in phrase.ToUpper())
            {
                for (int i=0; i < pressMap.Count(); i++)
                {
                    if (pressMap[i].IndexOf(letter) != -1) {
                        result += (i + 1);
                        break;
                    }
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
            Debug.Assert(Presses("LOL") == 9);
            Debug.Assert(Presses("HOW R U") == 13);
        }
    }
}

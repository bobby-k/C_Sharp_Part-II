using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiddenMessage
{
    class HiddenMessage
    {
        private static StringBuilder hiddenMsg = new StringBuilder();

        static void Main()
        {
            string firstSymbolIndexStr = Console.ReadLine();
            while (firstSymbolIndexStr != "end")
            {
                int firstSymbolIndex = int.Parse(firstSymbolIndexStr);
                int numberOfSymbolsToSkip = int.Parse(Console.ReadLine());
                string subtitles = Console.ReadLine();
                if (firstSymbolIndex >= subtitles.Length)
                {
                    firstSymbolIndexStr = Console.ReadLine();
                    continue;
                }

                ExtractHiddenMsg(subtitles, firstSymbolIndex, numberOfSymbolsToSkip);

                firstSymbolIndexStr = Console.ReadLine();
            }

            // Output
            Console.WriteLine(hiddenMsg);
        }

        private static void ExtractHiddenMsg(string subtitles, int firstSymbolIndex, int numberOfSymbolsToSkip)
        {
            if (firstSymbolIndex >= 0)
            {
                if (numberOfSymbolsToSkip >= 0)
                {
                    for (int i = firstSymbolIndex; i < subtitles.Length; i += numberOfSymbolsToSkip)
                    {
                        hiddenMsg.Append(subtitles[i]);
                    }
                }
                else
                {
                    for (int i = firstSymbolIndex; i >= 0; i += numberOfSymbolsToSkip)
                    {
                        hiddenMsg.Append(subtitles[i]);
                    }
                }

            }
            else
            {
                if (numberOfSymbolsToSkip >= 0)
                {
                    for (int i = subtitles.Length + firstSymbolIndex; i < subtitles.Length; i += numberOfSymbolsToSkip)
                    {
                        hiddenMsg.Append(subtitles[i]);
                    }
                }
                else
                {
                    for (int i = subtitles.Length + firstSymbolIndex; i >= 0; i += numberOfSymbolsToSkip)
                    {
                        hiddenMsg.Append(subtitles[i]);
                    }
                }
            }

        }
    }
}

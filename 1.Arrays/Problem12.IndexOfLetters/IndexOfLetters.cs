using System;
using System.Globalization;
using System.Threading;

namespace Problem12.IndexOfLetters
{
    class IndexOfLetters
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            // Write a program that creates an array containing all letters from the alphabet (A-Z).
            // Read a word from the console and print the index of each of its letters in the array.

            // Логика: ще използваме Binarry Search Algorithm (подробно обяснение на алгоритъма има в Problem11.)
            // за всяка буква от дадената дума така ще намерим най-бързо индексите 
            char[] alphabet = { 
                                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I',
                                'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 
                                'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 
                                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 
                                'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r',
                                's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
                              };

            Console.Write("Please enter any word: ");
            string word = Console.ReadLine();

            // разделител за повече прегледност
            Console.WriteLine(new string('*', 25));

            // Binarry Search Algorithm 
            // в този случай няма нужда от последната проверка в алгоритъма от Problem11. тъй като всяка буква със сигурност ще се 
            // съдържа в масива, т.е. няма случай в който буквата да я няма в азбуката
            int start = 0;
            int end = alphabet.Length - 1;
            int middle = 0;

            foreach (char letter in word)
            {
                while (start <= end)
                {
                    middle = start + ((end - start) / 2);
                    if (alphabet[middle] == letter)
                    {
                        Console.WriteLine("\'{0}\' has index [{1}]", letter, middle);
                        break;
                    }
                    else if (alphabet[middle] > letter)
                    {
                        end = middle - 1;
                    }
                    else
                    {
                        start = middle + 1;
                    }
                }
                // зануляваме преди да се вземе следващата буква
                start = 0;
                end = alphabet.Length - 1;
                middle = 0;
            }


        }
    }
}

using System;

internal class LettersCount
{
    // Write a program that reads a string from the console and prints all different letters in the string along with information how
    // many times each letter is found.

    // Логика: Ще създадем масив от int-ове с размер колкото е размера на UTF таблицата(65536 или 2^16) това е ushort.MaxValue + 1, тъй
    // като char e 16-bit.После ще взимаме всеки символ започвайки от нулевият до последният. Ако текущият символ е буква ще я кастнем
    // към int, така ще получим номера под който стой буквата в UTF таблицата и този номер ще е индексът, чиято стойност ще увеличим с
    // 1 ( Всички стойности в масива имат default value 0).Така реално сме пребройли текущата буква.Накрая ще минем през целият масив
    // от int-ове и ще отпечатим всички позиции с ненулеви стойности, като кастнем първо индекса към char(за да получим пак съответната
    // буква). Така ще имаме всички двойки буква и колко пъти се среща и то дори сотирани в реда в който се срещат в UTF таблицата.
    private static void Main()
    {
        string text = "Write a program that reads a string from the console and prints all different letters in the string";

        int[] utfChars = new int[ushort.MaxValue + 1];

        for (int i = 0; i < text.Length; i++)
        {
            if (char.IsLetter(text[i]))
            {
                int index = (int)text[i];
                utfChars[index]++;
            }
        }

        for (int i = 0; i < utfChars.Length; i++)
        {
            if (utfChars[i] != 0)
            {
                Console.WriteLine("{0} - {1} times", (char)i, utfChars[i]);
            }
        }
    }
}
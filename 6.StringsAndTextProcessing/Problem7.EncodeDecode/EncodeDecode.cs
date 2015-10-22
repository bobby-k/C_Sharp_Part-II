using System;
using System.Text;

internal class EncodeDecode
{
    // Write a program that encodes and decodes a string using given encryption key (cipher). The key consists of a sequence of
    // characters. The encoding/decoding is done by performing XOR (exclusive or) operation over the first letter of the string with
    // the first of the key, the second – with the second, etc. When the last key character is reached, the next is the first.
    private static void Main()
    {
        string key = "123abcAbc#$%`";

        Console.WriteLine("Enter the text to be encrypted:");
        string text = Console.ReadLine();

        text = Encrypt(text, key);
        Console.WriteLine(text);

        text = Decrypt(text, key);
        Console.WriteLine(text);
    }

    private static string Encrypt(string someText, string key)
    {
        // Логика: прилагаме XOR върху първият символ на подаденият текст и първият символ на ключа. XOR работи върху битовете на
        // съответните char-ове (16-bits) и връща нов int от резултата съответно различно подредени битове. Ние ще кастваме този int
        // към char за да получим символ отговарящ на него от UNICODE стандарта. Ще записваме този символ в стринг чрез StringBuilder
        // за да можем да отпечатим "енкоднатият" текст.
        var encryptedText = new StringBuilder(someText.Length);

        for (int i = 0, j = 0; i < someText.Length; i++, j++)
        {
            if (j == key.Length) // When the last key character is reached, the next is the first
            {
                j = 0;
            }

            encryptedText.Append((char)(someText[i] ^ key[j]));
        }

        return encryptedText.ToString();
    }

    private static string Decrypt(string encryptedText, string key)
    {
        // Логика: Подобно на Encrypt метода в този метод ще получаваме някакъв текст, който е вече кодиран с даденият ключ, а ние ще
        // използваме ключа за да го декриптираме.Пак ще използваме XOR за да възстановим първоначалният символ. Ще прилагаме XOR върху
        // първият символ на подаденият текст и първият символ на ключа. Полученият резултат трябва да е номера на символа по UNICODE
        // стандарта, затова го кастваме към char за да получим въпросният символ и го записваме в стринг чрез StringBuilder, след като
        // сме минали през всички символи можем да отпечатим "декриптираният" текст.
        StringBuilder decryptedText = new StringBuilder();

        for (int i = 0, j = 0; i < encryptedText.Length; i++, j++)
        {
            if (j >= key.Length) // When the last key character is reached, the next is the first
            {
                j = 0;
            }

            int decryptedCharNum = encryptedText[i] ^ key[j];
            char decryptedChar = (char)decryptedCharNum;
            decryptedText.Append(decryptedChar);
        }

        return decryptedText.ToString();
    }
}
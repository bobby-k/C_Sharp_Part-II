using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpJump
{
    public class JumpJump
    {
        public static void Main()
        {
            string instructions = Console.ReadLine();

            int position = 0;

            try
            {
                while (true)
                {
                    if (char.IsDigit(instructions[position]))
                    {
                        int currentDigit = int.Parse(instructions[position].ToString());
                        if (currentDigit % 2 == 0 && currentDigit != 0)
                        {
                            position += currentDigit;
                        }
                        else if (currentDigit % 2 != 0)
                        {
                            position -= currentDigit;
                        }
                        else if (currentDigit == 0)
                        {
                            Console.WriteLine("Too drunk to go on after {0}!", position);
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Jump, Jump, DJ Tomekk kommt at {0}!", position);
                        return;
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Fell off the dancefloor at {0}!", position);
            }
        }
    }
}

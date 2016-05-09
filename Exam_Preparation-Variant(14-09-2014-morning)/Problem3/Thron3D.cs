using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class Thron3D
{
    static bool[,] playField;
    static int x, y, z;
    static string redCmds;
    static string blueCmds;
    static int redPlayerDirection = 0;
    static int bluePlayerDirection = 2;

    static int initCoordRedX;
    static int initCoordRedY;

    static int initCoordBlueX;
    static int initCoordBlueY;

    static void Main()
    {
        var reader = new StreamReader(@"D:\C#2\Variant 1(2013-09-14, Morning)podg\Problem-3-Tron-3D\Tests\Tests\test.012.in.txt");

        ReadInput(reader);

        initCoordRedX = x / 2;
        initCoordRedY = y / 2;

        initCoordBlueX = initCoordRedX;
        initCoordBlueY = y + z + (y / 2);

        // initialize playfield      __         
        //                        __|//|___ ___ 
        // open-spread cube area |__|__|___|___|  with forbidden walls
        //                          |//| 
        playField = new bool[x + 1, (y * 2 + z * 2)];

        int redX = initCoordRedX;
        int redY = initCoordRedY;
        //playField[redX, redY] = true;

        int blueX = initCoordBlueX;
        int blueY = initCoordBlueY;
        //playField[blueX, blueY] = true;

        for (int redCmdIndex = 0, blueCmdIndex = 0; redCmdIndex < redCmds.Length; redCmdIndex++, blueCmdIndex++)
        {
            char currentCmdRed = redCmds[redCmdIndex];
            switch (currentCmdRed)
            {
                case 'L':
                    RotateLeft(ref redPlayerDirection);
                    break;
                case 'R':
                    RotateRight(ref redPlayerDirection);
                    break;
                default:
                    Move(redPlayerDirection, ref redX, ref redY);
                    if (redY >= playField.GetLength(1) - 1)
                    {
                        redY = 0;
                    }
                    else if (redY < 0)
                    {
                        redY = playField.GetLength(1) - 1;
                    }

                    break;
            }

            char currentCmdBlue = blueCmds[blueCmdIndex];
            switch (currentCmdBlue)
            {
                case 'L':
                    RotateLeft(ref bluePlayerDirection);
                    break;
                case 'R':
                    RotateRight(ref bluePlayerDirection);
                    break;
                default:
                    Move(bluePlayerDirection, ref blueX, ref blueY);
                    if (blueY >= playField.GetLength(1) - 1)
                    {
                        blueY = 0;
                    }
                    else if (blueY < 0)
                    {
                        blueY = playField.GetLength(1) - 1;
                    }

                    break;
            }

            bool redCrash = CheckCollision(redX, redY);
            bool blueCrash = CheckCollision(blueX, blueY);

            if (redCrash && blueCrash)
            {
                Console.WriteLine("DRAW");
                // count distance
                break;
            }
            else if (redCrash)
            {
                Console.WriteLine("BLUE");
                // count distance
                break;
            }
            else if (blueCrash)
            {
                Console.WriteLine("RED");
                // count distance
                break;
            }
        }
    }

    private static bool CheckCollision(int playerX, int playerY)
    {
        if (playerX < 0)
        {
            return true;
        }

        if (playerX > playField.GetLength(0) - 1)
        {
            return true;
        }

        if (playField[playerX, playerY] == true)
        {
            return true;
        }

        return false;
    }

    private static void Move(int playerDirection, ref int playerX, ref int playerY)
    {
        // position 0 -> East/to the right 
        // position 1 -> North/up
        // position 2 -> West/to the left
        // position 3 -> South/down
        switch (playerDirection)
        {
            case 1:
                playField[playerX, playerY] = true;
                playerX--;
                break;
            case 2:
                playField[playerX, playerY] = true;
                playerY--;
                break;
            case 3:
                playField[playerX, playerY] = true;
                playerX++;
                break;
            default:
                playField[playerX, playerY] = true;
                playerY++;
                break;
        }
    }

    private static void RotateRight(ref int playerDirection)
    {
        // position 0 -> East/to the right 
        // position 1 -> North/up
        // position 2 -> West/to the left
        // position 3 -> South/down
        switch (playerDirection)
        {
            case 1:
                playerDirection = 0;
                break;
            case 2:
                playerDirection = 1;
                break;
            case 3:
                playerDirection = 2;
                break;
            default:
                playerDirection = 3;
                break;
        }
    }

    private static void RotateLeft(ref int playerDirection)
    {
        // position 0 -> East/to the right 
        // position 1 -> North/up
        // position 2 -> West/to the left
        // position 3 -> South/down
        switch (playerDirection)
        {
            case 1:
                playerDirection = 2;
                break;
            case 2:
                playerDirection = 3;
                break;
            case 3:
                playerDirection = 0;
                break;
            default:
                playerDirection = 1;
                break;
        }
    }

    static void ReadInput(StreamReader reader)
    {
        string[] dimencions = reader.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        x = int.Parse(dimencions[0]);
        y = int.Parse(dimencions[1]);
        z = int.Parse(dimencions[2]);

        redCmds = reader.ReadLine();
        blueCmds = reader.ReadLine();
    }
}

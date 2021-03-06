﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {

        public static char[,] gameBoard =
        {
            {'1','2','3'},
            {'4','5','6'},
            {'7','8','9'}
        };
        private static bool  player1Turn = true;
        private static bool player2Turn = false;
        private static bool gameIsRunning = true;
        private static int selection;
        private static string winner = null;
        private static bool isStalemate = false;

        static void Main(string[] args)
        {

            drawBoard();
            checkInput();
            printInfo();

            Console.Read();

        }

        public static void drawBoard()
        {
            Console.WriteLine("\n     |   |   ");
            Console.WriteLine("   {0} | {1} | {2} ",gameBoard[0,0],gameBoard[0,1],gameBoard[0,2]);
            Console.WriteLine("  ___|___|___");
            Console.WriteLine("     |   |   ");
            Console.WriteLine("   {0} | {1} | {2} ", gameBoard[1, 0], gameBoard[1, 1], gameBoard[1, 2]);
            Console.WriteLine("  ___|___|___");
            Console.WriteLine("     |   |   ");
            Console.WriteLine("   {0} | {1} | {2} ", gameBoard[2, 0], gameBoard[2, 1], gameBoard[2, 2]);
        }
        public static void checkInput()
        {
            while (gameIsRunning)
            {
                if (player1Turn)
                {
                    Console.WriteLine("\n\nPlayer 1, choose a number!");
                    string inp = Console.ReadLine();
                    try
                    {
                        selection = Int32.Parse(inp);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Please only enter a number");
                        continue;
                    }
                    if (selection < 1 || selection > 9)
                    {
                        Console.WriteLine("Please only enter a number between 1 and 9");
                        continue;
                    }
                    drawX();
                    player1Turn = false;
                    player2Turn = true;

                }
                else if (player2Turn)
                {
                    Console.WriteLine("\n\nPlayer 2, choose a number!");
                    string inp = Console.ReadLine();
                    try
                    {
                        selection = Int32.Parse(inp);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Please only enter a number");
                        continue;
                    }
                    if (selection < 1 || selection > 9)
                    {
                        Console.WriteLine("Please only enter a number between 1 and 9");
                        continue;
                    }
                    drawO();
                    player2Turn = false;
                    player1Turn = true;
                }
                hasWon();
                checkForTie();
            }
            if (isStalemate)
            {
                Console.WriteLine("The game ends with a tie!");
            }
            else{
                Console.WriteLine("\n{0}, YOU ARE THE WINNER!", winner);
            }
        }

       

        public static void drawX()
        {
            if (selection == 1)
            {
                checkX(0, 0);
            }
            else if (selection == 2)
            {
                checkX(0, 1);
            }
            else if (selection == 3)
            {
                checkX(0, 2);
            }
            else if (selection == 4)
            {
                checkX(1, 0);
            }
            else if (selection == 5)
            {
                checkX(1, 1);
            }
            else if (selection == 6)
            {
                checkX(1, 2);
            }
            else if (selection == 7)
            {
                checkX(2, 0);
            }
            else if (selection == 8)
            {
                checkX(2, 1);
            }
            else if (selection == 9)
            {
                checkX(2, 2);
            }
            drawBoard();
        }
        public static void drawO()
        {
            if (selection == 1)
            {
                checkO(0, 0);
            }
            else if (selection == 2)
            {
                checkO(0, 1);
            }
            else if (selection == 3)
            {
                checkO(0, 2);
            }
            else if (selection == 4)
            {
                checkO(1, 0);
            }
            else if (selection == 5)
            {
                checkO(1, 1);
            }
            else if (selection == 6)
            {
                checkO(1, 2);
            }
            else if (selection == 7)
            {
                checkO(2, 0);
            }
            else if (selection == 8)
            {
                checkO(2, 1);
            }
            else if (selection == 9)
            {
                checkO(2, 2);
            }
            drawBoard();
        }
        public static bool alreadySelected(int x, int y)
        {
            if (gameBoard[x,y] == 'X'|| gameBoard[x,y] == 'O')
            {
                return true;
            }
            return false;
        }
        public static void checkX(int x, int y)
        {
            if (alreadySelected(x, y))
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("\nPlease choose an empty space!");    
            } else
            {
                gameBoard[x, y] = 'X';
            }
        }
        public static void checkO(int x, int y)
        {
            if (alreadySelected(x, y))
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("\nPlease choose an empty space!");
            }
            else
            {
                gameBoard[x, y] = 'O';
            }
        }
        public static void hasWon()
        {
            if (gameBoard[0, 0] == 'X' && gameBoard[0, 1] == 'X' && gameBoard[0, 2] == 'X' ||
                gameBoard[1, 0] == 'X' && gameBoard[1, 1] == 'X' && gameBoard[1, 2] == 'X' ||
                gameBoard[2, 0] == 'X' && gameBoard[2, 1] == 'X' && gameBoard[2, 2] == 'X' ||
                gameBoard[0, 0] == 'X' && gameBoard[1, 0] == 'X' && gameBoard[2, 0] == 'X' ||
                gameBoard[0, 1] == 'X' && gameBoard[1, 1] == 'X' && gameBoard[2, 1] == 'X' ||
                gameBoard[0, 2] == 'X' && gameBoard[1, 2] == 'X' && gameBoard[2, 2] == 'X' ||
                gameBoard[0, 0] == 'X' && gameBoard[1, 1] == 'X' && gameBoard[2, 2] == 'X' ||
                gameBoard[0, 2] == 'X' && gameBoard[1, 1] == 'X' && gameBoard[2, 0] == 'X')
            {
                gameIsRunning = false;
                winner = "Player 1";
            }
            else if (gameBoard[0, 0] == 'O' && gameBoard[0, 1] == 'O' && gameBoard[0, 2] == 'O' ||
                gameBoard[1, 0] == 'O' && gameBoard[1, 1] == 'O' && gameBoard[1, 2] == 'O' ||
                gameBoard[2, 0] == 'O' && gameBoard[2, 1] == 'O' && gameBoard[2, 2] == 'O' ||
                gameBoard[0, 0] == 'O' && gameBoard[1, 0] == 'O' && gameBoard[2, 0] == 'O' ||
                gameBoard[0, 1] == 'O' && gameBoard[1, 1] == 'O' && gameBoard[2, 1] == 'O' ||
                gameBoard[0, 2] == 'O' && gameBoard[1, 2] == 'O' && gameBoard[2, 2] == 'O' ||
                gameBoard[0, 0] == 'O' && gameBoard[1, 1] == 'O' && gameBoard[2, 2] == 'O' ||
                gameBoard[0, 2] == 'O' && gameBoard[1, 1] == 'O' && gameBoard[2, 0] == 'O')
                {
                    gameIsRunning = false;
                    winner = "Player 2";
                }

        }
        public static bool isTie()
        {
            int counter = 0;
            foreach (char n in gameBoard)
            {
                if (n == 'O' || n == 'X')
                {
                    counter++;
                }
            }


            if (counter == 9)
            {
                isStalemate = true;
                return true;
            }

            return false; 
        }

        public static void checkForTie()
        {
            if (isTie())
            {
                gameIsRunning = false;
                
            }
        }

 
        public static void printInfo()
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("\nRestart application to play again");
            Console.WriteLine("\n-------------------------------------------");
            Console.WriteLine("\nThis short, simple game was made by Alexander Delpin");


        }

    }
}

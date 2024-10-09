using System;


namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] mat = new char[3, 3];
            char win = ' ';
            char turn;
            int turnCounter = 0;
            RestartGame(mat);
            while (win != 'X' && win != 'O' && win != 'E')
            {
                if (turnCounter % 2 == 0)
                    turn = 'X';
                else
                    turn = 'O';
                DrawBoard(mat);
                SelectMove(turn, mat);
                win = CheckWin(mat);
                turnCounter++;

            }
            DeclareWinner(mat, win);
        }

        static void DrawBoard(char[,] mat)
        {
            Console.Clear();
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.ResetColor();
                    if (mat[i, j] == 'O')
                        Console.ForegroundColor = ConsoleColor.Green;
                    else if (mat[i, j] == 'X')
                        Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write(" " + mat[i, j]);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    if (j < 2)
                        Console.Write(" |");
                }
                if (i < 2)
                    Console.WriteLine("\n---+---+---");
            }

            Console.WriteLine("\n\n");
            Console.ResetColor();
        }

        static char CheckWin(char[,] mat)
        {
            char first = mat[0, 0];
            //row
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                first = mat[i, 0];
                int counter = 0;
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if (first == mat[i, j])
                        counter++;
                    if (counter == 3)
                        return mat[i, j];
                }
            }
            //coll

            for (int i = 0; i < mat.GetLength(0); i++)
            {
                first = mat[0, i];
                int counter = 0;

                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if (first == mat[j, i])
                        counter++;
                    if (counter == 3)
                        return mat[j, i];
                }
            }

            //diagnal
            int dcounter = 0;
            char dfirst = mat[0, 0];
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                if (dfirst == mat[i, i])
                    dcounter++;
                if (dcounter == 3)
                    return dfirst;
            }

            dcounter = 0;
            dfirst = mat[0, mat.GetLength(1) - 1];
            for (int i = mat.GetLength(1) - 1; i >= 0; i--)
            {

                if (first == mat[mat.GetLength(0) - 1 - i, i])
                    dcounter++;
                if (dcounter == 3)
                    return dfirst;
            }

            //game end
            for (int i = 0; i < mat.GetLength(0); i++)
                for (int j = 0; j < mat.GetLength(1); j++)
                    if (!char.IsLetter(mat[i, j]))
                        return '0';

            return 'E';
        }

        static void SelectMove(char turn, char[,] mat)
        {
            switch (turn)
            {
                case 'X':
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 'O':
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                default:
                    break;
            }
            Console.WriteLine($"\tIts {turn}'s Turn!");
            Console.ResetColor();
            Console.WriteLine("===============================");
        TakeInput:
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter your move: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            int slot = short.Parse(Console.ReadLine());
            Console.ResetColor();

            int j = slot % 3;
            int i = 2;
            if (slot < 3)
                i = 0;
            else if (slot < 6)
                i = 1;

            if (Char.IsLetter(mat[i, j]))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("WHAT ARE YOU DOING?!");
                Console.ResetColor();
                Console.WriteLine("please try again...\n");
                goto TakeInput;
            }
            mat[i, j] = turn;


        }

        static void RestartGame(char[,] mat)
        {
            char slot = '0';
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    mat[i, j] = slot;
                    slot++;
                }
            }
        }

        static void DeclareWinner(char[,] mat, char winner)
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("===================================");
            if (winner != 'E')
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\t WE HAVE A WINNER!");
                if (winner == 'X')
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\t {winner} HAS WON THE GAME");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("\t GAME ENDED IN A DRAW");
            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("===================================");


            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.ResetColor();
                    if (mat[i, j] == winner)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    Console.Write(" " + mat[i, j]);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    if (j < 2)
                        Console.Write(" |");
                }
                if (i < 2)
                    Console.WriteLine("\n---+---+---");
            }

            Console.WriteLine("\n\n");
            Console.ResetColor();

        }
    }
}


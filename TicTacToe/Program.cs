using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            //Set up 3x3 grid
            char[,] grid = new char[3, 3];
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    grid[x, y] = 'E';
                }
            }
            DrawGrid(grid);
            //Allow players to pick a marker
            Console.WriteLine("Player 1, Do you want to be X's or O's?");
            char player1 = Convert.ToChar(Console.ReadLine());
            char player2 = 'X';
            if (player1 == 'X')
            {
                player2 = 'O';
            }
            bool playing = true;

            while (playing == true)
            {
                if (playing == true)
                {
                    player1turn(player1, grid, 0, playing);
                    //Console.Clear(); //Will clear any out of date grids
                    DrawGrid(grid);
                    if (isWinPlayer1(grid, player1) == true)
                    {
                        Console.WriteLine("PLAYER 1 WINS!");
                        playing = false;
                        break;
                    }
                    else if (isFull(grid, playing) == false)
                    {
                        break;
                    }


                    if (playing == true)
                    {
                        player2turn(player2, grid, 0, playing, player1);
                        //Console.Clear(); //Will clear any out of date grids
                        DrawGrid(grid);
                        if (isWinPlayer2(grid, player2) == true)
                        {
                            Console.WriteLine("PLAYER 2 WINS!");
                            playing = false;
                            break;
                        }
                        if (isFull(grid, playing) == false)//Because the function isFull uses the playing 
                                                           //variable this is false and they would no longer be playing
                        {
                            break;
                        }
                    }
                }
            }

            Console.ReadKey();
        }
        static int[] DrawGrid(char[,] grid)
        {
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    Console.Write(grid[x, y]);
                    if (x < 2)
                    {
                        Console.Write(" | ");
                    }
                }
                Console.WriteLine();
                if (y < 2)
                {
                    Console.WriteLine("--+---+---");
                }
            }
            return null;
        }
        static void player1turn(char player1, char[,] grid, int playerchoice, bool playing)
        {
            Console.WriteLine("Player one you are " + player1 + " and it is your go!");
            Console.WriteLine("Which square do you want please enter a number 1 - 9.");
            playerchoice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(playerchoice);
            switch (playerchoice)
            {
                case (1):
                    if (grid[0, 0] != 'X' && grid[0, 0] != 'O')
                    {
                        grid[0, 0] = player1;
                    }
                    else
                    {
                        Console.WriteLine("Invaild move");
                        player1turn(player1, grid, playerchoice, playing);
                    }
                    return;
                case (2):
                    if (grid[1, 0] != 'X' && grid[1, 0] != 'O')
                    {
                        grid[1, 0] = player1;
                    }
                    else
                    {
                        Console.WriteLine("Invaild move");
                        player1turn(player1, grid, playerchoice, playing);
                    }
                    return;
                case (3):
                    if (grid[2, 0] != 'X' && grid[2, 0] != 'O')
                    {
                        grid[2, 0] = player1;
                    }
                    else
                    {
                        Console.WriteLine("Invaild move");
                        player1turn(player1, grid, playerchoice, playing);
                    }
                    return;
                case (4):
                    if (grid[0, 1] != 'X' && grid[0, 1] != 'O')
                    {
                        grid[0, 1] = player1;
                    }
                    else
                    {
                        Console.WriteLine("Invaild move");
                        player1turn(player1, grid, playerchoice, playing);
                    }
                    return;
                case (5):
                    if (grid[1, 1] != 'X' && grid[1, 1] != 'O')
                    {
                        grid[1, 1] = player1;
                    }
                    else
                    {
                        Console.WriteLine("Invaild move");
                        player1turn(player1, grid, playerchoice, playing);
                    }
                    return;
                case (6):
                    if (grid[2, 1] != 'X' && grid[2, 1] != 'O')
                    {
                        grid[2, 1] = player1;
                    }
                    else
                    {
                        Console.WriteLine("Invaild move");
                        player1turn(player1, grid, playerchoice, playing);
                    }
                    return;
                case (7):
                    if (grid[0, 2] != 'X' && grid[0, 2] != 'O')
                    {
                        grid[0, 2] = player1;
                    }
                    else
                    {
                        Console.WriteLine("Invaild move");
                        player1turn(player1, grid, playerchoice, playing);
                    }
                    return;
                case (8):
                    if (grid[1, 2] != 'X' && grid[1, 2] != 'O')
                    {
                        grid[1, 2] = player1;
                    }
                    else
                    {
                        Console.WriteLine("Invaild move");
                        player1turn(player1, grid, playerchoice, playing);
                    }
                    return;
                case (9):
                    if (grid[2, 2] != 'X' && grid[2, 2] != 'O')
                    {
                        grid[2, 2] = player1;
                    }
                    else
                    {
                        Console.WriteLine("Invaild move");
                        player1turn(player1, grid, playerchoice, playing);
                    }
                    return;
            }

        }
        static void player2turn(char player2, char[,] grid, int playerchoice, bool playing, char player1)
        {
            int[] move = findBestMove(grid, player2, player1);
            grid[move[0], move[1]] = player2;
            return;

        }
        /*static void player2turn(char player2, char[,] grid, int playerchoice, bool playing)
        {
            Console.WriteLine("Player two you are " + player2 + " and it is your go!");
            Console.WriteLine("Which square do you want please enter a number 1 - 9.");
            playerchoice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(playerchoice);
            switch (playerchoice)
            {
                case (1):
                    if (grid[0, 0] != 'X' && grid[0, 0] != 'O')
                    {
                        grid[0, 0] = player2;
                    }
                    else
                    {
                        Console.WriteLine("Invaild move");
                        player2turn(player2, grid, playerchoice, playing);
                    }
                    return;
                case (2):
                    if (grid[1, 0] != 'X' && grid[1, 0] != 'O')
                    {
                        grid[1, 0] = player2;
                    }
                    else
                    {
                        Console.WriteLine("Invaild move");
                        player2turn(player2, grid, playerchoice, playing);
                    }
                    return;
                case (3):
                    if (grid[2, 0] != 'X' && grid[2, 0] != 'O')
                    {
                        grid[2, 0] = player2;
                    }
                    else
                    {
                        Console.WriteLine("Invaild move");
                        player2turn(player2, grid, playerchoice, playing);
                    }
                    return;
                case (4):
                    if (grid[0, 1] != 'X' && grid[0, 1] != 'O')
                    {
                        grid[0, 1] = player2;
                    }
                    else
                    {
                        Console.WriteLine("Invaild move");
                        player2turn(player2, grid, playerchoice, playing);
                    }
                    return;
                case (5):
                    if (grid[1, 1] != 'X' && grid[1, 1] != 'O')
                    {
                        grid[1, 1] = player2;
                    }
                    else
                    {
                        Console.WriteLine("Invaild move");
                        player2turn(player2, grid, playerchoice, playing);
                    }
                    return;
                case (6):
                    if (grid[2, 1] != 'X' && grid[2, 1] != 'O')
                    {
                        grid[2, 1] = player2;
                    }
                    else
                    {
                        Console.WriteLine("Invaild move");
                        player2turn(player2, grid, playerchoice, playing);
                    }
                    return;
                case (7):
                    if (grid[0, 2] != 'X' && grid[0, 2] != 'O')
                    {
                        grid[0, 2] = player2;
                    }
                    else
                    {
                        Console.WriteLine("Invaild move");
                        player2turn(player2, grid, playerchoice, playing);
                    }
                    return;
                case (8):
                    if (grid[1, 2] != 'X' && grid[1, 2] != 'O')
                    {
                        grid[1, 2] = player2;
                    }
                    else
                    {
                        Console.WriteLine("Invaild move");
                        player2turn(player2, grid, playerchoice, playing);
                    }
                    return;
                case (9):
                    if (grid[2, 2] != 'X' && grid[2, 2] != 'O')
                    {
                        grid[2, 2] = player2;
                    }
                    else
                    {
                        Console.WriteLine("Invaild move");
                        player2turn(player2, grid, playerchoice, playing);
                    }
                    return;
            }

        }*/
        static bool isFull(char[,] grid, bool playing)
        {
            if (grid[0, 0] != 'E' && grid[1, 0] != 'E' && grid[2, 0] != 'E' && grid[0, 1] != 'E' &&
                grid[1, 1] != 'E' && grid[2, 1] != 'E' && grid[0, 2] != 'E' && grid[1, 2] != 'E'
                && grid[2, 2] != 'E')
            {
                Console.WriteLine("Grid full no more vaild moves");
                Console.WriteLine("IT'S A TIE!");
                playing = false;
            }
            return playing;
        }
        static bool isTie(char[,] grid)
        {
            bool tie = false;
            if (grid[0, 0] != 'E' && grid[1, 0] != 'E' && grid[2, 0] != 'E' && grid[0, 1] != 'E' &&
                grid[1, 1] != 'E' && grid[2, 1] != 'E' && grid[0, 2] != 'E' && grid[1, 2] != 'E'
                && grid[2, 2] != 'E')
            {
                tie = true;
            }
            return tie;
        }
        static bool isWinPlayer1(char[,] grid, char player1)
        {
            bool win = false;
            if ((grid[0, 0] == player1) && (grid[1, 0] == player1) && (grid[2, 0] == player1))
            { //First row win
                win = true;
                return win;
            }
            else if ((grid[0, 1] == player1) && (grid[1, 1] == player1) && (grid[2, 1] == player1))
            { //Second row win
                win = true;
                return win;
            }
            else if ((grid[0, 2] == player1) && (grid[1, 2] == player1) && (grid[2, 2] == player1))
            { //Third row win
                win = true;
                return win;
            }
            else if ((grid[0, 0] == player1) && (grid[0, 1] == player1) && (grid[0, 2] == player1))
            { //First column win
                win = true;
                return win;
            }
            else if ((grid[1, 0] == player1) && (grid[1, 1] == player1) && (grid[1, 2] == player1))
            { //Second column win
                win = true;
                return win;
            }
            else if ((grid[2, 0] == player1) && (grid[2, 1] == player1) && (grid[2, 2] == player1))
            { //Third column win
                win = true;
                return win;
            }
            else if ((grid[0, 0] == player1) && (grid[1, 1] == player1) && (grid[2, 2] == player1))
            { //First diagonal win
                win = true;
                return win;
            }
            else if ((grid[2, 0] == player1) && (grid[1, 1] == player1) && (grid[0, 2] == player1))
            { //Second diagonal win
                win = true;
                return win;
            }

            return win;
        }
        static bool isWinPlayer2(char[,] grid, char player2)
        {
            bool win = false;
            if ((grid[0, 0] == player2) && (grid[1, 0] == player2) && (grid[2, 0] == player2))
            { //First row win
                win = true;
                return win;
            }
            else if ((grid[0, 1] == player2) && (grid[1, 1] == player2) && (grid[2, 1] == player2))
            { //Second row win
                win = true;
                return win;
            }
            else if ((grid[0, 2] == player2) && (grid[1, 2] == player2) && (grid[2, 2] == player2))
            { //Third row win
                win = true;
                return win;
            }
            else if ((grid[0, 0] == player2) && (grid[0, 1] == player2) && (grid[0, 2] == player2))
            { //First column win
                win = true;
                return win;
            }
            else if ((grid[1, 0] == player2) && (grid[1, 1] == player2) && (grid[1, 2] == player2))
            { //Second column win
                win = true;
                return win;
            }
            else if ((grid[2, 0] == player2) && (grid[2, 1] == player2) && (grid[2, 2] == player2))
            { //Third column win
                win = true;
                return win;
            }
            else if ((grid[0, 0] == player2) && (grid[1, 1] == player2) && (grid[2, 2] == player2))
            { //First diagonal win
                win = true;
                return win;
            }
            else if ((grid[2, 0] == player2) && (grid[1, 1] == player2) && (grid[0, 2] == player2))
            { //Second diagonal win
                win = true;
                return win;
            }

            return win;
        }
        static int[] findBestMove(char[,] grid, char player2, char player1)
        {
            int bestscore = -10000;
            int[] bestMove = { 0, 0 };
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (grid[y, x] == 'E')
                    {
                        grid[y, x] = player2;
                        int score = minimax(grid, player1, player2, false);
                        if (score > bestscore)
                        {
                            bestscore = score;
                            bestMove[0] = y;
                            bestMove[1] = x;
                        }
                        grid[y, x] = 'E';
                    }
                }
            }
            return bestMove;
        }
        static int minimax(char[,] grid, char player1, char player2, bool isMaximisingPlayer)
        {
            if (isWinPlayer1(grid, player1))
            {
                return -1;
            }
            if (isWinPlayer2(grid, player2))
            {
                return 1;
            }
            if (isTie(grid))
            {
                return 0;
            }
            if (isMaximisingPlayer)
            {
                int bestscore = -10000;
                for (int y = 0; y < 3; y++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        if (grid[y, x] == 'E')
                        {
                            grid[y, x] = player2;
                            int score = minimax(grid, player1, player2, false);
                            if (score > bestscore)
                            {
                                bestscore = score;
                            }
                            grid[y, x] = 'E';
                        }
                    }
                }
                return bestscore;
            }
            if (!isMaximisingPlayer)
            {
                int bestscore = 10000;
                for (int y = 0; y < 3; y++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        if (grid[y, x] == 'E')
                        {
                            grid[y, x] = player1;
                            int score = minimax(grid, player1, player2, true);
                            if (score < bestscore)
                            {
                                bestscore = score;
                            }
                            grid[y, x] = 'E';
                        }
                    }
                }
                return bestscore;
            }
            return -10000;
        }
    }
}

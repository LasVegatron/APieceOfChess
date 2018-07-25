using System;

namespace APeiceOfChess
{
    public class Board
    {
        string team = "white";
        Piece[,] board = new Piece[8, 8];

        public void Move(int xPos, int yPos)
        {
            int input;
            int down = xPos + 1, up = xPos - 1;
            int right = yPos + 1, left = yPos - 1; 

            //stand-in for the selected piece
            Piece fake = board[xPos, yPos];
            //stand-in for new chosen position

            //Only testing white for now.
            //Check 2 positions for validity.
            if (board[xPos, yPos].Team() == team)
            {
                //User input.
                Piece newPos = null;
                input = Convert.ToInt32(Console.ReadKey().KeyChar);

                if ((input == 9) && (NumChecker(up, right) == true) && (board[up, right] != null || board[up, right].Team() != team))                
                    SwitchPos(ref newPos, ref fake, up, right, xPos, yPos);                
                else if (input == 7)                
                    SwitchPos(ref newPos, ref fake, up, left, xPos, yPos);                
                else if (input == 3)                
                    SwitchPos(ref newPos, ref fake, down, right, xPos, yPos);                
                else if (input == 1)                
                    SwitchPos(ref newPos, ref fake, down, left, xPos, yPos);                
                else                
                    Console.WriteLine("Invalid input");                
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
            //Next.
        }

        bool NumChecker(int i, int j)
        {
            //from 0 to 7
            if ((0 >= i && i >= 7) && (0 >= j && j >= 7))            
                return true;            
            else            
                return false;            
        }

        void SwitchPos(ref Piece newPos, ref Piece fake, int x, int y, int xPos, int yPos)
        {
            string result;

            newPos = board[x, y];

            newPos = fake;
            result = BlankGate(xPos, yPos);
            fake = new Blank(result);
        }

        /// <summary>
        /// Used to decide which kind of space the new blank will be.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        string BlankGate(int i, int j)
        {
            string output;
            if (((i == 0 | i == 2 | i == 4 | i == 6) && (j == 0 | j == 2 | j == 4 | j == 6)) || ((i == 1 | i == 3 | i == 5 | i == 7) && (j == 1 | j == 3 | j == 5 | j == 7)))
            {
                output = " ";
            }
            else
            {
                output = "0";
            }
            return output;
        }

        /// <summary>
        /// Initialises board.
        /// </summary>
        public void Init()
        {
            string result;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    result = BlankGate(i, j);
                    board[i, j] = new Blank(result);
                }
            }

            for (int j = 0; j < 3; j++)
            {
                int i, even = 0, odd = 1, state;
                if (j == 1)
                {
                    state = even;
                }
                else
                {
                    state = odd;
                }

                for (i = state; i < 8; i += 2)
                {
                    board[j, i] = new BlackPiece();
                }
            }

            for (int j = 0; j < 3; j++)
            {
                int k = j + 5;
                int i, even = 0, odd = 1, state;
                if (j == 1)
                {
                    state = odd;
                }
                else
                {
                    state = even;
                }

                for (i = state; i < 8; i += 2)
                {
                    board[k, i] = new WhitePiece();
                }
            }
        }

        /// <summary>
        /// Displays board.
        /// </summary>
        public void Print()
        {
            //per line
            for (int i = 0; i < 8; i++)
            {
                Console.Write("|");
                //per position/column
                for (int j = 0; j < 7; j++)
                {
                    Console.Write(":{0}:|", board[i, j].Face());
                }
                Console.WriteLine();
            }
        }
    }
}
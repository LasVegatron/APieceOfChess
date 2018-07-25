namespace APeiceOfChess
{
    public class Piece
    {
        //How the piece will be seen on the board
        public string face = "0";
        //Identifies what team the piece is a part of
        public bool teamWhite;

        public bool upRight = false;
        public bool upLeft = false;
        public bool downRight = false;
        public bool downLeft = false;

        public Piece()
        {
            face = "0";
        }

        public string Face()
        {
            return face;
        }

        public string Team()
        {
            string team;
            if (teamWhite == true)
            {
                team = "white";
            }
            else if (teamWhite == false)
            {
                team = "black";
            }
            else
            {
                team = "blank";
            }
            return team;
        }
    }

    public class Blank : Piece
    {
        public Blank(string input)
        {
            face = input;
        }
    }

    public class WhitePiece : Piece
    {
        public WhitePiece()
        {
            face = "w";
            teamWhite = true;
            upRight = true;
            upLeft = true;
        }
    }

    public class WhiteQueen : WhitePiece
    {
        public WhiteQueen()
        {
            face = "W";
            downRight = true;
            downLeft = true;
        }
    }

    public class BlackPiece : Piece
    {
        public BlackPiece()
        {
            face = "b";
            downRight = true;
            downLeft = true;
        }
    }

    public class BlackQueen : BlackPiece
    {
        public BlackQueen()
        {
            face = "B";
            upRight = true;
            upLeft = true;
        }
    }
}
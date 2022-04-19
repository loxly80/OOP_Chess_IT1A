using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Chess_IT1A
{
    public class Figure
    {
        private List<string> numbers = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8" };
        private List<string> letters = new List<string>() { "A", "B", "C", "D", "F", "G", "E", "H" };
        private string position;

        public FigureType Type { get; }
        public string Position
        {
            set
            {
                if (string.IsNullOrEmpty(value))    //hodnota v proměnné value je null nebo ""
                {
                    position = value;   //figura je mimo šachovnici
                }
                else if (value.Length == 2)
                {   //první znak v proměnné value je v listu letters a druhý znak  je v listu numbers
                    if (letters.Contains(value.Substring(0, 1).ToUpper()) && numbers.Contains(value.Substring(1, 1))) 
                    {
                        position = value;
                    }
                    else
                    {
                        throw new Exception("Figure position value has to be valid chess position!");
                    }
                }
                else
                {
                    throw new Exception("Figure position value has to be 2 letters valid chess position!");
                }
            }
            get => position;
        }
        public FigureColor Color { get; }

        public Figure(FigureType type,FigureColor color)
        {
            Type = type;
            Color = color;
        }

        public Figure(FigureType type, string position, FigureColor color)
        {
            Type = type;
            Position = position;
            Color = color;
        }

        public override string ToString()
        {
            //return Type.ToString().Substring(0,1) + Position.ToLower();
            return Color.ToString() + " " + Type.ToString() + " on " + Position;
        }
    }

    //výčtový datový typ - seznam hodnot - interně jsou to hodnoty integer (od 0)
    public enum FigureType
    {
        Pawn,       //pěšec
        Rook,       //věž
        Knight,     //jezdec
        Bishop,     //střelec
        Queen,      //dáma
        King        //král
    }

    public enum FigureColor
    {
        White,
        Black
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Chess_IT1A
{
    public class Figure
    {
        public FigureType Type { get; set; }

        public Figure()
        {
            
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
}

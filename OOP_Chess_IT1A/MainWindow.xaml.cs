﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OOP_Chess_IT1A
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<int,string> columns = new Dictionary<int,string>();
        Dictionary<int, string> rows = new Dictionary<int, string>();
        List<Figure> figures;

        public MainWindow()
        {
            InitializeComponent();
            figures = CreateFigures();
            CreateDictionaries();
            ShowTextChessBoard();
            CreateBoard();
            DrawFigures(figures);
        }

        private void DrawFigures(List<Figure> figures)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.HorizontalAlignment = HorizontalAlignment.Stretch;
            rectangle.VerticalAlignment = VerticalAlignment.Stretch;
            rectangle.Margin = new Thickness(5);
            rectangle.Fill = new ImageBrush(GetImage(Properties.Resources.WhiteQueen));
            
            Grid.SetColumn(rectangle, 0);
            Grid.SetRow(rectangle, 5);
            ChessBoardGrid.Children.Add(rectangle);
        }

        private ImageSource GetImage(byte[] resource)
        {
            MemoryStream memoryStream = new MemoryStream(resource);
            BitmapFrame bitmapFrame = BitmapFrame.Create(memoryStream);
            Image image = new Image();
            image.Source = bitmapFrame;
            return image.Source;
        }
        public void CreateDictionaries()
        {
            columns.Add(0, "A");
            columns.Add(1, "B");
            columns.Add(2, "C");
            columns.Add(3, "D");
            columns.Add(4, "E");
            columns.Add(5, "F");
            columns.Add(6, "G");
            columns.Add(7, "H");
            rows.Add(0, "8");
            rows.Add(1, "7");
            rows.Add(2, "6");
            rows.Add(3, "5");
            rows.Add(4, "4");
            rows.Add(5, "3");
            rows.Add(6, "2");
            rows.Add(7, "1");
        }

        public void ShowTextChessBoard()
        {
            lblBoard.Text = "";
            foreach (Figure figure in figures)
            {
                lblBoard.Text += figure.ToString() + "\n";
            }
        }

        public List<Figure> CreateFigures()
        {
            var figures = new List<Figure>();
            figures.Add(new Figure(FigureType.Rook, "A8", FigureColor.Black));
            figures.Add(new Figure(FigureType.Rook, "H8", FigureColor.Black));
            figures.Add(new Figure(FigureType.Knight, "B8", FigureColor.Black));
            figures.Add(new Figure(FigureType.Knight, "G8", FigureColor.Black));
            figures.Add(new Figure(FigureType.Bishop, "C8", FigureColor.Black));
            figures.Add(new Figure(FigureType.Bishop, "F8", FigureColor.Black));
            figures.Add(new Figure(FigureType.King, "E8", FigureColor.Black));
            figures.Add(new Figure(FigureType.Queen, "D8", FigureColor.Black));

            figures.Add(new Figure(FigureType.Pawn, "A7", FigureColor.Black));
            figures.Add(new Figure(FigureType.Pawn, "H7", FigureColor.Black));
            figures.Add(new Figure(FigureType.Pawn, "B7", FigureColor.Black));
            figures.Add(new Figure(FigureType.Pawn, "G7", FigureColor.Black));
            figures.Add(new Figure(FigureType.Pawn, "C7", FigureColor.Black));
            figures.Add(new Figure(FigureType.Pawn, "F7", FigureColor.Black));
            figures.Add(new Figure(FigureType.Pawn, "E7", FigureColor.Black));
            figures.Add(new Figure(FigureType.Pawn, "D7", FigureColor.Black));

            figures.Add(new Figure(FigureType.Rook, "A1", FigureColor.White));
            figures.Add(new Figure(FigureType.Rook, "H1", FigureColor.White));
            figures.Add(new Figure(FigureType.Knight, "B1", FigureColor.White));
            figures.Add(new Figure(FigureType.Knight, "G1", FigureColor.White));
            figures.Add(new Figure(FigureType.Bishop, "C1", FigureColor.White));
            figures.Add(new Figure(FigureType.Bishop, "F1", FigureColor.White));
            figures.Add(new Figure(FigureType.King, "E1", FigureColor.White));
            figures.Add(new Figure(FigureType.Queen, "D1", FigureColor.White));

            figures.Add(new Figure(FigureType.Pawn, "A2", FigureColor.White));
            figures.Add(new Figure(FigureType.Pawn, "H2", FigureColor.White));
            figures.Add(new Figure(FigureType.Pawn, "B2", FigureColor.White));
            figures.Add(new Figure(FigureType.Pawn, "G2", FigureColor.White));
            figures.Add(new Figure(FigureType.Pawn, "C2", FigureColor.White));
            figures.Add(new Figure(FigureType.Pawn, "F2", FigureColor.White));
            figures.Add(new Figure(FigureType.Pawn, "E2", FigureColor.White));
            figures.Add(new Figure(FigureType.Pawn, "D2", FigureColor.White));

            return figures;
        }

        public void CreateBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                ChessBoardGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                ChessBoardGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            }
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {

                    Rectangle rectangle = new Rectangle();
                    rectangle.Stroke = new SolidColorBrush(Colors.Black);
                    rectangle.StrokeThickness = 3;
                    rectangle.Margin = new Thickness(-1.5);
                    rectangle.HorizontalAlignment = HorizontalAlignment.Stretch;
                    rectangle.VerticalAlignment = VerticalAlignment.Stretch;
                    if ((x + y) % 2 == 0)
                    {
                        rectangle.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 128));
                    }
                    else
                    {
                        rectangle.Fill = new SolidColorBrush(Color.FromRgb(128, 64, 0));
                    }
                        

                    Grid.SetColumn(rectangle, x);
                    Grid.SetRow(rectangle, y);
                    ChessBoardGrid.Children.Add(rectangle);
                }
            }
        }
    }
}

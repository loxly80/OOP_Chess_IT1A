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
        Dictionary<string,int> columns = new Dictionary<string,int>();
        Dictionary<string,int> rows = new Dictionary<string,int>();
        List<Figure> figures;
        Figure selectedFigure;

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
            foreach(var figure in figures)
            {
                DrawFigure(figure);
            }
        }

        private void DrawFigure(Figure figure)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.HorizontalAlignment = HorizontalAlignment.Stretch;
            rectangle.VerticalAlignment = VerticalAlignment.Stretch;
            rectangle.Margin = new Thickness(5);
            rectangle.Fill = new ImageBrush(GetImage(figure.Resource));
            int indexCol = columns[figure.Position.Substring(0, 1)];
            int indexRow = rows[figure.Position.Substring(1, 1)];
            Grid.SetColumn(rectangle, indexCol);
            Grid.SetRow(rectangle, indexRow);
            ChessBoardGrid.Children.Add(rectangle);
            rectangle.Tag = figure;
            rectangle.MouseDown += Rectangle_MouseDown;
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle rectangle = (Rectangle)sender; //přetypování z object na Rectangle
            Figure figure = (Figure)rectangle.Tag;
            if(selectedFigure == null)
            {
                selectedFigure = figure;
                rectangle.Margin = new Thickness(0);
                rectangle.Stroke = new SolidColorBrush(Colors.Lime);
                rectangle.StrokeThickness = 5;
            }
            else if(selectedFigure == figure)
            {
                rectangle.StrokeThickness = 0;
                rectangle.Margin = new Thickness(5);
                selectedFigure = null;
            }
            else
            {

            }
            
            //MessageBox.Show($"Klik na {figure}");
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
            columns.Add("A",0);
            columns.Add("B",1);
            columns.Add("C",2);
            columns.Add("D",3);
            columns.Add("E",4);
            columns.Add("F",5);
            columns.Add("G",6);
            columns.Add("H",7);
            rows.Add("8",0);
            rows.Add("7",1);
            rows.Add("6",2);
            rows.Add("5",3);
            rows.Add("4",4);
            rows.Add("3",5);
            rows.Add("2",6);
            rows.Add("1",7);
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

        private void ChessBoardGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}

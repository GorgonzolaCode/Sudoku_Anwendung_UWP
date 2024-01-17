using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;



// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x407 dokumentiert.


namespace Sudoku_Anwendung
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        Sudoku sudoku;
        Button[,] buttons = new Button[9, 9];

        public MainPage()
        {
            sudoku = new Sudoku();
            sudoku.FullShuffle();

            this.InitializeComponent();

            this.ListButtons();
            this.ShowAllButtons();

            this.Loaded += AfterLoad;
        }



        private void ListButtons()
        {
            buttons[0, 0] = Cell_1_1;
            buttons[0, 1] = Cell_1_2;
            buttons[0, 2] = Cell_1_3;
            buttons[0, 3] = Cell_1_4;
            buttons[0, 4] = Cell_1_5;
            buttons[0, 5] = Cell_1_6;
            buttons[0, 6] = Cell_1_7;
            buttons[0, 7] = Cell_1_8;
            buttons[0, 8] = Cell_1_9;

            buttons[1, 0] = Cell_2_1;
            buttons[1, 1] = Cell_2_2;
            buttons[1, 2] = Cell_2_3;
            buttons[1, 3] = Cell_2_4;
            buttons[1, 4] = Cell_2_5;
            buttons[1, 5] = Cell_2_6;
            buttons[1, 6] = Cell_2_7;
            buttons[1, 7] = Cell_2_8;
            buttons[1, 8] = Cell_2_9;

            buttons[2, 0] = Cell_3_1;
            buttons[2, 1] = Cell_3_2;
            buttons[2, 2] = Cell_3_3;
            buttons[2, 3] = Cell_3_4;
            buttons[2, 4] = Cell_3_5;
            buttons[2, 5] = Cell_3_6;
            buttons[2, 6] = Cell_3_7;
            buttons[2, 7] = Cell_3_8;
            buttons[2, 8] = Cell_3_9;

            buttons[3, 0] = Cell_4_1;
            buttons[3, 1] = Cell_4_2;
            buttons[3, 2] = Cell_4_3;
            buttons[3, 3] = Cell_4_4;
            buttons[3, 4] = Cell_4_5;
            buttons[3, 5] = Cell_4_6;
            buttons[3, 6] = Cell_4_7;
            buttons[3, 7] = Cell_4_8;
            buttons[3, 8] = Cell_4_9;

            buttons[4, 0] = Cell_5_1;
            buttons[4, 1] = Cell_5_2;
            buttons[4, 2] = Cell_5_3;
            buttons[4, 3] = Cell_5_4;
            buttons[4, 4] = Cell_5_5;
            buttons[4, 5] = Cell_5_6;
            buttons[4, 6] = Cell_5_7;
            buttons[4, 7] = Cell_5_8;
            buttons[4, 8] = Cell_5_9;

            buttons[5, 0] = Cell_6_1;
            buttons[5, 1] = Cell_6_2;
            buttons[5, 2] = Cell_6_3;
            buttons[5, 3] = Cell_6_4;
            buttons[5, 4] = Cell_6_5;
            buttons[5, 5] = Cell_6_6;
            buttons[5, 6] = Cell_6_7;
            buttons[5, 7] = Cell_6_8;
            buttons[5, 8] = Cell_6_9;

            buttons[6, 0] = Cell_7_1;
            buttons[6, 1] = Cell_7_2;
            buttons[6, 2] = Cell_7_3;
            buttons[6, 3] = Cell_7_4;
            buttons[6, 4] = Cell_7_5;
            buttons[6, 5] = Cell_7_6;
            buttons[6, 6] = Cell_7_7;
            buttons[6, 7] = Cell_7_8;
            buttons[6, 8] = Cell_7_9;

            buttons[7, 0] = Cell_8_1;
            buttons[7, 1] = Cell_8_2;
            buttons[7, 2] = Cell_8_3;
            buttons[7, 3] = Cell_8_4;
            buttons[7, 4] = Cell_8_5;
            buttons[7, 5] = Cell_8_6;
            buttons[7, 6] = Cell_8_7;
            buttons[7, 7] = Cell_8_8;
            buttons[7, 8] = Cell_8_9;

            buttons[8, 0] = Cell_9_1;
            buttons[8, 1] = Cell_9_2;
            buttons[8, 2] = Cell_9_3;
            buttons[8, 3] = Cell_9_4;
            buttons[8, 4] = Cell_9_5;
            buttons[8, 5] = Cell_9_6;
            buttons[8, 6] = Cell_9_7;
            buttons[8, 7] = Cell_9_8;
            buttons[8, 8] = Cell_9_9;
        }




        private void ShowAllButtons()
        {
            for (int i = 0; i < buttons.GetLength(0); i++)
            {
                for (int j = 0; j < buttons.GetLength(1); j++)
                {
                    buttons[i, j].Content = sudoku.Get(j, i);
                }
            }
        }



        private void AfterLoad(object sender, RoutedEventArgs e)
        {
            textBox.Focus(FocusState.Programmatic);
        }



        private void Cell_Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string name = button.Name.ToString();


            string[] nameArray = name.Split("_");
            int row = (int)nameArray[1].First() - 49;
            int column = (int)nameArray[2].First() - 49;


            //use number in sudoku
            if (textBox.Text.Length == 1)
            {
                char tempChar = textBox.Text.First();

                if (Char.IsDigit(tempChar))
                {
                    int value = (int)tempChar - 48;
                    button.Content = value;
                    sudoku.Set(column, row, value);

                    //check sudoku
                    if (sudoku.IsCorrect()) textOut.Text = "";
                    else textOut.Text = "The sudoku has a contradiction.";
                }
            }
            

            //clear text box and set focus
            textBox.Text = "";
            textBox.Focus(FocusState.Programmatic);
        }




        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBox.Text = textBox.Text.LastOrDefault().ToString();
            textBox.Select(textBox.Text.Length, 0);
        }


    }
}

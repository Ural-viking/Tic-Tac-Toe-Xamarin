using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tic_Tac_Toe_Xamarin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class GamePage : ContentPage
{
        string PlayerXName = "";
        string PlayerOName = "";

        bool playerX = true;
        bool winnerBool = false;
        string winnerStr = "";

        int[,] array = new int[,]
        {
            { 0, 0, 0 },
            { 0, 0, 0 },
            { 0, 0, 0 }
        };
        private void CellClick(object sender, EventArgs e)
        {
                Button Cell = ((Button)sender);
                string name = Cell.StyleId;
                string x = name.Substring(4, 1);
                string y = name.Substring(5, 1);
                Cell.IsEnabled = false;
                if(playerX == true)
                {
                    array[int.Parse(x), int.Parse(y)] = 1;
                    Cell.BackgroundColor = Color.Green;
                    Cell.Text = "X";
                    check();
                    playerX = false;
                }
                else
                {
                    array[int.Parse(x), int.Parse(y)] = 2;
                    Cell.BackgroundColor = Color.Red;
                    Cell.Text = "O";
                    check();
                    playerX = true;
                }
         }
        public void check()
        {
            int turn = 0;
            if(playerX == true)
            {
                turn = 1;
                winnerStr = PlayerXName;
            }
            else
            {
                turn = 2;
                winnerStr = PlayerOName;

            }
            if(Cell00.IsEnabled == false 
                && Cell01.IsEnabled == false
                && Cell02.IsEnabled == false
                && Cell10.IsEnabled == false
                && Cell11.IsEnabled == false
                && Cell12.IsEnabled == false
                && Cell20.IsEnabled == false
                && Cell21.IsEnabled == false
                && Cell22.IsEnabled == false)
            {
                DisplayAlert("ВЫ ОЧЕНЬ СТАРАЛИСЬ", "НИЧЬЯ !!!", "ОК");
                winnerBool = true;
            }
            if (array[0, 0] == turn && array[0, 1] == turn && array[0, 2] == turn)
            {
                DisplayAlert("ПОБЕДИТЕЛЬ", "ИГРОК " + winnerStr, "OK");
                winnerBool = true;
            }
            if (array[1, 0] == turn && array[1, 1] == turn && array[1, 2] == turn)
            {
                DisplayAlert("ПОБЕДИТЕЛЬ", "ИГРОК " + winnerStr, "OK");
                winnerBool = true;
            }
            if (array[2, 0] == turn && array[2, 1] == turn && array[2, 2] == turn)
            {
                DisplayAlert("ПОБЕДИТЕЛЬ", "ИГРОК " + winnerStr, "OK");
                winnerBool = true;
            }
            if (array[0, 0] == turn && array[1, 0] == turn && array[2, 0] == turn)
            {
                DisplayAlert("ПОБЕДИТЕЛЬ", "ИГРОК " + winnerStr, "OK");
                winnerBool = true;
            }
            if (array[0, 1] == turn && array[1, 1] == turn && array[2, 1] == turn)
            {
                DisplayAlert("ПОБЕДИТЕЛЬ", "ИГРОК " + winnerStr, "OK");
                winnerBool = true;
            }
            if (array[0, 2] == turn && array[1, 2] == turn && array[2, 2] == turn)
            {
                DisplayAlert("ПОБЕДИТЕЛЬ", "ИГРОК " + winnerStr, "OK");
                winnerBool = true;
            }
            if (array[0, 2] == turn && array[1, 1] == turn && array[2, 0] == turn)
            {
                DisplayAlert("ПОБЕДИТЕЛЬ", "ИГРОК " + winnerStr, "OK");
                winnerBool = true;
            }
            if (array[0, 0] == turn && array[1, 1] == turn && array[2, 2] == turn)
            {
                DisplayAlert("ПОБЕДИТЕЛЬ", "ИГРОК " + winnerStr, "OK");
                winnerBool = true;
            }
            if (winnerBool == true)
            {
                Navigation.PushAsync(new GamePage(PlayerXName, PlayerOName));
            }
        }
        public GamePage(string playerXName, string playerOName)
        {
            InitializeComponent();
            this.PlayerXName = playerXName;
            this.PlayerOName = playerOName;
        }

        private async void BackParameteresPageClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ParametresPage());
        }
    }
}
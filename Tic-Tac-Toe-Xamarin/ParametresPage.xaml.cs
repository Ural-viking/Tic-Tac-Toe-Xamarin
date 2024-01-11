using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;
using System.Reflection;
using System.IO;

namespace Tic_Tac_Toe_Xamarin
{
    public partial class ParametresPage : ContentPage
    {
        int size = 0;

        private SelectTheme selectTheme;
        public ParametresPage()
        {
            InitializeComponent();
            BindingContext = selectTheme = new SelectTheme();
            
        }

        private async void BackMainPageClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
        private async void StartGameClick(object sender, EventArgs e)
        {
            string playerX = this.FindByName<Entry>("NamePlayerX").Text;
            string playerO = this.FindByName<Entry>("NamePlayerO").Text;

            if(size == 3)
            {
                await Navigation.PushAsync(new GamePage(playerX, playerO));
            }
            if(size == 4)
            {
                await Navigation.PushAsync(new GamePage4(playerX, playerO));
            }
            if (size == 5)
            {
                await Navigation.PushAsync(new GamePage5(playerX, playerO));
            }
            else if(size == 0)
            {
                await Navigation.PushAsync(new ParametresPage());
            }
        }

        private async void ChoiceSizeField (object sender, EventArgs e)
        {
            string choice = await DisplayActionSheet("Размер игрового поля", "Отмена", null, "3x3", "4x4", "5x5");

            switch (choice)
            {
                case "3x3":
                    size = 3;
                    break;
                case "4x4":
                    size = 4;
                    break;
                case "5x5":
                    size = 5;
                    break;
            }
        }

        void ChangeTheme(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            AllThemes.Themes theme = (AllThemes.Themes)picker.SelectedItem;

            selectTheme.SelectedTheme(theme);

        }
    }
}
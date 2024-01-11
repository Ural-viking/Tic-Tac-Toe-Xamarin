using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Reflection;
using System.IO;
using System.Collections.ObjectModel;
using System.Net;
using Newtonsoft.Json;

namespace Tic_Tac_Toe_Xamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            

        }

        private async void ButtonNewGameClick (object sender,EventArgs e)
        {
            await Navigation.PushAsync(new ParametresPage());
        }
        
    }
}

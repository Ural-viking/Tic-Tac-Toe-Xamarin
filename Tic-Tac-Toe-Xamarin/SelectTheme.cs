using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using Tic_Tac_Toe_Xamarin.Themes;

namespace Tic_Tac_Toe_Xamarin
{
    class SelectTheme
    {
        public IList<AllThemes.Themes> Themes { get; private set; }

        object savedTheme = "";

        private AllThemes.Themes selectedThemes;
        public AllThemes.Themes SelectedThemes 
        { 
            get 
                {
                    if(App.Current.Properties.TryGetValue("theme", out savedTheme))
                        {
                            selectedThemes = (AllThemes.Themes)savedTheme;
                        }
                    return selectedThemes; 
            }
            set 
            {
                if (App.Current.Properties.TryGetValue("theme", out savedTheme)) 
                {
                    App.Current.Properties["theme"] = value;
                }
                else
                {
                    App.Current.Properties.Add("theme", value);
                }
                selectedThemes = value; 
            } 
        }

        public SelectTheme()
        {
            Themes = new List<AllThemes.Themes>();
            Themes.Add(AllThemes.Themes.Light);
            Themes.Add(AllThemes.Themes.Classic);
            Themes.Add(AllThemes.Themes.Dark);
        }

        public void SelectedTheme(AllThemes.Themes theme)
        {
            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();

                switch (theme)
                {
                    case AllThemes.Themes.Dark:
                        mergedDictionaries.Add(new DarkTheme());
                        break;
                    case AllThemes.Themes.Light:
                        mergedDictionaries.Add(new LightTheme());
                        break;
                    case AllThemes.Themes.Classic:
                    default:
                        mergedDictionaries.Add(new ClassicTheme());
                        break;
                }
            }
        }
    }
}

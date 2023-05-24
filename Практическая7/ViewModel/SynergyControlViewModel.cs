using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Практическая7.Model;
using Практическая7.ViewModel.Helpers;

namespace Практическая7.ViewModel
{
    internal class SynergyControlViewModel : BindingHelper
    {
        private string label;
        public string Label 
        { 
            get
            {
                return label;
            }
            set
            {
                label = value;
                OnPropertyChanged();
            }
        }

        private string effect;
        public string Effect
        {
            get
            {
                return effect;
            }
            set
            {
                effect = value;
                OnPropertyChanged();
            }
        }
        private BitmapImage icon;
        public BitmapImage Icon
        {
            get { return icon; }
            set
            {
                icon = value;
                OnPropertyChanged();
            }
        }
        public SynergyControlViewModel(ChampionClass championClass, int count)
        {
            Label = $"{championClass.name} ({count})";

            string effect = "Нет эффектов";
            foreach (var buff in championClass.buffs)
            {
                if (buff.championsCount <= count)
                {
                    effect = $"({buff.championsCount}) {buff.description}";
                }
                else
                {
                    break;
                }
            }

            Effect = effect;
            Icon = new BitmapImage(new Uri(championClass.icon, UriKind.Relative));
        }
    }
}

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
    internal class ChampionControlViewModel : BindingHelper
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
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

        public ChampionControlViewModel(Champion champion)
        {
            Name = champion.name;
            Icon = new BitmapImage(new Uri(champion.icon, UriKind.Relative));
        }
    }
}

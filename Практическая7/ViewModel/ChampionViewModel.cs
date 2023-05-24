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
    internal class ChampionViewModel : BindingHelper
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

        private string classes;
        public string Classes
        {
            get { return classes; }
            set
            {
                classes = value; 
                OnPropertyChanged();
            }
        }

        private int cost;
        public int Cost
        {
            get { return cost; }
            set
            {
                cost = value;
                OnPropertyChanged();
            }
        }
        private string ult;
        public string Ult
        {
            get { return ult; }
            set
            {
                ult = value;
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

        public ChampionViewModel(Champion champion)
        {
            Name = champion.name;
            string classes = "";
            foreach (var className in champion.classesNames)
            {
                classes += $"{className}, ";
            }
            Classes = classes.Remove(classes.Length - 2);
            Cost = champion.cost;
            Ult = champion.ultDescription;
            Icon = new BitmapImage(new Uri(champion.icon, UriKind.Relative));
        }
    }
}

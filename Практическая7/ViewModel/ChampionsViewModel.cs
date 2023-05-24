using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Практическая7.Model;
using Практическая7.View;
using Практическая7.ViewModel.Helpers;

namespace Практическая7.ViewModel
{
    internal class ChampionsViewModel : BindingHelper
    {
        private List<Champion> champions_list;
        private ObservableCollection<ChampionControl> champions;
        public ObservableCollection<ChampionControl> Champions
        {
            get { return champions; }
            set
            {
                champions = value;
                OnPropertyChanged();
            }
        }

        private int selected;
        public int Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged();
            }
        }

        public BindableCommand OpenChampionWindow { get; set; }

        public ChampionsViewModel()
        {
            champions_list = Serializer.Load<List<Champion>>("Data/champions.json");
            if (champions_list == null)
            {
                champions_list = new List<Champion>();
            }

            Champions = new ObservableCollection<ChampionControl>();
            foreach (var champion in champions_list)
            {
                ChampionControl championControl = new ChampionControl(champion);
                Champions.Add(championControl);
            }

            Selected = -1;
            OpenChampionWindow = new BindableCommand(_ => ShowChampion());
        }

        public void ShowChampion()
        {
            if (Selected == -1)
            {
                return;
            }

            Champion champion = champions_list[Selected];
            ChampionWindow window = new ChampionWindow(champion);
            window.ShowDialog();
            Selected = -1;
        }
    }
}

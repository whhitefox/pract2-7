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
    internal class TeamViewModel : BindingHelper
    {
        private List<ChampionClass> classes;
        private List<Champion> allChampions;
        private List<Champion> teamChampions;

        private ObservableCollection<ChampionLineControl> allChampionsViews;
        public ObservableCollection<ChampionLineControl> AllChampionsViews
        {
            get
            {
                return allChampionsViews;
            }
            set
            {
                allChampionsViews = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<ChampionLineControl> teamChampionsViews;
        public ObservableCollection<ChampionLineControl> TeamChampionsViews
        {
            get
            {
                return teamChampionsViews;
            }
            set
            {
                teamChampionsViews = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<SynergyControl> synergies;
        public ObservableCollection<SynergyControl> Synergies
        {
            get
            {
                return synergies;
            }
            set
            {
                synergies = value;
                OnPropertyChanged();
            }
        }


        private int allSelected;
        public int AllSelected
        {
            get
            {
                return allSelected;
            }
            set
            {
                allSelected = value;
                OnPropertyChanged();
            }
        }

        private int teamSelected;
        public int TeamSelected
        {
            get
            {
                return teamSelected;
            }
            set
            {
                teamSelected = value;
                OnPropertyChanged();
            }
        }

        public BindableCommand AddChampionCommand { get; set; }
        public BindableCommand RemoveChampionCommand { get; set; }

        public TeamViewModel()
        {
            allChampions = Serializer.Load<List<Champion>>("Data/champions.json");
            classes = Serializer.Load<List<ChampionClass>>("Data/classes.json");
            teamChampions = new List<Champion>();

            AllChampionsViews = new ObservableCollection<ChampionLineControl>();
            TeamChampionsViews = new ObservableCollection<ChampionLineControl>();
            Synergies = new ObservableCollection<SynergyControl>();

            AllSelected = -1;
            TeamSelected = -1;

            AddChampionCommand = new BindableCommand(_ => AddChampion());
            RemoveChampionCommand = new BindableCommand(_ => RemoveChampion());

            UpdateChampionsViews();
        }

        public void AddChampion()
        {
            if (AllSelected == -1)
            {
                return;
            }
            if (teamChampions.Count >= 9)
            {
                return;
            }

            Champion champion = allChampions[AllSelected];
            teamChampions.Add(champion);
            allChampions.Remove(champion);

            AllSelected = -1;
            TeamSelected = -1;

            UpdateChampionsViews();
            CalculateSynergy();
        }

        public void RemoveChampion()
        {
            if (TeamSelected == -1)
            {
                return;
            }

            Champion champion = teamChampions[TeamSelected];
            allChampions.Add(champion);
            teamChampions.Remove(champion);

            AllSelected = -1;
            TeamSelected = -1;

            UpdateChampionsViews();
            CalculateSynergy();
        }

        private void UpdateChampionsViews()
        {
            AllChampionsViews.Clear();
            TeamChampionsViews.Clear();

            allChampions = allChampions.OrderBy(ch => ch.name).ToList();
            teamChampions = teamChampions.OrderBy(ch => ch.name).ToList();

            foreach (var champion in allChampions)
            {
                ChampionLineControl ch = new ChampionLineControl(champion);
                AllChampionsViews.Add(ch);
            }

            foreach (var champion in teamChampions)
            {
                ChampionLineControl ch = new ChampionLineControl(champion);
                TeamChampionsViews.Add(ch);
            }
        }

        private void CalculateSynergy()
        {
            Synergies.Clear();
            foreach (var championClass in classes)
            {
                List<Champion> champions = teamChampions.FindAll(ch => ch.classesNames.Contains(championClass.name));
                if (champions.Count == 0)
                {
                    continue;
                }

                SynergyControl synergy = new SynergyControl(championClass, champions.Count);
                Synergies.Add(synergy);
            }
        }
    }
}

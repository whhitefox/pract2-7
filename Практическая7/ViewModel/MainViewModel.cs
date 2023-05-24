using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Практическая7.View;
using Практическая7.ViewModel.Helpers;

namespace Практическая7.ViewModel
{
    internal class MainViewModel : BindingHelper
    {
        private Page selected;
        public Page Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged();
            }
        }

        public BindableCommand OpenChampionsPage { get; set; }
        public BindableCommand OpenTeamPage { get; set; }

        public MainViewModel()
        {
            Selected = new ChampionsPage();
            OpenChampionsPage = new BindableCommand(_ => CreateChampionsPage());
            OpenTeamPage = new BindableCommand(_ => CreateTeamPage());
        }

        public void CreateChampionsPage()
        {
            if (Selected.Title == "ChampionsPage")
            {
                return;
            }

            Selected = new ChampionsPage();
        }

        public void CreateTeamPage()
        {
            if (Selected.Title == "TeamPage")
            {
                return;
            }

            Selected = new TeamPage();
        }
    }
}

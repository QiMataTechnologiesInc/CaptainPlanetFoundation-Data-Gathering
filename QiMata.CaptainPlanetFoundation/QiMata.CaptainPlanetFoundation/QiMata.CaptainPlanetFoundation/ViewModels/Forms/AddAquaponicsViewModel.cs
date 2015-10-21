using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QiMata.CaptainPlanetFoundation.Models;
using QiMata.CaptainPlanetFoundation.ViewModels.Partials;
using Xamarin.Forms;

namespace QiMata.CaptainPlanetFoundation.ViewModels.Forms
{
    class AddAquaponicsViewModel : BaseFormViewModel
    {
        private readonly AquaponicProject _aquaponicProject;

        public AddAquaponicsViewModel()
        {
            _aquaponicProject = new AquaponicProject
            {
                ProjectBase = new ProjectBase()
            };

            ProjectBasePartial = new ProjectBasePartialViewModel(_aquaponicProject.ProjectBase);

            TypeSelectedIndex = -1;
            UseOfHarestIndex = -1;
        }

        public ProjectBasePartialViewModel ProjectBasePartial { get; private set; }

        public int TypeSelectedIndex { get; set; }

        public string SizeOfProject { get; set; }

        public bool Harvested
        {
            get { return _aquaponicProject.Harvested; }
            set
            {
                _aquaponicProject.Harvested = value;
                base.OnPropertyChanged();
            }
        }

        public int UseOfHarestIndex { get; set; }

        private Command _submitCommand;

        public Command SubmitCommand
        {
            get { return _submitCommand ?? (_submitCommand = new Command(() => { })); }
        }
    }
}

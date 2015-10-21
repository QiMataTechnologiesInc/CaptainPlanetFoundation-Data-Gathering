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
    class AddReforestationViewModel : BaseFormViewModel
    {
        private readonly Reforestation _reforestation;

        public AddReforestationViewModel()
        {
            _reforestation = new Reforestation
            {
                ProjectBase = new ProjectBase()
            };

            ProjectBasePartial = new ProjectBasePartialViewModel(_reforestation.ProjectBase);
            AreaOfTreesUnitsIndex = -1;
        }


        public ProjectBasePartialViewModel ProjectBasePartial { get; private set; }

        public string NumberOfTreesPlanted { get; set; }

        public string AreaOfTreesPlanted { get; set; }

        public int AreaOfTreesUnitsIndex { get; set; }

        private Command _submitCommand;

        public Command SubmitCommand
        {
            get { return _submitCommand ?? (_submitCommand = new Command(() => { })); }
        }
    }    
}


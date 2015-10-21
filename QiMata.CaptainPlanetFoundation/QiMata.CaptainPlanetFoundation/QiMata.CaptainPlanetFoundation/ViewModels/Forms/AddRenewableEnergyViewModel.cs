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
    class AddRenewableEnergyViewModel : BaseFormViewModel
    {
        private readonly RenewableEnergy _renewableEnergy;

        public AddRenewableEnergyViewModel()
        {
            _renewableEnergy = new RenewableEnergy
            {
                ProjectBase = new ProjectBase()
            };

            ProjectBasePartial = new ProjectBasePartialViewModel(_renewableEnergy.ProjectBase);
        }

        public ProjectBasePartialViewModel ProjectBasePartial { get; private set; }

        public string TypeOfEnergy {
            get { return _renewableEnergy.TypeOfEnergy; }
            set { _renewableEnergy.TypeOfEnergy = value; } }

        private Command _submitCommand;

        public Command SubmitCommand
        {
            get { return _submitCommand ?? (_submitCommand = new Command(() => { })); }
        }
    }
}

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
    class AddPollinatorGardenViewModel : BaseFormViewModel
    {
        private PollinatorGarden _pollinatorGarden;

        public AddPollinatorGardenViewModel()
        {
            _pollinatorGarden = new PollinatorGarden
            {
                ProjectBase = new ProjectBase()
            };

            ProjectBasePartial = new ProjectBasePartialViewModel(_pollinatorGarden.ProjectBase);
        }

        public ProjectBasePartialViewModel ProjectBasePartial { get; private set; }

        public string GardenSize { get; set; }

        public string GardenLocation => _pollinatorGarden.GardentLocation;

        private Command _submitCommand;

        public Command SubmitCommand
        {
            get { return _submitCommand ?? (_submitCommand = new Command(() => { })); }
        }
    }
}

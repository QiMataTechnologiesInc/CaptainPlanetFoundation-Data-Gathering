using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QiMata.CaptainPlanetFoundation.Helpers;
using QiMata.CaptainPlanetFoundation.Models;
using QiMata.CaptainPlanetFoundation.ViewModels.Partials;
using QiMata.CaptainPlanetFoundation.Views;
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

        public string GardenLocation {
            get { return _pollinatorGarden.GardentLocation; }
            set { _pollinatorGarden.GardentLocation = value; }
        }

        private Command _submitCommand;

        public Command SubmitCommand
        {
            get { return _submitCommand ?? (_submitCommand = new Command(async () =>
            {
                FormErrors.Clear();
                ProjectBasePartial.FormErrors.Clear();
                var projectPartialSuccess = ProjectBasePartial.Submit();
                if (!projectPartialSuccess)
                {
                    foreach (string formError in ProjectBasePartial.FormErrors)
                    {
                        FormErrors.Add(formError);
                    }
                }
                if (String.IsNullOrEmpty(GardenLocation) || String.IsNullOrWhiteSpace(GardenLocation))
                {
                    FormErrors.Add("Please state the location of the garden");
                }
                if (String.IsNullOrEmpty(GardenSize) || String.IsNullOrWhiteSpace(GardenSize))
                {
                    FormErrors.Add("Please state the size of the garden");
                }
                else
                {
                    int sizeOfHarvest = 0;
                    bool parseSuccess = Int32.TryParse(GardenSize, out sizeOfHarvest);
                    if (parseSuccess)
                    {
                        _pollinatorGarden.GardenSize = sizeOfHarvest;
                    }
                    else
                    {
                        FormErrors.Add("Square feet must be a whole number");
                    }
                }

                if (!FormErrors.Any())
                {
                    _pollinatorGarden =
                        await HttpClientHelper.Post(Constants.BaseApiClientUrl, "api/pollinatorgardens", _pollinatorGarden);
                    ViewLocater.Default.ChangeDetail(new PollinatorGardenPage());
                }
            })); }
        }
    }
}

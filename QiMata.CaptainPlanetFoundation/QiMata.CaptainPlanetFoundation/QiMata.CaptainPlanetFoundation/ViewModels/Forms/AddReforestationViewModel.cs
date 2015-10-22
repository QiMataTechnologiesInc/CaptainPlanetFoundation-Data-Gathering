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
    class AddReforestationViewModel : BaseFormViewModel
    {
        private Reforestation _reforestation;

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
                if (String.IsNullOrEmpty(NumberOfTreesPlanted) || String.IsNullOrWhiteSpace(NumberOfTreesPlanted))
                {
                    FormErrors.Add("Number of trees planed required");
                }
                else
                {
                    int sizeOfHarvest = 0;
                    bool parseSuccess = Int32.TryParse(NumberOfTreesPlanted, out sizeOfHarvest);
                    if (parseSuccess)
                    {
                        _reforestation.NumberOfTreesPlanted = sizeOfHarvest;
                    }
                    else
                    {
                        FormErrors.Add("Number of trees planted must be a whole number");
                    }
                }
                if (String.IsNullOrEmpty(AreaOfTreesPlanted) || String.IsNullOrWhiteSpace(AreaOfTreesPlanted))
                {
                    FormErrors.Add("Please state the area of trees");
                }
                else
                {
                    int sizeOfHarvest = 0;
                    bool parseSuccess = Int32.TryParse(AreaOfTreesPlanted, out sizeOfHarvest);
                    if (parseSuccess)
                    {
                        _reforestation.AreaOfTrees = sizeOfHarvest;
                    }
                    else
                    {
                        FormErrors.Add("Area must be a whole number");
                    }
                }
                if (AreaOfTreesUnitsIndex == -1)
                {
                    FormErrors.Add("Please select the area units");
                }
                else
                {
                    if (AreaOfTreesUnitsIndex == 0)
                    {
                        _reforestation.AreaOfTreesUnits = "Square Feet";
                    }
                    else if (AreaOfTreesUnitsIndex == 1)
                    {
                        _reforestation.AreaOfTreesUnits = "Acres";
                    }
                }
                if (!FormErrors.Any())
                {
                    _reforestation =
                        await HttpClientHelper.Post(Constants.BaseApiClientUrl, "api/reforestations", _reforestation);
                    ViewLocater.Default.ChangeDetail(new ReforestationPage());
                }
            })); }
        }
    }    
}


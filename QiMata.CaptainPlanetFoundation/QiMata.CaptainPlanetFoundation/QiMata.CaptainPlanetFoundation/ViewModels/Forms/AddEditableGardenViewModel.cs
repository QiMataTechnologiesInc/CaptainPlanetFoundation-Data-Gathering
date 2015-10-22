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
    class AddEditableGardenViewModel : BaseFormViewModel
    {
        private EditableGarden _editableGarden;
        private readonly ProjectBasePartialViewModel _projectBasePartial;

        public AddEditableGardenViewModel()
        {
            _editableGarden = new EditableGarden
            {
                ProjectBase =  new ProjectBase()
            };

            _projectBasePartial = new ProjectBasePartialViewModel(_editableGarden.ProjectBase);
            UseOfHarvestIndex = -1;
        }

        public ProjectBasePartialViewModel ProjectBasePartial
        {
            get
            {
                return _projectBasePartial;
            }
        }

        public string SizeOfGarden { get; set; }

        public int UseOfHarvestIndex { get; set; }

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
                if (UseOfHarvestIndex == -1)
                {
                    FormErrors.Add("Please select the use of the harvest");
                }
                else
                {
                    if (UseOfHarvestIndex == 0)
                    {
                        _editableGarden.UseOfHarvest = "Classroom tastings";
                    }
                    else if (UseOfHarvestIndex == 1)
                    {
                        _editableGarden.UseOfHarvest = "Cafeteria";
                    }
                    else if (UseOfHarvestIndex == 2)
                    {
                        _editableGarden.UseOfHarvest = "Food Pantries or Food Bank";
                    }
                    else if (UseOfHarvestIndex == 3)
                    {
                        _editableGarden.UseOfHarvest = "School staff & families";
                    }
                }
                if (String.IsNullOrEmpty(SizeOfGarden) || String.IsNullOrWhiteSpace(SizeOfGarden))
                {
                    FormErrors.Add("Please state the size of the garden");
                }
                else
                {
                    int sizeOfHarvest = 0;
                    bool parseSuccess = Int32.TryParse(SizeOfGarden, out sizeOfHarvest);
                    if (parseSuccess)
                    {
                        _editableGarden.SquareFeet = sizeOfHarvest;
                    }
                    else
                    {
                        FormErrors.Add("Square feet must be a whole number");
                    }
                }
                if (!FormErrors.Any())
                {
                    _editableGarden =
                        await HttpClientHelper.Post(Constants.BaseApiClientUrl, "api/editablegardens", _editableGarden);
                    ViewLocater.Default.ChangeDetail(new EdibleGardensPage());
                }
            })); }
        }
    }
}

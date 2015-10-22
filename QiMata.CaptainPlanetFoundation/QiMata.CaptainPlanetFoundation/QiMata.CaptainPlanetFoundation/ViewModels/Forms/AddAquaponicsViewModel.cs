using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using QiMata.CaptainPlanetFoundation.Helpers;
using QiMata.CaptainPlanetFoundation.Models;
using QiMata.CaptainPlanetFoundation.ViewModels.Partials;
using QiMata.CaptainPlanetFoundation.Views;
using Xamarin.Forms;

namespace QiMata.CaptainPlanetFoundation.ViewModels.Forms
{
    class AddAquaponicsViewModel : BaseFormViewModel
    {
        private AquaponicProject _aquaponicProject;

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
            get
            {
                return _submitCommand ?? (_submitCommand = new Command(async () =>
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
                    if (TypeSelectedIndex == -1)
                    {
                        FormErrors.Add("Must select a type of Aquapoincs project");
                    }
                    else
                    {
                        if (TypeSelectedIndex == 0)
                        {
                            _aquaponicProject.Type = "Fish";
                        }
                        else if (TypeSelectedIndex == 1)
                        {
                            _aquaponicProject.Type = "Plants";
                        }
                    }
                    if (String.IsNullOrEmpty(SizeOfProject) || String.IsNullOrWhiteSpace(SizeOfProject))
                    {
                        if (TypeSelectedIndex == -1)
                        {
                            FormErrors.Add("Please state the size of the project");
                        }
                        else if (TypeSelectedIndex == 0)
                        {
                            FormErrors.Add("Please state the size of the project (Gallons)");
                        }
                        else if (TypeSelectedIndex == 1)
                        {
                            FormErrors.Add("Please state the size of the project (Square Feet)");
                        }
                    }
                    else
                    {
                        int sizeOfHarvest = 0;
                        bool parseSuccess = Int32.TryParse(SizeOfProject, out sizeOfHarvest);
                        if (parseSuccess)
                        {
                            _aquaponicProject.SizeOfHarvest = sizeOfHarvest;
                        }
                        else
                        {
                            FormErrors.Add("Size of Harvest must be a whole number");
                        }
                    }
                    if (Harvested && UseOfHarestIndex == -1)
                    {
                        FormErrors.Add("Please select the use of the harvest");
                    }
                    else
                    {
                        if (UseOfHarestIndex == 0)
                        {
                            _aquaponicProject.UseOfHarvest = "Classroom tastings";
                        }
                        else if (UseOfHarestIndex == 1)
                        {
                            _aquaponicProject.UseOfHarvest = "Cafeteria";
                        }
                        else if (UseOfHarestIndex == 2)
                        {
                            _aquaponicProject.UseOfHarvest = "Food Pantries or Food Bank";
                        }
                        else if (UseOfHarestIndex == 3)
                        {
                            _aquaponicProject.UseOfHarvest = "School staff & families";
                        }
                    }
                    if (!FormErrors.Any())
                    {
                        _aquaponicProject =
                            await HttpClientHelper.Post(Constants.BaseApiClientUrl, "api/aquaponicprojects",_aquaponicProject);
                        ViewLocater.Default.ChangeDetail(new AquaponicsPage());
                    }
                }));
            }
        }
    }
}

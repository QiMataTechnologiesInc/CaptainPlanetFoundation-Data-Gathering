using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QiMata.CaptainPlanetFoundation.Client;
using QiMata.CaptainPlanetFoundation.Models;
using QiMata.CaptainPlanetFoundation.ViewModels.Partials;
using QiMata.CaptainPlanetFoundation.Views;
using Xamarin.Forms;

namespace QiMata.CaptainPlanetFoundation.ViewModels.Forms
{
    class AddHabitatRestorationViewModel : BaseFormViewModel
    {
        private HabitatRestoration _habitatRestoration;
        private readonly Client.HabitatRestorationClient _habitatRestorationClient;

        public AddHabitatRestorationViewModel()
        {
            _habitatRestorationClient = new HabitatRestorationClient();

            _habitatRestoration = new HabitatRestoration
            {
                ProjectBase = new ProjectBase()
            };

            ProjectBasePartial = new ProjectBasePartialViewModel(_habitatRestoration.ProjectBase);
            UnitsSelectedIndex = -1;
            RestoredOrAddedIndex = -1;
            TypeOfRestorationIndex = -1;
        }

        public ProjectBasePartialViewModel ProjectBasePartial { get; private set; }

        public int UnitsSelectedIndex { get; set; }

        public int RestoredOrAddedIndex { get; set; }

        public int TypeOfRestorationIndex { get; set; }

        public string TotalAreaRestored { get; set; }

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
                    if (UnitsSelectedIndex == -1)
                    {
                        FormErrors.Add("Please select units for total area restored");
                    }
                    else
                    {
                        if (UnitsSelectedIndex == 0)
                        {
                            _habitatRestoration.UnitsOfRestoration = "Square Feet";
                        }
                        else
                        {
                            _habitatRestoration.UnitsOfRestoration = "Acres";
                        }
                    }
                    if (RestoredOrAddedIndex == -1)
                    {
                        FormErrors.Add("Please select whether the restoration was Restored or Added");
                    }
                    else
                    {
                        if (RestoredOrAddedIndex == 0)
                        {
                            _habitatRestoration.AddedOrRestored = "Restored";
                        }
                        else
                        {
                            _habitatRestoration.AddedOrRestored = "Added";
                        }
                    }
                    if (TypeOfRestorationIndex == -1)
                    {
                        FormErrors.Add("Please select the type of restoration");
                    }
                    else
                    {
                        switch (TypeOfRestorationIndex)
                        {
                            case 0:
                                _habitatRestoration.RestorationType = "Water Source";
                                break;
                            case 1:
                                _habitatRestoration.RestorationType = "Shelter";
                                break;
                            case 2:
                                _habitatRestoration.RestorationType = "Food";
                                break;
                            case 3:
                                _habitatRestoration.RestorationType = "Removal of Invasive Species";
                                break;
                        }
                    }
                    if (String.IsNullOrWhiteSpace(TotalAreaRestored) || String.IsNullOrEmpty(TotalAreaRestored))
                    {
                        FormErrors.Add("Total Area Restored is required");
                    }
                    else
                    {
                        int totalAreaPlaceHolder = 0;
                        bool parseSuccess = Int32.TryParse(TotalAreaRestored, out totalAreaPlaceHolder);
                        if (parseSuccess)
                        {
                            _habitatRestoration.TotalAreaRestored = totalAreaPlaceHolder;
                        }
                        else
                        {
                            FormErrors.Add("Total Area Restored must be a whole number");
                        }
                    }
                    if (!FormErrors.Any())
                    {
                        _habitatRestoration =
                            await _habitatRestorationClient.PostHabitatRestoration(_habitatRestoration);
                        ViewLocater.Default.ChangeDetail(new HabitatRestorationPage());
                    }
                }));
            }
        }
    }
}

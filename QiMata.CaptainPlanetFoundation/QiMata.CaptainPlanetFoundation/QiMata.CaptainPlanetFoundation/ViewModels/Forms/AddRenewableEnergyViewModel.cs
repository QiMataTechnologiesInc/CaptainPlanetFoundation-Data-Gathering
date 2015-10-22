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
    class AddRenewableEnergyViewModel : BaseFormViewModel
    {
        private RenewableEnergy _renewableEnergy;

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
                if (String.IsNullOrEmpty(TypeOfEnergy) || String.IsNullOrWhiteSpace(TypeOfEnergy))
                {
                    FormErrors.Add("Type of energy required");
                }
                if (!FormErrors.Any())
                {
                    _renewableEnergy =
                        await HttpClientHelper.Post(Constants.BaseApiClientUrl, "api/renewableenergies", _renewableEnergy);
                    ViewLocater.Default.ChangeDetail(new RenewableEnergyPage());
                }
            })); }
        }
    }
}

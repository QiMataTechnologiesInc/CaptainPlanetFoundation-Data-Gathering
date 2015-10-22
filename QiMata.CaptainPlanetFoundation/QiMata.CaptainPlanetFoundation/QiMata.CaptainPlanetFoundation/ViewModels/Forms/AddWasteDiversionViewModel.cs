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
    class AddWasteDiversionViewModel : BaseFormViewModel
    {
        private WasteDiversion _wasteDiversion;

        public AddWasteDiversionViewModel()
        {
            _wasteDiversion = new WasteDiversion
            {
                ProjectBase = new ProjectBase()
            };

            ProjectBasePartial = new ProjectBasePartialViewModel(_wasteDiversion.ProjectBase);
            UnitsSelectedIndex = -1;
        }

        public ProjectBasePartialViewModel ProjectBasePartial { get; private set; }

        public string AmountDiverted { get; set; }

        public int UnitsSelectedIndex { get; set; }

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
                if (String.IsNullOrEmpty(AmountDiverted) || String.IsNullOrWhiteSpace(AmountDiverted))
                {
                    FormErrors.Add("Amount of waste diverted is required");
                }
                else
                {
                    decimal amountDiverted = 0;
                    var success = Decimal.TryParse(AmountDiverted, out amountDiverted);
                    if (success)
                    {
                        _wasteDiversion.AmountDiverted = amountDiverted;
                    }
                    else
                    {
                        FormErrors.Add("Amount diverted must be a number");
                    }
                }
                if (UnitsSelectedIndex == -1)
                {
                    FormErrors.Add("Select a unit of measurement");
                }
                else
                {
                    if (UnitsSelectedIndex == 0)
                    {
                        _wasteDiversion.Units = "Percent";
                    }
                    else if (UnitsSelectedIndex == 1)
                    {
                        _wasteDiversion.Units = "Pounds";
                    }
                }

                if (!FormErrors.Any())
                {
                    _wasteDiversion =
                        await HttpClientHelper.Post(Constants.BaseApiClientUrl, "api/wastediversions", _wasteDiversion);
                    ViewLocater.Default.ChangeDetail(new WasteDiversionPage());
                }
            })); }
        }
    }
}

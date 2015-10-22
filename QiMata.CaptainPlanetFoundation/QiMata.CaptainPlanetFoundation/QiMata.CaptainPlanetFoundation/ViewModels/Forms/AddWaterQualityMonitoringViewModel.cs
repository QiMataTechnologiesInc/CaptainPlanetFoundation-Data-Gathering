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
    class AddWaterQualityMonitoringViewModel : BaseFormViewModel
    {
        private WaterQualityMonitoring _waterQualityMonitoring;

        public AddWaterQualityMonitoringViewModel()
        {
            _waterQualityMonitoring = new WaterQualityMonitoring
            {
                ProjectBase = new ProjectBase()
            };

            ProjectBasePartial = new ProjectBasePartialViewModel(_waterQualityMonitoring.ProjectBase);
        }

        public ProjectBasePartialViewModel ProjectBasePartial { get; private set; }

        public string FrequencyOfTest {
            get { return _waterQualityMonitoring.FrequencyOfTest; }
            set { _waterQualityMonitoring.FrequencyOfTest = value; } }

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
                if (String.IsNullOrEmpty(FrequencyOfTest) || String.IsNullOrWhiteSpace(FrequencyOfTest))
                {
                    FormErrors.Add("Frequency of test is required");
                }

                if (!FormErrors.Any())
                {
                    try
                    {
                        _waterQualityMonitoring =
                        await HttpClientHelper.Post(Constants.BaseApiClientUrl, "api/WaterQualityMonitorings", _waterQualityMonitoring);
                    }
                    catch (Exception ex)
                    {
                        
                        throw;
                    }
                    
                    ViewLocater.Default.ChangeDetail(new WaterQualityMonitoringPage());
                }
            })); }
        }
    }
}

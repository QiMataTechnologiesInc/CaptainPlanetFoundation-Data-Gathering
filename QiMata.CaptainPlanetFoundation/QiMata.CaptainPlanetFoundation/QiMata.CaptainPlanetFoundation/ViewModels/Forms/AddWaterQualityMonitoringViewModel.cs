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

        public string FrequencyOfTest { get; set; }

        private Command _submitCommand;

        public Command SubmitCommand
        {
            get { return _submitCommand ?? (_submitCommand = new Command(() => { })); }
        }
    }
}

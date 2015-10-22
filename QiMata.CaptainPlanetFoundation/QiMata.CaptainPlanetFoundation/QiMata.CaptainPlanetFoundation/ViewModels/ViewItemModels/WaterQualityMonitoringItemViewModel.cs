using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QiMata.CaptainPlanetFoundation.Models;
using Xamarin.Forms;

namespace QiMata.CaptainPlanetFoundation.ViewModels.ViewItemModels
{
    class WaterQualityMonitoringItemViewModel
    {
        private WaterQualityMonitoring _waterQualityMonitoring;

        public WaterQualityMonitoringItemViewModel(WaterQualityMonitoring waterQualityMonitoring)
        {
            _waterQualityMonitoring = waterQualityMonitoring;
        }

        public bool HasImage
        {
            get { return _waterQualityMonitoring.ProjectBase.Image != null; }
        }

        public string ProjectText
        {
            get { return _waterQualityMonitoring.ProjectBase.ProjectName + " - " + _waterQualityMonitoring.ProjectBase.ClassName ?? ""; }
        }

        public ImageSource Image
        {
            get
            {
                if (HasImage)
                {
                    return ImageSource.FromStream(() =>
                    {
                        return new MemoryStream(_waterQualityMonitoring.ProjectBase.Image);
                    });
                }
                return null;
            }
        }

        public string ProjectType
        {
            get { return "Water Monitoring"; }
        }

        public string ProjectDate
        {
            get { return _waterQualityMonitoring.ProjectBase.DateReported.ToString(@"MM\/ dd\/ yyyy"); }
        }

        public string Students
        {
            get { return "Students: " + _waterQualityMonitoring.ProjectBase.NumberOfParticipants.ToString(); }
        }

        public string ProjectName => _waterQualityMonitoring.ProjectBase.ProjectName;

        public string ClassName => _waterQualityMonitoring.ProjectBase.ClassName;

        public string Description => _waterQualityMonitoring.ProjectBase.Description;
    }
}

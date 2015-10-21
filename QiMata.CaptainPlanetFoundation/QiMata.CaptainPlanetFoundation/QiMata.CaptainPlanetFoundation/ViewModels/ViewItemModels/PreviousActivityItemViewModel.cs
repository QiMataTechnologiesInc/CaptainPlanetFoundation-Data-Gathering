using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QiMata.CaptainPlanetFoundation.Models;
using QiMata.CaptainPlanetFoundation.Views;
using Xamarin.Forms;

namespace QiMata.CaptainPlanetFoundation.ViewModels.ViewItemModels
{
    class PreviousActivityItemViewModel
    {
        private readonly ProjectBase _projectBase;

        public PreviousActivityItemViewModel(ProjectBase projectBase)
        {
            _projectBase = projectBase;
        }

        public bool HasImage
        {
            get { return _projectBase.Image != null; }
        }

        public string ProjectText
        {
            get { return _projectBase.ProjectName + " - " + _projectBase.ClassName ?? ""; }
        }

        public ImageSource Image
        {
            get
            {
                if (HasImage)
                {
                    return ImageSource.FromStream(() =>
                    {
                        return new MemoryStream(_projectBase.Image);
                    });
                }
                return null;
            }
        }

        private Command _onTap;

        public Command OnTap
        {
            get
            {
                return _onTap ?? (_onTap = new Command(() =>
                {
                    if (_projectBase.AquaponicProject != null)
                    {
                        ViewLocater.Default.ChangeDetail(new AquaponicsPage());
                    }
                    else if (_projectBase.EditableGarden != null)
                    {
                        ViewLocater.Default.ChangeDetail(new EdibleGardensPage());
                    }
                    else if (_projectBase.HabitatRestoration != null)
                    {
                        ViewLocater.Default.ChangeDetail(new HabitatRestorationPage());
                    }
                    else if (_projectBase.PollinatorGarden != null)
                    {
                        ViewLocater.Default.ChangeDetail(new PollinatorGardenPage());
                    }
                    else if (_projectBase.Reforestation != null)
                    {
                        ViewLocater.Default.ChangeDetail(new ReforestationPage());
                    }
                    else if (_projectBase.RenewableEnergy != null)
                    {
                        ViewLocater.Default.ChangeDetail(new RenewableEnergyPage());
                    }
                    else if (_projectBase.WasteDiversion != null)
                    {
                        ViewLocater.Default.ChangeDetail(new WasteDiversionPage());
                    }
                    else if (_projectBase.WaterQualityMonitoring != null)
                    {
                        ViewLocater.Default.ChangeDetail(new WaterQualityMonitoringPage());
                    }
                }));
            }
        }

        public string ProjectType
        {
            get
            {
                if (_projectBase.AquaponicProject != null)
                {
                    return "Aquaponics";
                }
                else if (_projectBase.EditableGarden != null)
                {
                    return "Editable Garden";
                }
                else if (_projectBase.HabitatRestoration != null)
                {
                    return "Habitat Restoration";
                }
                else if (_projectBase.PollinatorGarden != null)
                {
                    return "Pollinator Garden";
                }
                else if (_projectBase.Reforestation != null)
                {
                    return "Reforestation";
                }
                else if (_projectBase.RenewableEnergy != null)
                {
                    return "Renewable Energy";
                }
                else if (_projectBase.WasteDiversion != null)
                {
                    return "Waste Diversion";
                }
                else if (_projectBase.WaterQualityMonitoring != null)
                {
                    return "Water Quality Monitoring";
                }
                else
                {
                    return "Please add project type";
                }
            }
        }

        public string ProjectDate
        {
            get { return _projectBase.DateReported.ToString(@"MM\/ dd\/ yyyy"); }
        }

        public string Students
        {
            get { return "Students: " + _projectBase.NumberOfParticipants.ToString(); }
        }

        public string ProjectName => _projectBase.ProjectName;

        public string ClassName => _projectBase.ClassName;

        public string Description => _projectBase.Description;
    }
}

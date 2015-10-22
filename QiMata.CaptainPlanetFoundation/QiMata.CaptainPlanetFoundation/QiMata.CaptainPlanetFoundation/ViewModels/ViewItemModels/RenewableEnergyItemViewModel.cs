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
    class RenewableEnergyItemViewModel
    {
        private readonly RenewableEnergy _renewableEnergy;

        public RenewableEnergyItemViewModel(RenewableEnergy renewableEnergy)
        {
            _renewableEnergy = renewableEnergy;
        }

        public bool HasImage
        {
            get { return _renewableEnergy.ProjectBase.Image != null; }
        }

        public string ProjectText
        {
            get { return _renewableEnergy.ProjectBase.ProjectName + " - " + _renewableEnergy.ProjectBase.ClassName ?? ""; }
        }

        public ImageSource Image
        {
            get
            {
                if (HasImage)
                {
                    return ImageSource.FromStream(() =>
                    {
                        return new MemoryStream(_renewableEnergy.ProjectBase.Image);
                    });
                }
                return null;
            }
        }

        public string ProjectType
        {
            get { return "Renewable Energy"; }
        }

        public string ProjectDate
        {
            get { return _renewableEnergy.ProjectBase.DateReported.ToString(@"MM\/ dd\/ yyyy"); }
        }

        public string Students
        {
            get { return "Students: " + _renewableEnergy.ProjectBase.NumberOfParticipants.ToString(); }
        }

        public string ProjectName => _renewableEnergy.ProjectBase.ProjectName;

        public string ClassName => _renewableEnergy.ProjectBase.ClassName;

        public string Description => _renewableEnergy.ProjectBase.Description;
    }
}

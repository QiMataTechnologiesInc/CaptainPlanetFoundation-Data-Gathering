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
    class AquaponicsListItemViewModel
    {
        private AquaponicProject _aquaponicProject;

        public AquaponicsListItemViewModel(AquaponicProject aquaponicProject)
        {
            _aquaponicProject = aquaponicProject;
        }

        public bool HasImage
        {
            get { return _aquaponicProject.ProjectBase.Image != null; }
        }

        public string ProjectText
        {
            get { return _aquaponicProject.ProjectBase.ProjectName + " - " + _aquaponicProject.ProjectBase.ClassName ?? ""; }
        }

        public ImageSource Image
        {
            get
            {
                if (HasImage)
                {
                    return ImageSource.FromStream(() =>
                    {
                        return new MemoryStream(_aquaponicProject.ProjectBase.Image);
                    });
                }
                return null;
            }
        }

        public string ProjectType
        {
            get { return "Aquaponics Project"; }
        }

        public string ProjectDate
        {
            get { return _aquaponicProject.ProjectBase.DateReported.ToString(@"MM\/ dd\/ yyyy"); }
        }

        public string Students
        {
            get { return "Students: " + _aquaponicProject.ProjectBase.NumberOfParticipants.ToString(); }
        }

        public string ProjectName => _aquaponicProject.ProjectBase.ProjectName;

        public string ClassName => _aquaponicProject.ProjectBase.ClassName;

        public string Description => _aquaponicProject.ProjectBase.Description;
    }
}

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
    class ReforestationItemViewModel
    {
        private Reforestation _reforestation;

        public ReforestationItemViewModel(Reforestation reforestation)
        {
            _reforestation = reforestation;
        }

        public bool HasImage
        {
            get { return _reforestation.ProjectBase.Image != null; }
        }

        public string ProjectText
        {
            get { return _reforestation.ProjectBase.ProjectName + " - " + _reforestation.ProjectBase.ClassName ?? ""; }
        }

        public ImageSource Image
        {
            get
            {
                if (HasImage)
                {
                    return ImageSource.FromStream(() =>
                    {
                        return new MemoryStream(_reforestation.ProjectBase.Image);
                    });
                }
                return null;
            }
        }

        public string ProjectType
        {
            get { return "Reforestation"; }
        }

        public string ProjectDate
        {
            get { return _reforestation.ProjectBase.DateReported.ToString(@"MM\/ dd\/ yyyy"); }
        }

        public string Students
        {
            get { return "Students: " + _reforestation.ProjectBase.NumberOfParticipants.ToString(); }
        }

        public string ProjectName => _reforestation.ProjectBase.ProjectName;

        public string ClassName => _reforestation.ProjectBase.ClassName;

        public string Description => _reforestation.ProjectBase.Description;
    }
}

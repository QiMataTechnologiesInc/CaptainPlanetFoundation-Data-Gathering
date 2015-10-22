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
    class PollinatorGardenListItemViewModel
    {
        private PollinatorGarden _pollinatorGarden;

        public PollinatorGardenListItemViewModel(PollinatorGarden pollinatorGarden)
        {
            _pollinatorGarden = pollinatorGarden;
        }

        public bool HasImage
        {
            get { return _pollinatorGarden.ProjectBase.Image != null; }
        }

        public string ProjectText
        {
            get { return _pollinatorGarden.ProjectBase.ProjectName + " - " + _pollinatorGarden.ProjectBase.ClassName ?? ""; }
        }

        public ImageSource Image
        {
            get
            {
                if (HasImage)
                {
                    return ImageSource.FromStream(() =>
                    {
                        return new MemoryStream(_pollinatorGarden.ProjectBase.Image);
                    });
                }
                return null;
            }
        }

        public string ProjectType
        {
            get { return "Pollinator Garden"; }
        }

        public string ProjectDate
        {
            get { return _pollinatorGarden.ProjectBase.DateReported.ToString(@"MM\/ dd\/ yyyy"); }
        }

        public string Students
        {
            get { return "Students: " + _pollinatorGarden.ProjectBase.NumberOfParticipants.ToString(); }
        }

        public string ProjectName => _pollinatorGarden.ProjectBase.ProjectName;

        public string ClassName => _pollinatorGarden.ProjectBase.ClassName;

        public string Description => _pollinatorGarden.ProjectBase.Description;
    }
}

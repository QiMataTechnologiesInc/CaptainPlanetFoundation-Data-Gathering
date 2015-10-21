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
    class HabitatRestorationViewItem
    {
        private HabitatRestoration _habitatRestoration;

        public HabitatRestorationViewItem(HabitatRestoration habitatRestoration)
        {
            _habitatRestoration = habitatRestoration;
        }

        public bool HasImage
        {
            get { return _habitatRestoration.ProjectBase.Image != null; }
        }

        public string ProjectText
        {
            get { return _habitatRestoration.ProjectBase.ProjectName + " - " + _habitatRestoration.ProjectBase.ClassName ?? ""; }
        }

        public ImageSource Image
        {
            get
            {
                if (HasImage)
                {
                    return ImageSource.FromStream(() =>
                    {
                        return new MemoryStream(_habitatRestoration.ProjectBase.Image);
                    });
                }
                return null;
            }
        }

        public string ProjectType
        {
            get { return "Habitat Restoration"; }
        }

        public string ProjectDate
        {
            get { return _habitatRestoration.ProjectBase.DateReported.ToString(@"MM\/ dd\/ yyyy"); }
        }

        public string Students
        {
            get { return "Students: " + _habitatRestoration.ProjectBase.NumberOfParticipants.ToString(); }
        }

        public string ProjectName => _habitatRestoration.ProjectBase.ProjectName;

        public string ClassName => _habitatRestoration.ProjectBase.ClassName;

        public string Description => _habitatRestoration.ProjectBase.Description;
    }
}

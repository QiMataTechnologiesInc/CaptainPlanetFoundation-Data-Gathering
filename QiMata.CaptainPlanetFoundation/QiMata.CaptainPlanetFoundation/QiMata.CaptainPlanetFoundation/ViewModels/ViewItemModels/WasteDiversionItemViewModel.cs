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
    class WasteDiversionItemViewModel
    {
        private WasteDiversion _wasteDiversion;

        public WasteDiversionItemViewModel(WasteDiversion wasteDiversion)
        {
            _wasteDiversion = wasteDiversion;
        }

        public bool HasImage
        {
            get { return _wasteDiversion.ProjectBase.Image != null; }
        }

        public string ProjectText
        {
            get { return _wasteDiversion.ProjectBase.ProjectName + " - " + _wasteDiversion.ProjectBase.ClassName ?? ""; }
        }

        public ImageSource Image
        {
            get
            {
                if (HasImage)
                {
                    return ImageSource.FromStream(() =>
                    {
                        return new MemoryStream(_wasteDiversion.ProjectBase.Image);
                    });
                }
                return null;
            }
        }

        public string ProjectType
        {
            get { return "Waste Diversion"; }
        }

        public string ProjectDate
        {
            get { return _wasteDiversion.ProjectBase.DateReported.ToString(@"MM\/ dd\/ yyyy"); }
        }

        public string Students
        {
            get { return "Students: " + _wasteDiversion.ProjectBase.NumberOfParticipants.ToString(); }
        }

        public string ProjectName => _wasteDiversion.ProjectBase.ProjectName;

        public string ClassName => _wasteDiversion.ProjectBase.ClassName;

        public string Description => _wasteDiversion.ProjectBase.Description;
    }
}

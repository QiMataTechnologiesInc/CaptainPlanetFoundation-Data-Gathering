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
    class EdibleGardenItemViewModel
    {
        private EditableGarden _edibleGarden;

        public EdibleGardenItemViewModel(EditableGarden edibleGarden)
        {
            _edibleGarden = edibleGarden;
        }

        public bool HasImage
        {
            get { return _edibleGarden.ProjectBase.Image != null; }
        }

        public string ProjectText
        {
            get { return _edibleGarden.ProjectBase.ProjectName + " - " + _edibleGarden.ProjectBase.ClassName ?? ""; }
        }

        public ImageSource Image
        {
            get
            {
                if (HasImage)
                {
                    return ImageSource.FromStream(() =>
                    {
                        return new MemoryStream(_edibleGarden.ProjectBase.Image);
                    });
                }
                return null;
            }
        }

        public string ProjectType
        {
            get { return "Edible Garden"; }
        }

        public string ProjectDate
        {
            get { return _edibleGarden.ProjectBase.DateReported.ToString(@"MM\/ dd\/ yyyy"); }
        }

        public string Students
        {
            get { return "Students: " + _edibleGarden.ProjectBase.NumberOfParticipants.ToString(); }
        }

        public string ProjectName => _edibleGarden.ProjectBase.ProjectName;

        public string ClassName => _edibleGarden.ProjectBase.ClassName;

        public string Description => _edibleGarden.ProjectBase.Description;
    }
}

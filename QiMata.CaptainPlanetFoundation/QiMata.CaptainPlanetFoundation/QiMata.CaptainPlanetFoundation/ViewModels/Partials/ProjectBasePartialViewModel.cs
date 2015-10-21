using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QiMata.CaptainPlanetFoundation.Models;
using QiMata.CaptainPlanetFoundation.ViewModels.Forms;
using Xamarin.Forms;

namespace QiMata.CaptainPlanetFoundation.ViewModels.Partials
{
    class ProjectBasePartialViewModel : BaseFormViewModel
    {
        private readonly ProjectBase _projectBase;

        public ProjectBasePartialViewModel(ProjectBase projectBase)
        {
            _projectBase = projectBase;
        }

        public string ProjectName {
            get { return _projectBase.ProjectName; }
            set { _projectBase.ProjectName = value; } }

        public string NumberOfParticipants { get; set; }
        

        public string ClassName
        {
            get { return _projectBase.ClassName; }
            set { _projectBase.ClassName = value; }
        }

        public string Description
        {
            get { return _projectBase.Description; }
            set { _projectBase.Description = value; }
        }

        public string DataReportedLocation
        {
            get { return _projectBase.DataReportedLocation; }
            set { _projectBase.DataReportedLocation = value; }
        }

        public byte[] ImageSource { get; set; }

        public bool Submit()
        {
            if (String.IsNullOrWhiteSpace(ProjectName) || String.IsNullOrWhiteSpace(ProjectName))
            {
                FormErrors.Add("Project Name is required");
            }
            if (String.IsNullOrWhiteSpace(NumberOfParticipants) || String.IsNullOrWhiteSpace(NumberOfParticipants))
            {
                FormErrors.Add("Number of Participants is required");
            }
            else
            {
                int numberOfParticipants = 0;
                bool successfulParse = Int32.TryParse(NumberOfParticipants, out numberOfParticipants);
                if (!successfulParse)
                {
                    FormErrors.Add("Number of Participants must be a valid whole number");
                }
            }
            if (String.IsNullOrWhiteSpace(ClassName) || String.IsNullOrWhiteSpace(ClassName))
            {
                FormErrors.Add("Class name is required");
            }
            if (String.IsNullOrWhiteSpace(DataReportedLocation) || String.IsNullOrWhiteSpace(DataReportedLocation))
            {
                FormErrors.Add("Data reported location is required");
            }
            if (ImageSource != null)
            {
                _projectBase.Image = ImageSource;
            }
            return !FormErrors.Any();
        }
    }
}

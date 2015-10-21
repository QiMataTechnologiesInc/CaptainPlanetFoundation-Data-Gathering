using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QiMata.CaptainPlanetFoundation.Models;
using QiMata.CaptainPlanetFoundation.ViewModels.Partials;
using Xamarin.Forms;

namespace QiMata.CaptainPlanetFoundation.ViewModels.Forms
{
    class AddEditableGardenViewModel : BaseFormViewModel
    {
        private readonly EditableGarden _editableGarden;
        private readonly ProjectBasePartialViewModel _projectBasePartial;

        public AddEditableGardenViewModel()
        {
            _editableGarden = new EditableGarden
            {
                ProjectBase =  new ProjectBase()
            };

            _projectBasePartial = new ProjectBasePartialViewModel(_editableGarden.ProjectBase);
        }

        public ProjectBasePartialViewModel ProjectBasePartial
        {
            get
            {
                return _projectBasePartial;
            }
        }

        private Command _submitCommand;

        public Command SubmitCommand
        {
            get { return _submitCommand ?? (_submitCommand = new Command(() => { })); }
        }
    }
}

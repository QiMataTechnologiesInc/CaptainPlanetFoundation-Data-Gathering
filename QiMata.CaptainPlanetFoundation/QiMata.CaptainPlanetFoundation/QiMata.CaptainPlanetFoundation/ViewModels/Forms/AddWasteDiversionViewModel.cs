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
    class AddWasteDiversionViewModel : BaseFormViewModel
    {
        private readonly WasteDiversion _wasteDiversion;

        public AddWasteDiversionViewModel()
        {
            _wasteDiversion = new WasteDiversion
            {
                ProjectBase = new ProjectBase()
            };

            ProjectBasePartial = new ProjectBasePartialViewModel(_wasteDiversion.ProjectBase);
            UnitsSelectedIndex = -1;
        }

        public ProjectBasePartialViewModel ProjectBasePartial { get; private set; }

        public string AmountDiverted { get; set; }

        public int UnitsSelectedIndex { get; set; }

        private Command _submitCommand;

        public Command SubmitCommand
        {
            get { return _submitCommand ?? (_submitCommand = new Command(() => { })); }
        }
    }
}

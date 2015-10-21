using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QiMata.CaptainPlanetFoundation.ViewModels.Partials
{
    class AddNewEntryViewModel
    {
        public AddNewEntryViewModel(Command command, string text)
        {
            Command = command;
            Text = text;
        }

        public Command Command { get; private set; }

        public string Text { get; private set; }
    }
}

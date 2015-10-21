using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QiMata.CaptainPlanetFoundation.ViewModels.ViewItemModels
{
    class NavigationListItemViewModel
    {
        public NavigationListItemViewModel(string name, Command onClick)
        {
            OnClick = onClick;
            Name = name;
        }

        public Command OnClick { get; private set; }
        public string Name { get; private set; }
    }
}

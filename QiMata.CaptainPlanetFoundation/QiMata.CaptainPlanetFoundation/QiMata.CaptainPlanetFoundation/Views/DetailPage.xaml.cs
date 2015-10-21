using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace QiMata.CaptainPlanetFoundation.Views
{
    public partial class DetailPage : NavigationPage
    {
        public DetailPage()
            : this(new PreviousActivityPage())
        {
            InitializeComponent();
        }

        public DetailPage(Page root) : base(root)
        {
            
            if (Device.OS == TargetPlatform.iOS)
            {
                Icon = new FileImageSource
                {
                    File = Device.OS == TargetPlatform.iOS ? "captain_planet_foundation_logo12.png" : null,
                };
                Title = null;
                BarTextColor = Color.Black;
            }
            else
            {
                root.BackgroundColor = Color.White;
                this.BarTextColor = Color.Black;
            }
            this.BarBackgroundColor = Color.FromHex("#6DB4A6");
        }
    }
}

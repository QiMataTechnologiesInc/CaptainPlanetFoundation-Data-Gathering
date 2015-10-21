using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QiMata.CaptainPlanetFoundation.ViewModels.ViewItemModels;
using QiMata.CaptainPlanetFoundation.Views;
using Xamarin.Forms;

namespace QiMata.CaptainPlanetFoundation.ViewModels
{
    class MainPageMasterViewModel
    {
        public ImageSource ImagePath
        {
            get
            {
                return ImageSource.FromFile("captain_planet_foundation_logo12.png");
            }
        }

        public string Title
        {
            get { return "Master"; }
        }

        private List<NavigationListItemViewModel> _pages;

        public IEnumerable<NavigationListItemViewModel> Pages
        {
            get
            {
                return _pages ?? (_pages = GetPages());
            }
        }

        private Command _goHome;

        public Command GoHome
        {
            get
            {
                return _goHome ?? (_goHome = new Command(() =>
                {
                    ViewLocater.Default.ChangeDetail(new PreviousActivityPage());
                }));
            }
        }

        private List<NavigationListItemViewModel> GetPages()
        {
            return new List<NavigationListItemViewModel>
            {
                new NavigationListItemViewModel("Aquaponics",new Command(() =>
                {
                    ViewLocater.Default.ChangeDetail(new AquaponicsPage());
                })),
                new NavigationListItemViewModel("Edible Gardens",new Command(() =>
                {
                    ViewLocater.Default.ChangeDetail(new EdibleGardensPage());
                })),
                new NavigationListItemViewModel("Habitat Restoration",new Command(() =>
                {
                    ViewLocater.Default.ChangeDetail(new HabitatRestorationPage());
                })),
                new NavigationListItemViewModel("Pollinator Garden",new Command(() =>
                {
                    ViewLocater.Default.ChangeDetail(new PollinatorGardenPage());
                })),
                new NavigationListItemViewModel("Reforestation",new Command(() =>
                {
                    ViewLocater.Default.ChangeDetail(new ReforestationPage());
                })),
                new NavigationListItemViewModel("Renewable Energy Projects",new Command(() =>
                {
                    ViewLocater.Default.ChangeDetail(new RenewableEnergyPage());
                })),
                new NavigationListItemViewModel("Waste Diversion",new Command(() =>
                {
                    ViewLocater.Default.ChangeDetail(new WasteDiversionPage());
                })),
                new NavigationListItemViewModel("Water Quality Monitoring",new Command(() =>
                {
                    ViewLocater.Default.ChangeDetail(new WaterQualityMonitoringPage());
                }))
            };
        }
    }
}

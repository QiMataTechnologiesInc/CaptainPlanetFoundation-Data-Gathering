using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QiMata.CaptainPlanetFoundation.Helpers;
using QiMata.CaptainPlanetFoundation.Models;
using QiMata.CaptainPlanetFoundation.ViewModels.Partials;
using QiMata.CaptainPlanetFoundation.ViewModels.ViewItemModels;
using QiMata.CaptainPlanetFoundation.Views;
using QiMata.CaptainPlanetFoundation.Views.Forms;
using Xamarin.Forms;

namespace QiMata.CaptainPlanetFoundation.ViewModels
{
    class HabitatRestorationViewModel
    {
        public ObservableCollection<HabitatRestorationViewItem> HabitatRestorations { get; set; }

        public AddNewEntryViewModel AddNewEntry { get; private set; }

        public HabitatRestorationViewModel()
        {
            AddNewEntry = new AddNewEntryViewModel(new Command(() =>
            {
                ViewLocater.Default.ChangeDetail(new AddHabitatRestorationPage());
            }), "Add");

            HabitatRestorations = new ObservableCollection<HabitatRestorationViewItem>();

            HttpClientHelper.Get<HabitatRestoration>(Constants.BaseApiClientUrl, "api/HabitatRestorations")
                .ContinueWith(x =>
                {
                    var results = x.Result;
                    foreach (HabitatRestoration habitatRestoration in results)
                    {
                        HabitatRestorations.Add(new HabitatRestorationViewItem(habitatRestoration));
                    }
                });
        }
    }
}

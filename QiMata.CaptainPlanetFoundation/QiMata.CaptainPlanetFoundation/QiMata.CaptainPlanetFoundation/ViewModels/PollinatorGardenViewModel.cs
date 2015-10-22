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
    class PollinatorGardenViewModel
    {
        public ObservableCollection<PollinatorGardenListItemViewModel> PollinatorGardenListItemViewModels { get; set; }

        public AddNewEntryViewModel AddNewEntry { get; private set; }

        public PollinatorGardenViewModel()
        {
            AddNewEntry = new AddNewEntryViewModel(new Command(() =>
            {
                ViewLocater.Default.ChangeDetail(new AddPollinatorGardenPage());
            }), "Add");

            PollinatorGardenListItemViewModels = new ObservableCollection<PollinatorGardenListItemViewModel>();

            HttpClientHelper.Get<PollinatorGarden>(Constants.BaseApiClientUrl, "api/pollinatorGardens")
                .ContinueWith(x =>
                {
                    foreach (PollinatorGarden pollinatorGarden in x.Result)
                    {
                        PollinatorGardenListItemViewModels.Add(new PollinatorGardenListItemViewModel(pollinatorGarden));
                    }
                });
        }
    }
}

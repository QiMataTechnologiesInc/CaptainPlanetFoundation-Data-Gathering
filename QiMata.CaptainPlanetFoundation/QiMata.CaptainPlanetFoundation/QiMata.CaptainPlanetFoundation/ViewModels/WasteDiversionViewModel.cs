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
    class WasteDiversionViewModel
    {
        public ObservableCollection<WasteDiversionItemViewModel> WasteDiversionItemViewModels { get; set; }

        public AddNewEntryViewModel AddNewEntry { get; private set; }

        public WasteDiversionViewModel()
        {
            AddNewEntry = new AddNewEntryViewModel(new Command(() =>
            {
                ViewLocater.Default.ChangeDetail(new AddWasteDiversionPage());
            }), "Add");

            WasteDiversionItemViewModels = new ObservableCollection<WasteDiversionItemViewModel>();

            HttpClientHelper.Get<WasteDiversion>(Constants.BaseApiClientUrl, "api/wastediversions")
                .ContinueWith(x =>
                {
                    foreach (WasteDiversion wasteDiversion in x.Result)
                    {
                        WasteDiversionItemViewModels.Add(new WasteDiversionItemViewModel(wasteDiversion));
                    }
                });
        }
    }
}

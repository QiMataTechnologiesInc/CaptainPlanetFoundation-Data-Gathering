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
    class RenewableEnergyViewModel
    {
        public ObservableCollection<RenewableEnergyItemViewModel> RenewableEnergyItemViewModels { get; set; }

        public AddNewEntryViewModel AddNewEntry { get; private set; }

        public RenewableEnergyViewModel()
        {
            AddNewEntry = new AddNewEntryViewModel(new Command(() =>
            {
                ViewLocater.Default.ChangeDetail(new AddRenewableEnergyPage());
            }), "Add");

            RenewableEnergyItemViewModels = new ObservableCollection<RenewableEnergyItemViewModel>();

            HttpClientHelper.Get<RenewableEnergy>(Constants.BaseApiClientUrl, "api/RenewableEnergies")
                .ContinueWith(x =>
                {
                    foreach (RenewableEnergy renewableEnergy in x.Result)
                    {
                        RenewableEnergyItemViewModels.Add(new RenewableEnergyItemViewModel(renewableEnergy));
                    }
                });
        }
    }
}

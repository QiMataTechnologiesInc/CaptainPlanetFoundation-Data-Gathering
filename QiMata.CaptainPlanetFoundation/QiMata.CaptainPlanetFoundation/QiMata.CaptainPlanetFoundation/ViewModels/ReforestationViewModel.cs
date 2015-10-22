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
    class ReforestationViewModel
    {
        public ObservableCollection<ReforestationItemViewModel> Reforestations { get; set; }

        public AddNewEntryViewModel AddNewEntry { get; private set; }

        public ReforestationViewModel()
        {
            AddNewEntry = new AddNewEntryViewModel(new Command(() =>
            {
                ViewLocater.Default.ChangeDetail(new AddReforestationPage());
            }), "Add");

            Reforestations = new ObservableCollection<ReforestationItemViewModel>();

            HttpClientHelper.Get<Reforestation>(Constants.BaseApiClientUrl, "api/reforestations")
                .ContinueWith(x =>
                {
                    foreach (Reforestation reforestation in x.Result)
                    {
                        Reforestations.Add(new ReforestationItemViewModel(reforestation));
                    }
                });
        }
    }
}

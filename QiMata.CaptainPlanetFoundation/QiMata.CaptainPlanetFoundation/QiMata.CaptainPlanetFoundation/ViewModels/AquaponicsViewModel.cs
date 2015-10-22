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
    class AquaponicsViewModel
    {
        public ObservableCollection<AquaponicsListItemViewModel> AquaponicsListItemViewModels { get; set; }

        public AddNewEntryViewModel AddNewEntry { get; private set; }

        public AquaponicsViewModel()
        {
            AddNewEntry = new AddNewEntryViewModel(new Command(() =>
            {
                ViewLocater.Default.ChangeDetail(new AddAquaponicsPage());
            }), "Add");

            AquaponicsListItemViewModels = new ObservableCollection<AquaponicsListItemViewModel>();

            HttpClientHelper.Get<AquaponicProject>(Constants.BaseApiClientUrl, "api/AquaponicProjects")
                .ContinueWith(x =>
                {
                    foreach (AquaponicProject aquaponicProject in x.Result)
                    {
                        AquaponicsListItemViewModels.Add(new AquaponicsListItemViewModel(aquaponicProject));
                    }
                });
        }
    }
}

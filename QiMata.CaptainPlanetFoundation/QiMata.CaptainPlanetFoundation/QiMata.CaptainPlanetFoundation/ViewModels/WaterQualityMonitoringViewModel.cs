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
    class WaterQualityMonitoringViewModel
    {
        public ObservableCollection<WaterQualityMonitoringItemViewModel> WaterQualityMonitoringItemViewModels { get; set; }

        public AddNewEntryViewModel AddNewEntry { get; private set; }

        public WaterQualityMonitoringViewModel()
        {
            AddNewEntry = new AddNewEntryViewModel(new Command(() =>
            {
                ViewLocater.Default.ChangeDetail(new AddWaterQualityMonitoringPage());
            }), "Add");

            WaterQualityMonitoringItemViewModels = new ObservableCollection<WaterQualityMonitoringItemViewModel>();

            HttpClientHelper.Get<WaterQualityMonitoring>(Constants.BaseApiClientUrl, "api/waterQualityMonitorings")
                .ContinueWith(x =>
                {
                    foreach (WaterQualityMonitoring waterQualityMonitoring in x.Result)
                    {
                        WaterQualityMonitoringItemViewModels.Add(
                            new WaterQualityMonitoringItemViewModel(waterQualityMonitoring));
                    }
                });
        }
    }
}

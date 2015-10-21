using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using QiMata.CaptainPlanetFoundation.Annotations;
using QiMata.CaptainPlanetFoundation.Helpers;
using QiMata.CaptainPlanetFoundation.Models;
using QiMata.CaptainPlanetFoundation.ViewModels.ViewItemModels;

namespace QiMata.CaptainPlanetFoundation.ViewModels
{
    class PreviousActivityViewModel : INotifyPropertyChanged
    {
        public PreviousActivityViewModel()
        {
            RecentActivites = new ObservableCollection<PreviousActivityItemViewModel>();

            HttpClientHelper.Get<ProjectBase>(Constants.BaseApiClientUrl, "api/ProjectBases").ContinueWith(x =>
            {
                try
                {
                    var result = x.Result;
                    foreach (var proj in result)
                    {
                        RecentActivites.Add(new PreviousActivityItemViewModel(proj));
                    }
                }
                catch (Exception ex)
                {
                    
                    throw;
                }
            });
        }

        public ObservableCollection<PreviousActivityItemViewModel> RecentActivites { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

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
    class EdibleGardensViewModel
    {
        public ObservableCollection<EdibleGardenItemViewModel> EdibleGardenItemViewModels { get; set; }

        public AddNewEntryViewModel AddNewEntry { get; private set; }

        public EdibleGardensViewModel()
        {
            AddNewEntry = new AddNewEntryViewModel(new Command(() =>
            {
                ViewLocater.Default.ChangeDetail(new AddEditableGardenPage());
            }), "Add");

            EdibleGardenItemViewModels = new ObservableCollection<EdibleGardenItemViewModel>();

            HttpClientHelper.Get<EditableGarden>(Constants.BaseApiClientUrl, "api/EditableGardens")
                .ContinueWith(x =>
                {
                    foreach (EditableGarden editableGarden in x.Result)
                    {
                        EdibleGardenItemViewModels.Add(new EdibleGardenItemViewModel(editableGarden));
                    }
                });
        }
    }
}

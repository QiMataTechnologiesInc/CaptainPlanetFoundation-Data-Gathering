using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QiMata.CaptainPlanetFoundation.ViewModels.Forms
{
    class BaseFormViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> FormErrors { get; protected set; }

        public bool ErrorsVisible
        {
            get { return FormErrors.Any(); }
        }

        public BaseFormViewModel()
        {
            FormErrors=new ObservableCollection<string>();
            FormErrors.CollectionChanged += FormErrors_CollectionChanged;
        }

        private void FormErrors_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(ErrorsVisible));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

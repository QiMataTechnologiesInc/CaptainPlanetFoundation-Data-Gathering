using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QiMata.CaptainPlanetFoundation.Views
{
    class ViewLocater
    {
        public static readonly ViewLocater Default = new ViewLocater();

        public readonly MainPage MainPage = new MainPage();

        public void ChangeDetail(Page page)
        {
            MainPage.Detail = new DetailPage(page);
            MainPage.IsPresented = false;
        }
    }
}

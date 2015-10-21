using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QiMata.CaptainPlanetFoundation.CustomRenderers
{
    public class ImageInput : Image
    {
        public static readonly BindableProperty ImageProperty = BindableProperty.Create<ImageInput, byte[]>(p => p.Image, null);

        public byte[] Image {
            get { return (byte[])GetValue(ImageProperty); }
            set
            {
                SetValue(ImageProperty,value);
            } }
    }
}

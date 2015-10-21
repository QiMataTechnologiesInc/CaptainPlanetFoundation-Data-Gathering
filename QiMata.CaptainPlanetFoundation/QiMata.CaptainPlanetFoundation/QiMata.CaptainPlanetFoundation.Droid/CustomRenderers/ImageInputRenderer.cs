using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using QiMata.CaptainPlanetFoundation.CustomRenderers;
using QiMata.CaptainPlanetFoundation.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(ImageInput),typeof(ImageInputRenderer))]
namespace QiMata.CaptainPlanetFoundation.Droid.CustomRenderers
{
    class ImageInputRenderer : ImageRenderer
    {
        private static readonly int _pickImageId = 1000;
        
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            var recognizers = this.Element.GestureRecognizers;
            recognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => { ShowImageInput(); })
            });

            this.Control.SetScaleType(ImageView.ScaleType.FitCenter);
        }

        private void ShowImageInput()
        {
            var intent = new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);
            var mainActivity = (MainActivity) this.Context;
            mainActivity.ActivityResultCallback = OnActivityResult;
            mainActivity.StartActivityForResult(Intent.CreateChooser(intent, "Select Picture"), _pickImageId);
        }

        private void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if ((requestCode == _pickImageId) && (resultCode == Result.Ok) && (data != null))
            {
                var imageUri = data.Data;
                Bitmap img = MediaStore.Images.Media.GetBitmap(this.Context.ContentResolver,imageUri);
                var finalImg = ScalBitMap(img);

                var imageControl = (ImageInput)this.Element;

                using (var stream = new MemoryStream())
                {
                    img.Compress(Bitmap.CompressFormat.Png, 0, stream);
                    imageControl.Image = stream.ToArray();
                }

                this.Control.SetImageBitmap(finalImg);
            }
        }

        private Bitmap ScalBitMap(Bitmap bitmap)
        {
            int imageHeight = bitmap.Height;
            int imageWidth = bitmap.Width;

            float xScale = Convert.ToSingle(Width) / imageWidth;
            float yScale = Convert.ToSingle(Height)/imageHeight;
            float scale = xScale <= yScale ? xScale : yScale;

            Matrix matrix = new Matrix();
            matrix.SetScale(scale,scale);

            return Bitmap.CreateBitmap(bitmap,0,0, imageWidth, imageHeight, matrix,true);
        }
    }
}
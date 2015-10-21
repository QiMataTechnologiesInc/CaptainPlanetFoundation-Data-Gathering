using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using QiMata.CaptainPlanetFoundation.CustomRenderers;
using QiMata.CaptainPlanetFoundation.iOS.CustomRenderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ExportRenderer(typeof(ImageInput),typeof(ImageInputRenderer))]
namespace QiMata.CaptainPlanetFoundation.iOS.CustomRenderers
{
    sealed class ImageInputRenderer : ImageRenderer
    {
        private readonly UIImagePickerController _imagePickerController;

        public ImageInputRenderer()
        {
            _imagePickerController = new UIImagePickerController
            {
                SourceType = UIImagePickerControllerSourceType.PhotoLibrary,
                MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary)
            };

            _imagePickerController.FinishedPickingMedia += ImagePickerController_FinishedPickingMedia;
            _imagePickerController.FinishedPickingImage += ImagePickerControllerOnFinishedPickingImage;
            _imagePickerController.Canceled += _imagePickerController_Canceled;

            AddGestureRecognizer(new UITapGestureRecognizer(() =>
            {
                base.Window.RootViewController.PresentModalViewController(_imagePickerController, true);
            }));
        }

        private void ImagePickerController_FinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs e)
        {
            this.Control.Image = e.OriginalImage;

            var imageInput = (ImageInput)this.Element;

            using (var image = e.OriginalImage.AsPNG().AsStream())
            {
                using (var ms = new MemoryStream())
                {
                    image.CopyTo(ms);
                    imageInput.Image = ms.ToArray();
                }

            }
            _imagePickerController.DismissModalViewController(true);
        }

        private void _imagePickerController_Canceled(object sender, EventArgs e)
        {
            _imagePickerController.DismissModalViewController(true);
        }

        private void ImagePickerControllerOnFinishedPickingImage(object sender, UIImagePickerImagePickedEventArgs uiImagePickerImagePickedEventArgs)
        {
            this.Control.Image = uiImagePickerImagePickedEventArgs.Image;
            _imagePickerController.DismissModalViewController(true);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _imagePickerController.FinishedPickingImage -= ImagePickerControllerOnFinishedPickingImage;
                _imagePickerController.Canceled += _imagePickerController_Canceled;
            }
        }
    }
}

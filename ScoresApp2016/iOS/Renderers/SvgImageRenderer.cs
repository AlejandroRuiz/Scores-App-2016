using System;
using System.IO;
using System.Net.Http;
using NGraphics.Custom.Parsers;
using NGraphics.iOS.Custom;
using ScoresApp2016;
using ScoresApp2016.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SvgImage), typeof(SvgImageRenderer))]
namespace ScoresApp2016.iOS
{
	/// <summary>
	/// SVG Renderer
	/// </summary>
	[Preserve(AllMembers = true)]
	public class SvgImageRenderer : ImageRenderer
	{

		private SvgImage _formsControl
		{
			get { return Element as SvgImage; }
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (_formsControl != null)
			{
				if (e.PropertyName != SvgImage.SvgPathProperty.PropertyName)
					return;

				if (string.IsNullOrWhiteSpace(_formsControl.SvgPath))
					return;

				UpdateSVGSource();
			}
		}

		async void UpdateSVGSource()
		{
			Control.ContentMode = UIViewContentMode.ScaleAspectFit;
			Uri u;
			try
			{
				u = new Uri(_formsControl.SvgPath);
			}
			catch
			{
				Control.Image = UIImage.FromBundle(_formsControl.SvgDefaultImage);
				return;
			}
			var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Path.GetFileName(u.AbsolutePath));
			if (!File.Exists(path))
			{
				using (var client = new HttpClient())
				{
					try
					{
						var bytes = await client.GetByteArrayAsync(_formsControl.SvgPath);
						File.WriteAllBytes(path, bytes);
					}
					catch
					{
						Control.Image = UIImage.FromBundle(_formsControl.SvgDefaultImage);
						return;
					}
				}
			}

			var svgStream = File.OpenRead(path);

			if (svgStream == null)
			{
				throw new Exception(string.Format("Error retrieving {0} make sure Build Action is Embedded Resource",
					_formsControl.SvgPath));
			}

			SvgReader r;
			try
			{
				r = new SvgReader(new StreamReader(svgStream), new StylesParser(new ValuesParser()), new ValuesParser());
			}
			catch
			{
				Control.Image = UIImage.FromBundle(_formsControl.SvgDefaultImage);
				return;
			}

			var graphics = r.Graphic;

			var width = _formsControl.WidthRequest <= 0 ? 100 : _formsControl.WidthRequest;
			var height = _formsControl.HeightRequest <= 0 ? 100 : _formsControl.HeightRequest;

			var scale = 1.0;

			if (height >= width)
			{
				scale = height / graphics.Size.Height;
			}
			else
			{
				scale = width / graphics.Size.Width;
			}

			var scaleFactor = UIScreen.MainScreen.Scale;

			try
			{
				var canvas = new ApplePlatform().CreateImageCanvas(graphics.Size, scale * scaleFactor);
				graphics.Draw(canvas);
				var image = canvas.GetImage();

				var uiImage = image.GetUIImage();
				Control.Image = uiImage;
			}
			catch
			{
				Control.Image = UIImage.FromBundle(_formsControl.SvgDefaultImage);
			}
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
		{
			base.OnElementChanged(e);

			if (_formsControl != null)
			{
				if (string.IsNullOrWhiteSpace(_formsControl.SvgPath))
					return;
				UpdateSVGSource();
			}
		}
	}
}


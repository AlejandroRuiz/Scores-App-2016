using System;
using Xamarin.Forms.Internals;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using NGraphics.Custom.Parsers;
using NGraphics.Android.Custom;
using Xamarin.Forms;
using ScoresApp2016;
using ScoresApp2016.Droid;

[assembly: ExportRenderer(typeof(SvgImage), typeof(SvgImageRenderer))]
namespace ScoresApp2016.Droid
{
	[Preserve(AllMembers = true)]
	public class SvgImageRenderer : Xamarin.Forms.Platform.Android.ViewRenderer<SvgImage, ImageView>
	{
		public static void Init()
		{
			var temp = DateTime.Now;
		}

		private SvgImage _formsControl
		{
			get
			{
				return Element as SvgImage;
			}
		}


		protected override void OnElementChanged(ElementChangedEventArgs<SvgImage> e)
		{
			base.OnElementChanged(e);

			if (_formsControl != null)
			{
				if (string.IsNullOrWhiteSpace(_formsControl.SvgPath))
					return;
				UpdateSVGSource();
			}
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
			await Task.Run(async () =>
				{
					Uri u;
					try
					{
						u = new Uri(_formsControl.SvgPath);
					}
					catch
					{
						return null;
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
								return null;
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
						return null;
					}

					var graphics = r.Graphic;

					var width = PixelToDP((int)_formsControl.WidthRequest <= 0 ? 100 : (int)_formsControl.WidthRequest);
					var height = PixelToDP((int)_formsControl.HeightRequest <= 0 ? 100 : (int)_formsControl.HeightRequest);

					var scale = 1.0;

					if (height >= width)
					{
						scale = height / graphics.Size.Height;
					}
					else
					{
						scale = width / graphics.Size.Width;
					}

					try
					{
						var canvas = new AndroidPlatform().CreateImageCanvas(graphics.Size, scale);
						graphics.Draw(canvas);
						var image = (BitmapImage)canvas.GetImage();
						return image;
					}
					catch
					{
						return null;
					}
				}).ContinueWith(taskResult =>
					{
						Device.BeginInvokeOnMainThread(() =>
							{
								var imageView = new ImageView(Context);
								SetNativeControl(imageView);
								if (taskResult.Result == null)
								{
									var id = getResourceId(_formsControl.SvgDefaultImage, "drawable", Context.PackageName);
									Control.SetImageResource(id);
									return;
								}

								imageView.SetScaleType(ImageView.ScaleType.CenterInside);
								imageView.SetImageBitmap(taskResult.Result.Bitmap);
							});

					});
		}

		public int getResourceId(String pVariableName, String pResourcename, String pPackageName)
		{
			try
			{
				return Context.Resources.GetIdentifier(pVariableName, pResourcename, pPackageName);
			}
			catch
			{
				return -1;
			}
		}

		public override SizeRequest GetDesiredSize(int widthConstraint, int heightConstraint)
		{
			return new SizeRequest(new Size(_formsControl.WidthRequest, _formsControl.WidthRequest));
		}

		/// <summary>
		/// http://stackoverflow.com/questions/24465513/how-to-get-detect-screen-size-in-xamarin-forms
		/// </summary>
		/// <param name="pixel"></param>
		/// <returns></returns>
		private int PixelToDP(int pixel)
		{
			var scale = Resources.DisplayMetrics.Density;
			return (int)((pixel * scale) + 0.5f);
		}
	}
}


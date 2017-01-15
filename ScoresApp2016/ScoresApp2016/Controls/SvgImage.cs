using System;
using System.Reflection;
using Xamarin.Forms;

namespace ScoresApp2016
{
	public class SvgImage : Image
	{
		/// <summary>
		/// The path to the svg file
		/// </summary>
		public static readonly BindableProperty SvgPathProperty =
			BindableProperty.Create("SvgPath", typeof(string), typeof(SvgImage), default(string));

		/// <summary>
		/// The path to the svg file
		/// </summary>
		public string SvgPath
		{
			get { return (string)GetValue(SvgPathProperty); }
			set { SetValue(SvgPathProperty, value); }
		}

		/// <summary>
		/// The assembly containing the svg file
		/// </summary>
		public static readonly BindableProperty SvgAssemblyProperty =
			BindableProperty.Create("SvgAssembly", typeof(Assembly), typeof(SvgImage), default(Assembly));

		/// <summary>
		/// The assembly containing the svg file
		/// </summary>
		public Assembly SvgAssembly
		{
			get { return (Assembly)GetValue(SvgAssemblyProperty); }
			set { SetValue(SvgAssemblyProperty, value); }
		}

		public static readonly BindableProperty SvgDefaultImageProperty =
			BindableProperty.Create("SvgDefaultImage", typeof(string), typeof(SvgImage), Strings.AppLogoIcon);

		public string SvgDefaultImage
		{
			get { return (string)GetValue(SvgDefaultImageProperty); }
			set { SetValue(SvgDefaultImageProperty, value); }
		}
	}
}

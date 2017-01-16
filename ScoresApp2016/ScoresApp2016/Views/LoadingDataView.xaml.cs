using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ScoresApp2016
{
	public partial class LoadingDataView : ContentView
	{
		public LoadingDataView()
		{
			InitializeComponent();
		}

		public async void RotateImage()
		{
			int i = 0;
			while (true)
			{
				if (i == 10)
					i = 0;
				await Task.Delay(100);
				_loadingImage.Rotation = (360 / 10) * (i + 1);
				i++;
			}
		}
	}
}

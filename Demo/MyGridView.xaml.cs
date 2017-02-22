using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Demo
{
	public partial class MyGridView : ContentView
	{
		public MyGridView()
		{
			InitializeComponent();

			this.Content = CreateContent();
		}

		private View CreateContent()
		{
			var heightLabel = new Label
			{
				Text = App.ScreenHeight.ToString(),
				TextColor = Color.Black
			};

			var widthLabel = new Label
			{
				Text = App.ScreenWidth.ToString(),
				TextColor = Color.Black
			};

			Grid grid = new Grid
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};

			// 1) object to add
			// 2) column to start at
			// 3) column span
			// 4) row to start at
			// 5) row span
			grid.Children.Add(new Label { Text = "Height:" }, 0, 0);
			grid.Children.Add(heightLabel, 1, 0);
			grid.Children.Add(new Label { Text = "Width:" }, 0, 1, 1, 2);
			grid.Children.Add(widthLabel, 1, 2, 1, 2);

			return grid;
		}
	}
}

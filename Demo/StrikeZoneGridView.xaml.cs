using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Demo
{
	public partial class StrikeZoneGridView : ContentView
	{
		public StrikeZoneGridView()
		{
			InitializeComponent();

			this.Content = CreateContent();
		}

		private View CreateContent()
		{
			var grid = new Grid
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};

			var tempX = App.ScreenHeight - grid.Bounds.Location.X;
			var tempY = App.ScreenWidth - grid.Bounds.Location.Y;

			grid.Children.Add(CreateZone("1", Color.Black), 0, 0);
			grid.Children.Add(CreateZone("2", Color.Black), 1, 0);
			grid.Children.Add(CreateZone("3", Color.Black), 2, 0);
			grid.Children.Add(CreateZone("4", Color.Black), 0, 1, 1, 2);
			grid.Children.Add(CreateZone("5", Color.Black), 1, 2, 1, 2);
			grid.Children.Add(CreateZone("6", Color.Black), 2, 3, 1, 2);
			grid.Children.Add(CreateZone("7", Color.Black), 0, 1, 2, 3);
			grid.Children.Add(CreateZone("8", Color.Black), 1, 2, 2, 3);
			grid.Children.Add(CreateZone("9", Color.Black), 2, 3, 2, 3);

			AbsoluteLayout layout = new AbsoluteLayout();


			grid.Children.Add(CreateZone(App.ScreenHeight.ToString(), Color.Black), 0, 1, 3, 4);
			grid.Children.Add(CreateZone(layout.Bounds.Y.ToString(), Color.Black), 1, 2, 3, 4);

			layout.Children.Add(grid);

			return layout;
		}

		private View CreateZone(string btnText,
		                        Color backgroundColor)
		{
			var zoneButton = new Button()
			{
				Text = btnText,
				TextColor = Color.White,
				WidthRequest = 75,
				HeightRequest = 75,
				BorderRadius = 3,
				BackgroundColor = backgroundColor
			};

			zoneButton.Clicked += OnButtonClicked;

			return zoneButton;
		}

		void OnButtonClicked(object sender, EventArgs e)
		{
			var btn = (Button)sender;

			btn.BackgroundColor = Color.Red;
		}
	}
}

using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Demo
{
	public partial class StrikeZoneView : ContentView
	{
		public StrikeZoneView()
		{
			InitializeComponent();

			Content = CreateStrikeZoneContent();
		}

		private View CreateStrikeZoneContent()
		{
			var stackLayout = new StackLayout
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};

			stackLayout.Children.Add(CreateTopRow());
			stackLayout.Children.Add(CreateMiddleRow());
			stackLayout.Children.Add(CreateBottomRow());

			return stackLayout;
		}

		private View CreateZone(string btnText,
								Color backgroundColor,
								LayoutOptions horizontalOptions)
		{
			var zoneButton = new Button()
			{
				Text = btnText,
				TextColor = Color.Black,
				WidthRequest = 75,
				HeightRequest = 75,
				BorderRadius = 3,
				BackgroundColor = backgroundColor,
				HorizontalOptions = horizontalOptions
			};

			zoneButton.Clicked += OnButtonClicked;

			return zoneButton;
		}

		void OnButtonClicked(object sender, EventArgs e)
		{
			var btn = (Button)sender;

			btn.BackgroundColor = Color.Red;
		}

		private View CreateTopRow()
		{
			var stackLayoutRow = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.Center
			};

			stackLayoutRow.Children.Add(CreateZone("1", Color.Gray, LayoutOptions.Start));
			stackLayoutRow.Children.Add(CreateZone("2", Color.Gray, LayoutOptions.Center));
			stackLayoutRow.Children.Add(CreateZone("3", Color.Gray, LayoutOptions.End));

			return stackLayoutRow;
		}

		private View CreateMiddleRow()
		{
			var stackLayoutRow = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.Center
			};

			stackLayoutRow.Children.Add(CreateZone("4", Color.Gray, LayoutOptions.Start));
			stackLayoutRow.Children.Add(CreateZone("5", Color.Gray, LayoutOptions.Center));
			stackLayoutRow.Children.Add(CreateZone("6", Color.Gray, LayoutOptions.End));

			return stackLayoutRow;
		}

		private View CreateBottomRow()
		{
			var stackLayoutRow = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.Center
			};

			stackLayoutRow.Children.Add(CreateZone("7", Color.Gray, LayoutOptions.Start));
			stackLayoutRow.Children.Add(CreateZone("8", Color.Gray, LayoutOptions.Center));
			stackLayoutRow.Children.Add(CreateZone("9", Color.Gray, LayoutOptions.End));

			return stackLayoutRow;
		}
	}
}

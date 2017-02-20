using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Demo
{
	public partial class StrikeZonePage : ContentPage
	{
		public StrikeZonePage()
		{
			InitializeComponent();

			Content = CreateContent();
		}

		private View CreateContent()
		{
			var statusLabel = new Label
			{
				Text = "It was a strike...",
				TextColor = Color.Black,
				HorizontalTextAlignment = TextAlignment.Center
			};

			var stackLayout = new StackLayout
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};

			stackLayout.Children.Add(new StrikeZoneView());
			stackLayout.Children.Add(statusLabel);

			return stackLayout;
		}
	}
}

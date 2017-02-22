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

			SwipeGesture = new PanGestureRecognizer();

			SwipeGesture.PanUpdated += OnSwipeUpdated;

			Content.GestureRecognizers.Add(SwipeGesture);
		}

		private PanGestureRecognizer SwipeGesture { get; set; }

		private View StrikeZone { get; set; }

		public Label StatusLabel { get; set; }

		private View CreateContent()
		{
			StatusLabel = new Label
			{
				Text = "Start Value...",
				TextColor = Color.Black,
				HorizontalTextAlignment = TextAlignment.Center
			};

			StatusLabel.SetBinding(Label.TextProperty, StatusLabel.ToString());

			var stackLayout = new StackLayout
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};

			StrikeZone = new StrikeZoneView();

			stackLayout.Children.Add(StrikeZone);
			stackLayout.Children.Add(StatusLabel);

			stackLayout.Children.Add(new StrikeZoneStatView());

			return stackLayout;
		}

		void OnSwipeUpdated(object sender, PanUpdatedEventArgs e)
		{
			switch (e.StatusType)
			{
				case GestureStatus.Started:
					HandleVerticalTouchStart(e);
					break;
				case GestureStatus.Running:
					HandleVerticalTouch((float)e.TotalY);
					break;
				case GestureStatus.Completed:
					HandleVerticalTouchEnd();
					break;
			}
		}

		private void HandleVerticalTouchStart(PanUpdatedEventArgs e)
		{
			var horizontal = e.TotalX;
			var vertical = e.TotalY;
		}

		private void HandleVerticalTouch(double verticalLength)
		{
			StatusLabel.Text = verticalLength.ToString();

			if (verticalLength >= 1)
			{
				this.Content = new StrikeZoneStatView();
				Content.GestureRecognizers.Add(SwipeGesture);
			}
			else
			{
				this.Content = StrikeZone;
				Content.GestureRecognizers.Add(SwipeGesture);
			}
		}

		private void HandleVerticalTouchEnd()
		{

		}
	}
}

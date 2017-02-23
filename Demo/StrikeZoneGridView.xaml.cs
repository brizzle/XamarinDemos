using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Demo
{
	public partial class StrikeZoneGridView : ContentView
	{
		public StrikeZoneGridView()
		{
			InitializeComponent();

			this.Content = CreateContent();

			_swipeGesture = new PanGestureRecognizer();

			_swipeGesture.PanUpdated += OnSwipeUpdated;

			Content.GestureRecognizers.Add(_swipeGesture);
		}

		private Grid _grid { get; set; }

		private PanGestureRecognizer _swipeGesture { get; set; }

		private AbsoluteLayout _absolute { get; set; }

		private View CreateContent()
		{
			_grid = new Grid
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};

			_grid.Children.Add(CreateZone("1", Color.Black), 0, 0);
			_grid.Children.Add(CreateZone("2", Color.Black), 1, 0);
			_grid.Children.Add(CreateZone("3", Color.Black), 2, 0);
			_grid.Children.Add(CreateZone("4", Color.Black), 0, 1, 1, 2);
			_grid.Children.Add(CreateZone("5", Color.Black), 1, 2, 1, 2);
			_grid.Children.Add(CreateZone("6", Color.Black), 2, 3, 1, 2);
			_grid.Children.Add(CreateZone("7", Color.Black), 0, 1, 2, 3);
			_grid.Children.Add(CreateZone("8", Color.Black), 1, 2, 2, 3);

			var zone = CreateZone("9", Color.Black);
			_grid.Children.Add(zone, 2, 3, 2, 3);

			_absolute = new AbsoluteLayout();

			var bounds = _absolute.Bounds;

			_absolute.Children.Add(_grid);

			var label = new Label
			{
				Text = "View # 2",
				TextColor = Color.Red,
				BackgroundColor = Color.Gray
			};

			_absolute.Children.Add(label);

			return _absolute;
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

		public delegate void Action();

		private async void OnButtonClicked(object sender, EventArgs e)
		{
			var btn = (Button)sender;

			btn.BackgroundColor = Color.Red;

			await Sleep(2000, btn);
		}

		public async Task Sleep(int ms, Button btn)
		{
			await Task.Delay(ms);

			btn.BackgroundColor = Color.Blue;

			await Task.Delay(ms);

			btn.BackgroundColor = Color.Black;
		}

		void OnCallBack(object sender, EventArgs e)
		{
			var btn = (Button)sender;

			btn.BackgroundColor = Color.Black;
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

		private async void HandleVerticalTouch(double verticalLength)
		{
			//var bounds = _absolute.Bounds;

			var moved = _grid.Bounds.Y + verticalLength;

			if (moved <= _absolute.Bounds.Y)
			{
				moved = _absolute.Bounds.Y;
			}
			//else if (moved >= _absolute.Bounds.Bottom)
			//{
			//	moved = _absolute.Bounds.Bottom;
			//}

			var rect = new Rectangle(0, moved, _grid.Bounds.Width, _grid.Bounds.Height);

			await _grid.LayoutTo(rect, 250, Easing.BounceIn);
		}

		private void HandleVerticalTouchEnd()
		{

		}
	}
}

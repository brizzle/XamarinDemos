using System;

using Xamarin.Forms;

namespace Demo
{
	public partial class StartPage : ContentPage
	{
		public StartPage()
		{
			InitializeComponent();

			this.Content = StartView;
		}

		private View _startView;

		private Button _backButton;

		public View StartView
		{
			get
			{
				if (_startView == null)
				{
					_startView = CreateContent();
				}

				return _startView;
			}
		}

		public Button BackButton
		{
			get
			{
				if (_backButton == null)
				{
					_backButton = new Button
					{
						Text = "Back",
						TextColor = Color.White,
						FontSize = 16,
						BackgroundColor = Color.Black,
						BorderRadius = 3,
						BorderColor = Color.Red
					};

					_backButton.Clicked += OnBackClicked;
				}

				return _backButton;
			}
		}

		private View CreateContent()
		{
			var stackLayout = new StackLayout
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};

			var strikeZoneBtn = new Button
			{
				Text = "Stack Layout",
				TextColor = Color.White,
				BackgroundColor = Color.Black,
				FontSize = 16,
				BorderRadius = 3,
				BorderColor = Color.Red
			};

			strikeZoneBtn.Clicked += OnStackLayoutButtonClicked;

			var gridBtn = new Button
			{
				Text = "Grid",
				TextColor = Color.White,
				BackgroundColor = Color.Black,
				FontSize = 16,
				BorderRadius = 3,
				BorderColor = Color.Red
			};

			gridBtn.Clicked += OnGridButtonClicked;

			stackLayout.Children.Add(strikeZoneBtn);
			stackLayout.Children.Add(gridBtn);

			return stackLayout;
		}

		void OnStackLayoutButtonClicked(object sender, EventArgs e)
		{
			var stackLayout = new StackLayout
			{
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center
			};

			stackLayout.Children.Add(new StrikeZoneView());
			stackLayout.Children.Add(BackButton);

			this.Content = stackLayout;
		}

		void OnGridButtonClicked(object sender, EventArgs e)
		{
			var stackLayout = new StackLayout
			{
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center
			};

			stackLayout.Children.Add(new MyGridView());
			stackLayout.Children.Add(BackButton);

			this.Content = stackLayout;
		}

		void OnBackClicked(object sender, EventArgs e)
		{
			this.Content = StartView;
		}
	}
}

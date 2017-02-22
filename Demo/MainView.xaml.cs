using System;
using Xamarin.Forms;

namespace Demo
{
	public partial class MainView : ContentView
	{
		public MainView()
		{
			InitializeComponent();

			this.Content = CreateContent();
		}

		private View CreateContent()
		{
			var stackLayout = new StackLayout
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};

			var btn = new Button
			{
				Text = "Click Me...",
				TextColor = Color.Black,
				BackgroundColor = Color.Gray
			};

			btn.Clicked += OnButtonClicked;

			stackLayout.Children.Add(btn);

			return stackLayout;
		}

		void OnButtonClicked(object sender, EventArgs e)
		{
			var btn = (Button)sender;

			btn.BackgroundColor = Color.Red;
		}
	}
}

using Xamarin.Forms;

namespace Demo
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			//MainPage = new StrikeZonePage();
			MainPage = new StartPage();
		}

		static public int ScreenWidth { get; set; }
		static public int ScreenHeight { get; set; }

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

namespace Xamanimation.Sample
{
    using System.Diagnostics;
    using Views;
    using Xamarin.Forms;

    public partial class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage(new AnimationsView());
        }

        protected override void OnStart()
        {
            Debug.WriteLine("OnStart");
        }

        protected override void OnSleep()
        {
            Debug.WriteLine("OnSleep");
        }

        protected override void OnResume()
        {
            Debug.WriteLine("OnResume");
        }
    }
}
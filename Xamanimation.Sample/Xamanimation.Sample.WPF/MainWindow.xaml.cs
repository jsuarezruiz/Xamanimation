using Xamarin.Forms.Platform.WPF;

namespace Xamanimation.Sample.WPF
{
    public partial class MainWindow : FormsApplicationPage
    {
        public MainWindow()
        {
            InitializeComponent();
            Xamarin.Forms.Forms.Init();
            LoadApplication(new Sample.App());
        }
    }
}

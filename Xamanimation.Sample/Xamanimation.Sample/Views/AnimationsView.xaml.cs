namespace Xamanimation.Sample.Views
{
    using Xamarin.Forms;
    using Xamanimation;

    public partial class AnimationsView : TabbedPage
    {
        public AnimationsView()
        {
            InitializeComponent();

            AnimationExtensionButton.Clicked += async (sender, args) =>
            {
                await AnimationBox.Animate(new HeartAnimation());
            };
        }
    }
}
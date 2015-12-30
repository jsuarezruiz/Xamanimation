namespace Xamanimation.Sample.Views
{
    using Xamarin.Forms;
    using Xamanimation;

    public partial class AnimationsView : TabbedPage
    {
        public AnimationsView()
        {
            InitializeComponent();

            AnimationExtensionButton.Clicked += (sender, args) =>
            {
                AnimationBox.Animate(new HeartAnimation());
            };
        }
    }
}
namespace Xamanimation.Sample.Views
{
    using Xamarin.Forms;

    public partial class AnimationsShell : Shell
    {
        public AnimationsShell()
        {
            InitializeComponent();

            AnimationExtensionButton.Clicked += async (sender, args) =>
            {
                await AnimationBox.Animate(new HeartAnimation());
            };
        }
    }
}
namespace Xamanimation
{
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public static class AnimationExtensions
    {
        public static async Task<bool> Animate(this VisualElement visualElement, AnimationBase animation)
        {
            try
            {
                animation.Target = visualElement;

                await animation.Begin();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
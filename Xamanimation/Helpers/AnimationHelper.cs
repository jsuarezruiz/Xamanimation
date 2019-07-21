namespace Xamanimation.Helpers
{
    using Xamarin.Forms;

    public static class AnimationHelper
    {
        public static double GetCurrentValue(double from, double to, double animationProgress)
        {
            return from + (to - from) * animationProgress;
        }

        public static Color GetCurrentValue(Color from, Color to, double animationProgress)
        {
            var newR = (to.R - from.R) * animationProgress;
            var newG = (to.G - from.G) * animationProgress;
            var newB = (to.B - from.B) * animationProgress;
            return Color.FromRgb(from.R + newR, from.G + newG, from.B + newB);
        }
    }
}

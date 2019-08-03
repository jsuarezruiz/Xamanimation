namespace Xamanimation
{
    using Xamarin.Forms;

    public class AnimateProgressColor : AnimationProgressBaseBehavior
    {
        public static readonly BindableProperty FromProperty =
              BindableProperty.Create(nameof(From), typeof(Color), typeof(AnimationProgressBaseBehavior), default(Color),
                  BindingMode.TwoWay, null);

        public Color From
        {
            get { return (Color)GetValue(FromProperty); }
            set { SetValue(FromProperty, value); }
        }

        public static readonly BindableProperty ToProperty =
            BindableProperty.Create(nameof(To), typeof(Color), typeof(AnimationProgressBaseBehavior), default(Color),
                BindingMode.TwoWay, null);

        public Color To
        {
            get { return (Color)GetValue(ToProperty); }
            set { SetValue(ToProperty, value); }
        }

        protected override void OnUpdate()
        {
            if (From == Color.Default && To == Color.Default)
                return;

            if (From == Color.Default)
            {
                Target.SetValue(TargetProperty, To);
                return;
            }
            if (To == Color.Default)
            {
                Target.SetValue(TargetProperty, From);
                return;
            }

            var newR = (To.R - From.R) * Progress;
            var newG = (To.G - From.G) * Progress;
            var newB = (To.B - From.B) * Progress;
            Color value = Color.FromRgb((int)(From.R + newR), (int)(From.G + newG), (int)(From.B + newB));

            Target.SetValue(TargetProperty, value);
        }
    }
}
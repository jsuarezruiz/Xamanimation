namespace Xamanimation
{
    using Xamarin.Forms;

    public class AnimateProgressThickness : AnimationProgressBaseBehavior
    {
        public static readonly BindableProperty FromProperty =
            BindableProperty.Create(nameof(From), typeof(Thickness), typeof(AnimationProgressBaseBehavior), default(Thickness),
                BindingMode.TwoWay, null);

        public Thickness From
        {
            get { return (Thickness)GetValue(FromProperty); }
            set { SetValue(FromProperty, value); }
        }

        public static readonly BindableProperty ToProperty =
            BindableProperty.Create(nameof(To), typeof(Thickness), typeof(AnimationProgressBaseBehavior), default(Thickness),
                BindingMode.TwoWay, null);

        public Thickness To
        {
            get { return (Thickness)GetValue(ToProperty); }
            set { SetValue(ToProperty, value); }
        }

        protected override void OnUpdate()
        {
            if (Progress < Minimum)
                return;

            if (Progress >= Maximum)
                return;

            double? left = ((Progress - Minimum) * (To.Left - From.Left) / (Maximum - Minimum)) + From.Left;
            double? top = ((Progress - Minimum) * (To.Top - From.Top) / (Maximum - Minimum)) + From.Top;
            double? right = ((Progress - Minimum) * (To.Right - From.Right) / (Maximum - Minimum)) + From.Right;
            double? bottom = ((Progress - Minimum) * (To.Bottom - From.Bottom) / (Maximum - Minimum)) + From.Bottom;

            Thickness value = new Thickness(left.Value, top.Value, right.Value, bottom.Value);

            Target.SetValue(TargetProperty, value);
        }
    }
}
namespace Xamanimation
{
    using Xamarin.Forms;

    public class AnimateProgressCornerRadius : AnimationProgressBaseBehavior
    {
        public static readonly BindableProperty FromProperty =
            BindableProperty.Create(nameof(From), typeof(CornerRadius), typeof(AnimationProgressBaseBehavior), default(CornerRadius),
                BindingMode.TwoWay, null);

        public CornerRadius From
        {
            get { return (CornerRadius)GetValue(FromProperty); }
            set { SetValue(FromProperty, value); }
        }

        public static readonly BindableProperty ToProperty =
            BindableProperty.Create(nameof(To), typeof(CornerRadius), typeof(AnimationProgressBaseBehavior), default(CornerRadius),
                BindingMode.TwoWay, null);

        public CornerRadius To
        {
            get { return (CornerRadius)GetValue(ToProperty); }
            set { SetValue(ToProperty, value); }
        }

        protected override void OnUpdate()
        {
            if (Progress < Minimum)
                return;

            if (Progress >= Maximum)
                return;

            double? topLeft = ((Progress - Minimum) * (To.TopLeft - From.TopLeft) / (Maximum - Minimum)) + From.TopLeft;
            double? topRight = ((Progress - Minimum) * (To.TopRight - From.TopRight) / (Maximum - Minimum)) + From.TopRight;
            double? bottomLeft = ((Progress - Minimum) * (To.BottomLeft - From.BottomLeft) / (Maximum - Minimum)) + From.BottomLeft;
            double? bottomRight = ((Progress - Minimum) * (To.BottomRight - From.BottomRight) / (Maximum - Minimum)) + From.BottomRight;

            CornerRadius value = new CornerRadius(topLeft.Value, topRight.Value, bottomLeft.Value, bottomRight.Value);

            Target.SetValue(TargetProperty, value);
        }
    }
}
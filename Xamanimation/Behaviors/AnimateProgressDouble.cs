namespace Xamanimation
{
    using Xamarin.Forms;

    public class AnimateProgressDouble : AnimationProgressBaseBehavior
    {
        public static readonly BindableProperty FromProperty =
            BindableProperty.Create(nameof(From), typeof(double), typeof(AnimationProgressBaseBehavior), default(double),
                BindingMode.TwoWay, null);

        public double From
        {
            get { return (double)GetValue(FromProperty); }
            set { SetValue(FromProperty, value); }
        }

        public static readonly BindableProperty ToProperty =
            BindableProperty.Create(nameof(To), typeof(double), typeof(AnimationProgressBaseBehavior), default(double),
                BindingMode.TwoWay, null);

        public double To
        {
            get { return (double)GetValue(ToProperty); }
            set { SetValue(ToProperty, value); }
        }

        public static readonly BindableProperty MultiplyValueProperty =
            BindableProperty.Create(nameof(MultiplyValue), typeof(double), typeof(AnimateProgressDouble), 1.0d,
                BindingMode.TwoWay, null);

        public double MultiplyValue
        {
            get { return (double)GetValue(MultiplyValueProperty); }
            set { SetValue(MultiplyValueProperty, value); }
        }

        protected override void OnUpdate()
        {
            if (Progress < Minimum)
                return;

            if (Progress >= Maximum)
                return;

            //Formula Used
            //Y = ((X - X1)*(Y2 - Y1) / (X2 - X1)) + Y1
            double? value = ((Progress - Minimum) * (To - From) / (Maximum - Minimum)) + From;

            Target.SetValue(TargetProperty, value.GetValueOrDefault() * MultiplyValue);
        }
    }
}

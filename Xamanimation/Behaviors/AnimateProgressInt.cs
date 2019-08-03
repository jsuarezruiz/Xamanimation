namespace Xamanimation.Behaviors
{
    using Xamarin.Forms;

    public class AnimateProgressInt : AnimationProgressBaseBehavior
    {
        public static readonly BindableProperty FromProperty =
            BindableProperty.Create(nameof(From), typeof(int), typeof(AnimationProgressBaseBehavior), default(int),
                BindingMode.TwoWay, null);

        public int From
        {
            get { return (int)GetValue(FromProperty); }
            set { SetValue(FromProperty, value); }
        }

        public static readonly BindableProperty ToProperty =
            BindableProperty.Create(nameof(To), typeof(int), typeof(AnimationProgressBaseBehavior), default(int),
                BindingMode.TwoWay, null);

        public int To
        {
            get { return (int)GetValue(ToProperty); }
            set { SetValue(ToProperty, value); }
        }

        protected override void OnUpdate()
        {
            if (Progress < Minimum)
                return;

            if (Progress >= Maximum)
                return;

            int? value = (int)(((Progress - Minimum) * (To - From) / (Maximum - Minimum)) + From);

            Target.SetValue(TargetProperty, value.GetValueOrDefault());
        }
    }
}
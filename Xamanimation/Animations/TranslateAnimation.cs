namespace Xamanimation
{
    using Helpers;
    using System;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public class TranslateToAnimation : AnimationBase
    {
        public static readonly BindableProperty TranslateXProperty =
           BindableProperty.Create<TranslateToAnimation, double>(p => p.TranslateX, 0,
           propertyChanged: (bindable, oldValue, newValue) =>
           ((TranslateToAnimation)bindable).TranslateX = newValue);

        public double TranslateX
        {
            get { return (double)GetValue(TranslateXProperty); }
            set { SetValue(TranslateXProperty, value); }
        }

        public static readonly BindableProperty TranslateYProperty =
           BindableProperty.Create<TranslateToAnimation, double>(p => p.TranslateY, 0,
           propertyChanged: (bindable, oldValue, newValue) =>
           ((TranslateToAnimation)bindable).TranslateY = newValue);

        public double TranslateY
        {
            get { return (double)GetValue(TranslateYProperty); }
            set { SetValue(TranslateYProperty, value); }
        }

        protected override Task BeginAnimation()
        {
            if (Target == null)
            {
                throw new NullReferenceException("Null Target property.");
            }

            return Target.TranslateTo(TranslateX, TranslateY, Convert.ToUInt32(Duration), EasingHelper.GetEasing(Easing));
        }
    }
}

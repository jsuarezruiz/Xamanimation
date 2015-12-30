namespace Xamanimation
{
    using Helpers;
    using System;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public class ScaleToAnimation : AnimationBase
    {
        public static readonly BindableProperty ScaleProperty =
         BindableProperty.Create<ScaleToAnimation, double>(p => p.Scale, 0,
         propertyChanged: (bindable, oldValue, newValue) =>
         ((ScaleToAnimation)bindable).Scale = newValue);

        public double Scale
        {
            get { return (double)GetValue(ScaleProperty); }
            set { SetValue(ScaleProperty, value); }
        }

        protected override Task BeginAnimation()
        {
            if (Target == null)
            {
                throw new NullReferenceException("Null Target property.");
            }

            return Target.ScaleTo(Scale, Convert.ToUInt32(Duration), EasingHelper.GetEasing(Easing));
        }
    }

    public class RelScaleToAnimation : AnimationBase
    {
        public static readonly BindableProperty ScaleProperty =
         BindableProperty.Create<RelScaleToAnimation, double>(p => p.Scale, 0,
         propertyChanged: (bindable, oldValue, newValue) =>
         ((RelScaleToAnimation)bindable).Scale = newValue);

        public double Scale
        {
            get { return (double)GetValue(ScaleProperty); }
            set { SetValue(ScaleProperty, value); }
        }

        protected override Task BeginAnimation()
        {
            if (Target == null)
            {
                throw new NullReferenceException("Null Target property.");
            }

            return Target.RelScaleTo(Scale, Convert.ToUInt32(Duration), EasingHelper.GetEasing(Easing));
        }
    }
}

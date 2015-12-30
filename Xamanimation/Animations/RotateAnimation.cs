namespace Xamanimation
{
    using Helpers;
    using System;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public class RotateToAnimation : AnimationBase
    {
        public static readonly BindableProperty RotationProperty =
            BindableProperty.Create<RotateToAnimation, double>(p => p.Rotation, 0,
            propertyChanged: (bindable, oldValue, newValue) =>
            ((RotateToAnimation)bindable).Rotation = newValue);

        public double Rotation
        {
            get { return (double)GetValue(RotationProperty); }
            set { SetValue(RotationProperty, value); }
        }

        protected override Task BeginAnimation()
        {
            if (Target == null)
            {
                throw new NullReferenceException("Null Target property.");
            }

            return Target.RotateTo(Rotation, Convert.ToUInt32(Duration), EasingHelper.GetEasing(Easing));
        }
    }

    public class RelRotateToAnimation : AnimationBase
    {
        public static readonly BindableProperty RotationProperty =
            BindableProperty.Create<RelRotateToAnimation, double>(p => p.Rotation, 0,
            propertyChanged: (bindable, oldValue, newValue) =>
            ((RelRotateToAnimation)bindable).Rotation = newValue);

        public double Rotation
        {
            get { return (double)GetValue(RotationProperty); }
            set { SetValue(RotationProperty, value); }
        }

        protected override Task BeginAnimation()
        {
            if (Target == null)
            {
                throw new NullReferenceException("Null Target property.");
            }

            return Target.RelRotateTo(Rotation, Convert.ToUInt32(Duration), EasingHelper.GetEasing(Easing));
        }
    }

    public class RotateXToAnimation : AnimationBase
    {
        public static readonly BindableProperty RotationProperty =
            BindableProperty.Create<RotateXToAnimation, double>(p => p.Rotation, 0,
            propertyChanged: (bindable, oldValue, newValue) =>
            ((RotateXToAnimation)bindable).Rotation = newValue);

        public double Rotation
        {
            get { return (double)GetValue(RotationProperty); }
            set { SetValue(RotationProperty, value); }
        }

        protected override Task BeginAnimation()
        {
            if (Target == null)
            {
                throw new NullReferenceException("Null Target property.");
            }

            return Target.RotateXTo(Rotation, Convert.ToUInt32(Duration), EasingHelper.GetEasing(Easing));
        }
    }

    public class RotateYToAnimation : AnimationBase
    {
        public static readonly BindableProperty RotationProperty =
            BindableProperty.Create<RotateYToAnimation, double>(p => p.Rotation, 0,
            propertyChanged: (bindable, oldValue, newValue) =>
            ((RotateYToAnimation)bindable).Rotation = newValue);

        public double Rotation
        {
            get { return (double)GetValue(RotationProperty); }
            set { SetValue(RotationProperty, value); }
        }

        protected override Task BeginAnimation()
        {
            if (Target == null)
            {
                throw new NullReferenceException("Null Target property.");
            }

            return Target.RotateYTo(Rotation, Convert.ToUInt32(Duration), EasingHelper.GetEasing(Easing));
        }
    }
}

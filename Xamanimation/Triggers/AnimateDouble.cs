namespace Xamanimation
{
    using System;
    using Xamanimation.Helpers;
    using Xamarin.Forms;

    public class AnimateDouble : AnimationBaseTrigger<double>
    {
        protected override void Invoke(VisualElement sender)
        {
            if (TargetProperty == null)
            {
                throw new NullReferenceException("Null Target property.");
            }

            SetDefaultFrom((double)sender.GetValue(TargetProperty));

            sender.Animate($"AnimateDouble{TargetProperty.PropertyName}", new Animation((progress) =>
             {
                 sender.SetValue(TargetProperty, AnimationHelper.GetCurrentValue(From, To, progress));
             }),
            length: Duration,
            easing: EasingHelper.GetEasing(Easing));
        }
    }
}

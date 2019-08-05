namespace Xamanimation
{
    using System;
    using System.Threading.Tasks;
    using Xamanimation.Helpers;
    using Xamarin.Forms;

    public class AnimateDouble : AnimationBaseTrigger<double>
    {
        protected override async void Invoke(VisualElement sender)
        {
            if (TargetProperty == null)
            {
                throw new NullReferenceException("Null Target property.");
            }

            if (Delay > 0)
                await Task.Delay(Delay);

            SetDefaultFrom((double)sender.GetValue(TargetProperty));

            sender.Animate($"AnimateDouble{TargetProperty.PropertyName}", new Animation((progress) =>
            {
                sender.SetValue(TargetProperty, AnimationHelper.GetDoubleValue(From, To, progress));
            }),
            length: Duration,
            easing: EasingHelper.GetEasing(Easing));
        }
    }
}

namespace Xamanimation.Triggers
{
    using System;
    using System.Threading.Tasks;
    using Xamanimation.Helpers;
    using Xamarin.Forms;

    public class AnimateInt : AnimationBaseTrigger<double>
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

            sender.Animate($"AnimateInt{TargetProperty.PropertyName}", new Animation((progress) =>
            {
                sender.SetValue(TargetProperty, AnimationHelper.GetIntValue((int)From, (int)To, progress));
            }),
            length: Duration,
            easing: EasingHelper.GetEasing(Easing));
        }
    }
}
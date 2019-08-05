namespace Xamanimation.Triggers
{
    using System;
    using System.Threading.Tasks;
    using Xamanimation.Helpers;
    using Xamarin.Forms;

    public class AnimateThickness : AnimationBaseTrigger<Thickness>
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

            sender.Animate($"AnimateThickness{TargetProperty.PropertyName}", new Animation((progress) =>
            {
                sender.SetValue(TargetProperty, AnimationHelper.GetThicknessValue(From, To, progress));
            }),
            length: Duration,
            easing: EasingHelper.GetEasing(Easing));
        }
    }
}

namespace Xamanimation.Triggers
{
    using System;
    using System.Threading.Tasks;
    using Xamanimation.Helpers;
    using Xamarin.Forms;

    public class AnimateCornerRadius : AnimationBaseTrigger<CornerRadius>
    {
        protected override async void Invoke(VisualElement sender)
        {
            if (TargetProperty == null)
            {
                throw new NullReferenceException("Null Target property.");
            }

            if (Delay > 0)
                await Task.Delay(Delay);

            SetDefaultFrom((CornerRadius)sender.GetValue(TargetProperty));

            sender.Animate($"AnimateCornerRadius{TargetProperty.PropertyName}", new Animation((progress) =>
            {
                sender.SetValue(TargetProperty, AnimationHelper.GetCornerRadiusValue(From, To, progress));
            }),
            length: Duration,
            easing: EasingHelper.GetEasing(Easing));
        }
    }
}
namespace Xamanimation
{
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public abstract class AnimationBase : BindableObject
    {
        public static readonly BindableProperty TargetProperty =
        BindableProperty.Create<AnimationBase, VisualElement>(p => p.Target, null,
        propertyChanged: (bindable, oldValue, newValue) =>
        ((AnimationBase)bindable).Target = newValue);

        public VisualElement Target
        {
            get { return (VisualElement)GetValue(TargetProperty); }
            set { SetValue(TargetProperty, value); }
        }

        public static readonly BindableProperty DurationProperty =
            BindableProperty.Create<AnimationBase, string>(p => p.Duration, "1000",
                propertyChanged: (bindable, oldValue, newValue) =>
                ((AnimationBase)bindable).Duration = newValue);

        public string Duration
        {
            get { return (string)GetValue(DurationProperty); }
            set { SetValue(DurationProperty, value); }
        }

        public static readonly BindableProperty EasingProperty =
            BindableProperty.Create<AnimationBase, EasingType>(p => p.Easing, EasingType.Linear,
            propertyChanged: (bindable, oldValue, newValue) =>
            ((AnimationBase)bindable).Easing = newValue);

        public EasingType Easing
        {
            get { return (EasingType)GetValue(EasingProperty); }
            set { SetValue(EasingProperty, value); }
        }

        protected abstract Task BeginAnimation();

        public async Task Begin()
        {
            await BeginAnimation();
        }
    }
}

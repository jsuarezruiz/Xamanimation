namespace Xamanimation
{
    using System.Threading;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public abstract class AnimationBase : BindableObject
    {
        private CancellationTokenSource _animateTimerCancellationTokenSource;

        public static readonly BindableProperty TargetProperty =
            BindableProperty.Create(nameof(Target), typeof(VisualElement), typeof(AnimationBase), null,
                BindingMode.TwoWay, null);

        public VisualElement Target
        {
            get { return (VisualElement)GetValue(TargetProperty); }
            set { SetValue(TargetProperty, value); }
        }

        public static readonly BindableProperty DurationProperty =
            BindableProperty.Create(nameof(Duration), typeof(string), typeof(AnimationBase), "1000",
                BindingMode.TwoWay, null);

        public string Duration
        {
            get { return (string)GetValue(DurationProperty); }
            set { SetValue(DurationProperty, value); }
        }

        public static readonly BindableProperty EasingProperty =
            BindableProperty.Create(nameof(Easing), typeof(EasingType), typeof(AnimationBase), EasingType.Linear,
                BindingMode.TwoWay, null);

        public EasingType Easing
        {
            get { return (EasingType)GetValue(EasingProperty); }
            set { SetValue(EasingProperty, value); }
        }

        public static readonly BindableProperty DelayProperty =
          BindableProperty.Create("Delay", typeof(int), typeof(AnimationBase), 0, propertyChanged: (bindable, oldValue, newValue) =>
              ((AnimationBase)bindable).Delay = (int)newValue);

        public int Delay
        {
            get { return (int)GetValue(DelayProperty); }
            set { SetValue(DelayProperty, value); }
        }

        public static readonly BindableProperty RepeatForeverProperty =
          BindableProperty.Create("RepeatForever", typeof(bool), typeof(AnimationBase), false, propertyChanged: (bindable, oldValue, newValue) =>
              ((AnimationBase)bindable).RepeatForever = (bool)newValue);

        public bool RepeatForever
        {
            get { return (bool)GetValue(RepeatForeverProperty); }
            set { SetValue(RepeatForeverProperty, value); }
        }

        protected abstract Task BeginAnimation();

        public async Task Begin()
        {
            if (Delay > 0)
            {
                await Task.Delay(Delay);
            }

            if (!RepeatForever)
            {
                await BeginAnimation();
            }
            else
            {
                RepeatAnimation(new CancellationTokenSource());
            }
        }

        public void End()
        {
            ViewExtensions.CancelAnimations(Target);

            if (_animateTimerCancellationTokenSource != null)
            {
                _animateTimerCancellationTokenSource.Cancel();
            }
        }

        internal void RepeatAnimation(CancellationTokenSource tokenSource)
        {
            _animateTimerCancellationTokenSource = tokenSource;

            Device.BeginInvokeOnMainThread(async () =>
            {
                if (!_animateTimerCancellationTokenSource.IsCancellationRequested)
                {
                    await BeginAnimation();

                    RepeatAnimation(_animateTimerCancellationTokenSource);
                }
            });
        }
    }
}
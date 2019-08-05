namespace Xamanimation
{
    using Xamarin.Forms;

    public abstract class AnimationProgressBaseBehavior : Behavior<VisualElement>
    {
        public static readonly BindableProperty ProgressProperty =
               BindableProperty.Create(nameof(Progress), typeof(double?), typeof(AnimationProgressBaseBehavior), default(double),
                   BindingMode.TwoWay, null, OnChanged);

        public double? Progress
        {
            get { return (double?)GetValue(ProgressProperty); }
            set { SetValue(ProgressProperty, value); }
        }
            
        public static readonly BindableProperty MinimumProperty =
            BindableProperty.Create(nameof(Minimum), typeof(double), typeof(AnimationProgressBaseBehavior), 0.0d,
                BindingMode.TwoWay, null);

        public double Minimum
        {
            get { return (double)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        public static readonly BindableProperty MaximumProperty =
           BindableProperty.Create(nameof(Maximum), typeof(double), typeof(AnimationProgressBaseBehavior), 100.0d,
               BindingMode.TwoWay, null);

        public double Maximum
        {
            get { return (double)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }
                
        public static readonly BindableProperty EasingProperty =
           BindableProperty.Create(nameof(Easing), typeof(EasingType), typeof(AnimationProgressBaseBehavior), EasingType.Linear,
               BindingMode.TwoWay, null);

        public EasingType Easing
        {
            get { return (EasingType)GetValue(EasingProperty); }
            set { SetValue(EasingProperty, value); }
        }

        public static readonly BindableProperty TargetPropertyProperty =
          BindableProperty.Create(nameof(TargetProperty), typeof(BindableProperty), typeof(AnimationProgressBaseBehavior), null,
              BindingMode.TwoWay, null);

        public BindableProperty TargetProperty
        {
            get { return (BindableProperty)GetValue(TargetPropertyProperty); }
            set { SetValue(TargetPropertyProperty, value); }
        }

        public VisualElement Target
        {
            get;
            private set;
        }

        protected override void OnAttachedTo(VisualElement bindable)
        {
            Target = bindable;
            Update();
            base.OnAttachedTo(bindable);
        }

        protected static void OnChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((AnimationProgressBaseBehavior)bindable).Update();
        }

        protected override void OnDetachingFrom(VisualElement bindable)
        {
            base.OnDetachingFrom(bindable);
            Target = null;
        }

        protected abstract void OnUpdate();

        protected void Update()
        {
            if (Target != null && Progress.HasValue)
            {
                OnUpdate();
            }
        }
    }
}
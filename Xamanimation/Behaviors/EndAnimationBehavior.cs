namespace Xamanimation
{
    using Xamarin.Forms;

    public class EndAnimationBehavior : Behavior<VisualElement>
    {
        private static VisualElement associatedObject;

        protected override void OnAttachedTo(VisualElement bindable)
        {
            base.OnAttachedTo(bindable);
            associatedObject = bindable;

            if (Animation != null)
            {
                if (Animation.Target == null)
                {
                    Animation.Target = associatedObject;
                }

                Animation.End();
            }
        }

        protected override void OnDetachingFrom(VisualElement bindable)
        {
            associatedObject = null;
            base.OnDetachingFrom(bindable);
        }

        public static readonly BindableProperty AnimationProperty =
          BindableProperty.Create(nameof(Animation), typeof(AnimationBase), typeof(BeginAnimationBehavior), null,
              BindingMode.TwoWay, null);

        public AnimationBase Animation
        {
            get { return (AnimationBase)GetValue(AnimationProperty); }
            set { SetValue(AnimationProperty, value); }
        }
    }
}
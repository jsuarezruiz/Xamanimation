namespace Xamanimation
{
    using Xamarin.Forms;

    public class EndAnimation : TriggerAction<VisualElement>
    {
        public AnimationBase Animation { get; set; }

        protected override void Invoke(VisualElement sender)
        {
            if (Animation != null)
                Animation.End();
        }
    }
}

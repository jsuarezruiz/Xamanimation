namespace Xamanimation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xamanimation.Helpers;
    using Xamarin.Forms;

    public class EntranceTransition : Behavior<VisualElement>
    {
        const int Delay = 100;
        const int TranslateFrom = 6;

        private VisualElement _associatedObject;
        private IEnumerable<VisualElement> _childrens;

        public static readonly BindableProperty DurationProperty =
            BindableProperty.Create(nameof(Duration), typeof(string), typeof(EntranceTransition), "500",
                BindingMode.TwoWay, null);

        public string Duration
        {
            get { return (string)GetValue(DurationProperty); }
            set { SetValue(DurationProperty, value); }
        }

        protected override void OnAttachedTo(VisualElement bindable)
        {
            base.OnAttachedTo(bindable);
            _associatedObject = bindable;
            _childrens = VisualTreeHelper.GetChildren<VisualElement>(_associatedObject);
            _associatedObject.PropertyChanged += OnPropertyChanged;
        }

        protected override void OnDetachingFrom(VisualElement bindable)
        {
            StopAnimation();
            _associatedObject.PropertyChanged -= OnPropertyChanged;
            _associatedObject = null;
            _childrens = null;
            base.OnDetachingFrom(bindable);
        }

        async void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Renderer")
            {
                await StartAnimationAsync();
            }
        }

        void SetInitialTransitionState()
        {
            if (_childrens.Any())
            {
                foreach (var child in _childrens)
                    SetInitialTransitionState(child);
            }
            else
                SetInitialTransitionState(_associatedObject);
        }

        void SetInitialTransitionState(VisualElement element)
        {
            element.Opacity = 0;
            element.TranslationX = _associatedObject.TranslationX + TranslateFrom;
            element.TranslationY = _associatedObject.TranslationY + TranslateFrom;
        }

        void StopAnimation()
        {
            if (_childrens.Any())
            {
                foreach (var child in _childrens)
                    ViewExtensions.CancelAnimations(child);
            }
            else
                ViewExtensions.CancelAnimations(_associatedObject);
        }

        async Task StartAnimationAsync()
        {
            StopAnimation();
            SetInitialTransitionState();

            if (_childrens.Any())
            {
                foreach (var child in _childrens)
                    await AnimateItemAsync(child);
            }
            else
            {
                if(!HasParentEntranceTransition(_associatedObject))
                    await AnimateItemAsync(_associatedObject);
            }
        }

        async Task AnimateItemAsync(VisualElement element)
        {
            await Task.Delay(Delay);

            var parentAnimation = new Animation();

            var translateXAnimation = new Animation(v => element.TranslationX = v, element.TranslationX, 0, Easing.SpringIn);
            var translateYAnimation = new Animation(v => element.TranslationY = v, element.TranslationY, 0, Easing.SpringIn);
            var opacityAnimation = new Animation(v => element.Opacity = v, 0, 1, Easing.CubicIn);

            parentAnimation.Add(0, 0.75, translateXAnimation);
            parentAnimation.Add(0, 0.75, translateYAnimation);
            parentAnimation.Add(0, 1, opacityAnimation);

            parentAnimation.Commit(_associatedObject, "EntranceTransition" + element.Id, 16, Convert.ToUInt32(Duration), null, (v, c) => StopAnimation());
        }

        bool HasParentEntranceTransition(VisualElement element)
        {
            VisualElement parent = VisualTreeHelper.GetParent<VisualElement>(element);
            var behaviors = parent.Behaviors;
            return behaviors.OfType<EntranceTransition>().FirstOrDefault() != null;
        }
    }
}
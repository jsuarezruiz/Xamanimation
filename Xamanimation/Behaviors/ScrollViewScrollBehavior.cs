using System;
using Xamarin.Forms;

namespace Xamanimation
{
    public class ScrollViewScrollBehavior : Behavior<ScrollView>
    {
        public static readonly BindableProperty ScrollXProperty =
            BindableProperty.Create(nameof(ScrollX), typeof(double), typeof(ScrollViewScrollBehavior), default(double),
                BindingMode.TwoWay, null);

        /// <summary>
        /// The horizontal scroll value in pixels.
        /// </summary>
        public double ScrollX
        {
            get { return (double)GetValue(ScrollXProperty); }
            set { SetValue(ScrollXProperty, value); }
        }

        public static readonly BindableProperty ScrollYProperty =
            BindableProperty.Create(nameof(ScrollY), typeof(double), typeof(ScrollViewScrollBehavior), default(double),
                BindingMode.TwoWay, null);

        /// <summary>
        /// The vertical scroll value in pixels.
        /// </summary>
        public double ScrollY
        {
            get { return (double)GetValue(ScrollYProperty); }
            set { SetValue(ScrollYProperty, value); }
        }

        public static readonly BindableProperty RelativeScrollXProperty =
           BindableProperty.Create(nameof(RelativeScrollX), typeof(double), typeof(ScrollViewScrollBehavior), default(double),
               BindingMode.TwoWay, null);

        /// <summary>
        /// The horizontal scroll value between 0 and 1.
        /// </summary>
        public double RelativeScrollX
        {
            get { return (double)GetValue(RelativeScrollXProperty); }
            set { SetValue(RelativeScrollXProperty, value); }
        }

        public static readonly BindableProperty RelativeScrollYProperty =
            BindableProperty.Create(nameof(RelativeScrollY), typeof(double), typeof(ScrollViewScrollBehavior), default(double),
                BindingMode.TwoWay, null);

        /// <summary>
        /// The vertical scroll value between 0 and 1.
        /// </summary>
        public double RelativeScrollY
        {
            get { return (double)GetValue(RelativeScrollYProperty); }
            set { SetValue(RelativeScrollYProperty, value); }
        }

        public static readonly BindableProperty PercentageScrollXProperty =
            BindableProperty.Create(nameof(PercentageScrollX), typeof(double), typeof(ScrollViewScrollBehavior), default(double),
                BindingMode.TwoWay, null);

        /// <summary>
        /// The horizontal scroll value between 0% and 100%.
        /// </summary>
        public double PercentageScrollX
        {
            get { return (double)GetValue(PercentageScrollXProperty); }
            set { SetValue(PercentageScrollXProperty, value); }
        }

        public static readonly BindableProperty PercentageScrollYProperty =
            BindableProperty.Create(nameof(PercentageScrollY), typeof(double), typeof(ScrollViewScrollBehavior), default(double),
            BindingMode.TwoWay, null);

        /// <summary>
        /// The vertical scroll value between 0% and 100%.
        /// </summary>
        public double PercentageScrollY
        {
            get { return (double)GetValue(PercentageScrollYProperty); }
            set { SetValue(PercentageScrollYProperty, value); }
        }

        protected override void OnAttachedTo(ScrollView bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.Scrolled += new EventHandler<ScrolledEventArgs>(OnScrolled);
        }

        protected override void OnDetachingFrom(ScrollView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.Scrolled -= new EventHandler<ScrolledEventArgs>(OnScrolled);
        }

        private void OnScrolled(object sender, ScrolledEventArgs e)
        {
            ScrollY = e.ScrollY;
            ScrollX = e.ScrollX;

            ScrollView scrollView = (ScrollView)sender;
            Size contentSize = scrollView.ContentSize;

            var viewportHeight = contentSize.Height - scrollView.Height;
            var viewportWidth = contentSize.Width - scrollView.Width;

            RelativeScrollY = viewportHeight <= 0 ? 0 : e.ScrollY / viewportHeight;
            RelativeScrollX = viewportWidth <= 0 ? 0 : e.ScrollX / viewportWidth;

            PercentageScrollX = RelativeScrollX * 100;
            PercentageScrollY = RelativeScrollY * 100;
        }
    }
}
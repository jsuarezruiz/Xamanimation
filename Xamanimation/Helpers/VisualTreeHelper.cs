namespace Xamanimation.Helpers
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Xamarin.Forms;

    public static class VisualTreeHelper
    {
        public static T GetParent<T>(this Element element) where T : Element
        {
            if (element is T)
            {
                return element as T;
            }
            else
            {
                if (element.Parent != null)
                {
                    return element.Parent.GetParent<T>();
                }

                return default(T);
            }
        }

        public static IEnumerable<T> GetChildren<T>(this Element element) where T : Element
        {
            var properties = element.GetType().GetRuntimeProperties();

            var contentProperty = properties.FirstOrDefault(w => w.Name == "Content");
            if (contentProperty != null)
            {
                if (contentProperty.GetValue(element) is Element content)
                {
                    if (content is T)
                    {
                        yield return content as T;
                    }
                    foreach (var child in content.GetChildren<T>())
                    {
                        yield return child;
                    }
                }
            }
            else
            {
                var childrenProperty = properties.FirstOrDefault(w => w.Name == "Children");
                if (childrenProperty != null)
                {
                    IEnumerable children = childrenProperty.GetValue(element) as IEnumerable;
                    foreach (var child in children)
                    {
                        if (child is Element childVisualElement)
                        {
                            if (childVisualElement is T)
                            {
                                yield return childVisualElement as T;
                            }

                            foreach (var childVisual in childVisualElement.GetChildren<T>())
                            {
                                yield return childVisual;
                            }
                        }
                    }
                }
            }
        }
    }
}
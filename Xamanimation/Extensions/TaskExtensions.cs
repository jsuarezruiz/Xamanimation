namespace Xamanimation
{
    using System;
    using System.Threading.Tasks;

    public static class TaskExtensions
    {
        public static async void FireAndForget(this Task task, Action<Exception> onException = null)
        {
            try
            {
                await task;
            }
            catch (Exception ex)
            {
                onException?.Invoke(ex);
            }
        }
    }
}
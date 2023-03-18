using System.Collections.Generic;

namespace Framework.Shared.States
{
    public static class IStateTriggerInfoExtension
    {
        public static bool IsCurrentTrigger<T>(this IStateTriggerInfo<T> triggerInfo, T trigger)
            => EqualityComparer<T>.Default.Equals(triggerInfo.CurrentTrigger, trigger);
    }
}
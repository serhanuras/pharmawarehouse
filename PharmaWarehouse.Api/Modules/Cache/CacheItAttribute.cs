using System;

namespace PharmaWarehouse.Api.Modules.Cache
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class CacheItAttribute : Attribute
    {
        public CacheItAttribute(DurationIn durationIn, long duration)
        {
            this.DurationIn = durationIn;
            this.Duration = duration;
        }

        public long Duration { get; set; }

        public DurationIn DurationIn { get; set; }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1201:Elements should appear in the correct order", Justification = "not required")]
    public enum DurationIn
    {
        Seconds = 0,
        Minutes = 1,
        Hours = 2,
        Days = 3,
    }
}

using System;
using System.Reflection;
using PharmaWarehouse.Api.Modules.Cache;

namespace PharmaWarehouse.Api.Modules.AbstractOriented
{
    public class DynamicProxy<T> : DispatchProxy
    {
        private T decorated;
        private ICacheStore cacheStore;

        public static T Create(T decorated, ICacheStore cacheStore)
        {
            object proxy = Create<T, DynamicProxy<T>>();
            ((DynamicProxy<T>)proxy).SetParameters(decorated, cacheStore);

            return (T)proxy;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:Elements should be ordered by access", Justification = "not required")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1101:Prefix local calls with this", Justification = "not required")]
        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            try
            {
                return CachedObjectInvoke(targetMethod, args);
            }
            catch (Exception ex) when (ex is TargetInvocationException)
            {
                throw ex.InnerException ?? ex;
            }
        }

        private object CachedObjectInvoke(MethodInfo targetMethod, object[] args)
        {
            var typeAsString = $"{targetMethod.DeclaringType?.ToString().Split("`")[0].Replace(".Interfaces.I", ".")},{targetMethod.DeclaringType.Module.Name.Replace(".dll", string.Empty)}";

            Type callType = Type.GetType(typeAsString);

            if (callType != null)
            {
                var classTargetMethod = callType.GetMethod(targetMethod.Name);
                CacheItAttribute cacheIt =
                    (CacheItAttribute)(classTargetMethod.GetCustomAttributes(typeof(CacheItAttribute), true).Length > 0
                        ? (CacheItAttribute)classTargetMethod.GetCustomAttributes(typeof(CacheItAttribute), true)[0]
                        : null);

                if (cacheIt != null)
                {
                    string key = string.Empty + classTargetMethod.DeclaringType.FullName + "||" + classTargetMethod.Name;
                    foreach (var arg in args)
                    {
                        key += "||" + arg.ToString();
                    }

                    var storedObject = this.cacheStore.Get(key);

                    if (storedObject != null)
                    {
                        return storedObject;
                    }
                    else
                    {
                        var duration = cacheIt.Duration;
                        switch (cacheIt.DurationIn)
                        {
                            case DurationIn.Minutes:
                                duration *= 60;
                                break;
                            case DurationIn.Hours:
                                duration = duration * 60 * 60;
                                break;
                            case DurationIn.Days:
                                duration = duration * 60 * 60 * 24;
                                break;
                        }

                        var result = targetMethod.Invoke(this.decorated, args);

                        this.cacheStore.Add(key, result, duration);

                        return result;
                    }
                }
                else
                {
                    var result = targetMethod.Invoke(this.decorated, args);
                    return result;
                }
            }
            else
            {
                var result = targetMethod.Invoke(this.decorated, args);
                return result;
            }
        }

        private void SetParameters(T decorated, ICacheStore cacheStore)
        {
            if (decorated == null)
            {
                throw new ArgumentNullException(nameof(decorated));
            }

            this.decorated = decorated;
            this.cacheStore = cacheStore;
        }
    }
}

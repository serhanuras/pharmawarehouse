namespace PharmaWarehouse.Api.Modules.Cache
{
    public class CacheItem<T>
    {
        public CacheItem(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }
    }
}

namespace PharmaWarehouse.Api.Modules.Cache
{
    public interface ICacheStore
    {
        void Add<TItem>(string key, TItem item);

        object Get(string key);

        TItem Get<TItem>(string key)
            where TItem : class;

        bool Contains<TItem>(string key)
            where TItem : class;

        void Remove(string key);

        void Add(string key, object item, long duration);
    }
}

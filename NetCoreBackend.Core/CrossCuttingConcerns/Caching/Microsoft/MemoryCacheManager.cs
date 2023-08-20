using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using NetCoreBackend.Core.Utilities.IoC;
using System.Text.RegularExpressions;

namespace NetCoreBackend.Core.CrossCuttingConcerns.Caching.Microsoft;

public class MemoryCacheManager : ICacheManager
{
    // Adapter Pattern uyguladık. Var olan bir yapıyı kendi sistemime uyarladım
    IMemoryCache _memoryCache;

    public MemoryCacheManager()
    {
        _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
    }

    public void Add(string key, object value, int duration)
    {
        _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
    }

    public T Get<T>(string key)
    {
        return _memoryCache.Get<T>(key);
    }

    public object Get(string key)
    {
        return _memoryCache.Get(key);
    }

    public bool IsAdd(string key)
    {
        return _memoryCache.TryGetValue(key, out _); //out _ : sadece key değeri vermek iştiyoruz ancak out bir boş parametre geçiyoruz
    }

    public void Remove(string key)
    {
        _memoryCache.Remove(key);
    }

    public void RemoveByPattern(string pattern)
    {
        // Bellekte MemoryCache tipinde olan yapıyı bul ve EntriesCollection(MemoryCache kendsi bu koleksiyonu olusturur) koleksiyonu içersindekileri al.
        var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;
        List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

        foreach (var cacheItem in cacheEntriesCollection)
        {
            ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
            cacheCollectionValues.Add(cacheItemValue);
        }

        // Burada pattern olusturuyoruz
        var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
        var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

        foreach (var key in keysToRemove)
        {
            _memoryCache.Remove(key);
        }
    }
}

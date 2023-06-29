using Microsoft.AspNetCore.Http;

public class TestSession : ISession
{
    private readonly Dictionary<string, byte[]> _sessionStorage = new Dictionary<string, byte[]>();

    public string Id => throw new NotImplementedException();

    public bool IsAvailable => throw new NotImplementedException();

    public IEnumerable<string> Keys => _sessionStorage.Keys;

    public void Clear()
    {
        _sessionStorage.Clear();
    }

    public Task CommitAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task LoadAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void Remove(string key)
    {
        _sessionStorage.Remove(key);
    }

    public void Set(string key, byte[] value)
    {
        _sessionStorage[key] = value;
    }

    public bool TryGetValue(string key, out byte[] value)
    {
        return _sessionStorage.TryGetValue(key, out value);
    }
}
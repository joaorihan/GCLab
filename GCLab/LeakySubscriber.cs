namespace GCLab;

class LeakySubscriber : IDisposable
{
    private static readonly List<WeakReference<LeakySubscriber>> _registry = new();
    private Publisher _publisher;
    private bool _disposed;

    public LeakySubscriber(Publisher publisher)
    {
        _publisher = publisher;
        _publisher.OnSomething += Handle;
        _registry.Add(new WeakReference<LeakySubscriber>(this));
    }

    private void Handle() { /* noop */ }

    public void Dispose()
    {
        if (_disposed) return;
        _disposed = true;
        if (_publisher != null)
            _publisher.OnSomething -= Handle;
        _publisher = null!;
        GC.SuppressFinalize(this);
    }

    ~LeakySubscriber()
    {
        if (_publisher != null)
            _publisher.OnSomething -= Handle;
    }
}
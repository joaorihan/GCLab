using System.Runtime.InteropServices;

namespace GCLab;

// ===================================
// 3) Pinned buffer mantido por muito tempo
// ===================================
class Pinner : System.IDisposable
{
    private GCHandle _handle;
    public byte[] PinLongTime()
    {
        var data = new byte[256];
        _handle = GCHandle.Alloc(data, GCHandleType.Pinned); // pin prolongado
        return data;
    }

    public void Unpin()
    {
        if (_handle.IsAllocated)
            _handle.Free();
    }

    public void Dispose()
    {
        Unpin();
        GC.SuppressFinalize(this);
    }

    ~Pinner()
    {
        Unpin();
    }
}
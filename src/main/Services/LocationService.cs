using ei8.Cortex.Gps.Sender.Models;

namespace ei8.Cortex.Gps.Sender.Services;

public partial class LocationService : ILocationService
{
    public event EventHandler<LocationModel> LocationChanged;
    public event EventHandler<string> StatusChanged;
    
    public void Initialize()
    {
#if ANDROID
        AndroidInitialize();
#elif IOS
        IosInitialize();
#endif
    }

    public void Stop()
    {
#if ANDROID
        AndroidStop();
#elif IOS
        IosStop();
#endif
    }

    protected virtual void OnLocationChanged(LocationModel e)
    {
        LocationChanged?.Invoke(this, e);
    }

    protected virtual void OnStatusChanged(string e)
    {
        StatusChanged?.Invoke(this, e);
    }
}
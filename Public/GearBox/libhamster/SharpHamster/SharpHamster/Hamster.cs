using System;

namespace SharpHamster
{
  public class Hamster : IDisposable
  {
    public static Hamster Instance
    {
      get { return inst_; }
    }

    ~Hamster()
    {
      Dispose(false);
    }

    public void Init()
    {
      if (!init_)
      {
        int ec = HamsterNative.hamster_init();
        if (0 != ec)
          throw new HamsterError(ec);
        init_ = true;
      }
    }

    public HamsterValue Get(string key)
    {
      if (disposed_)
        throw new HamsterDisposed();

      IntPtr h_value = HamsterNative.hamster_value_empty();
      int ec = HamsterNative.hamster_get(key, h_value);
      if (0 == ec)
      {
        HamsterValue hv = new HamsterValue(HamsterNative.hamster_value_ptr(h_value), HamsterNative.hamster_value_size(h_value));
        HamsterNative.hamster_value_free(h_value);
        return hv;
      }
      else
      {
        HamsterNative.hamster_value_free(h_value);
        throw new HamsterError(ec);
      }
    }

    public void Set(string key, HamsterValue value)
    {
      if (disposed_)
        throw new HamsterDisposed();

      IntPtr h_value = HamsterNative.hamster_value_new(value.UnmanagedDataPtr, value.Size, value.MaxSize);
      int ec = HamsterNative.hamster_set(key, h_value);
      HamsterNative.hamster_value_free(h_value);
      if (0 != ec)
        throw new HamsterError(ec);
    }

    public uint Count { get { return HamsterNative.hamster_count(); } }

    public void Dispose()
    {
      Dispose(true);
    }

    private void Dispose(bool is_disposing)
    {
      if (!disposed_)
      {
        if (init_)
        {
          HamsterNative.hamster_shutdown();
          init_ = false;
        }

        if (is_disposing)
          GC.SuppressFinalize(this);

        disposed_ = true;
      }
    }

    private static Hamster inst_ = new Hamster();
    private bool init_ = false;
    private bool disposed_ = false;
  }
}
using System;
using System.Runtime.InteropServices;

namespace SharpHamster
{
  public class HamsterValue : IDisposable
  {
    public HamsterValue(byte[] bytes, UInt32 max_size)
    {
      if (bytes.Length <= 0 || bytes.Length > max_size)
        throw new InvalidValueSize(bytes.Length, max_size);
 
      IntPtr data_ptr = Marshal.AllocHGlobal(bytes.Length);
      try
      {
        Marshal.Copy(bytes, 0, data_ptr, bytes.Length);
      }
      catch (Exception e)
      {
        Marshal.FreeHGlobal(data_ptr);
        throw e;
      }

      UnmanagedDataPtr = data_ptr;
      Size             = (UInt32)bytes.Length;
      MaxSize          = max_size;
    }

    internal HamsterValue(IntPtr data_ptr, UInt32 size)
    {
      Bytes = new byte[size];
      Marshal.Copy(data_ptr, Bytes, 0, (int)size);
    }

    ~HamsterValue()
    {
      Dispose(false);
    }

    public void Dispose()
    {
      Dispose(true);
    }

    private void Dispose(bool is_disposing)
    {
      if (!disposed_)
      {
        if (IntPtr.Zero != UnmanagedDataPtr)
        {
          Marshal.FreeHGlobal(UnmanagedDataPtr);
          UnmanagedDataPtr = IntPtr.Zero;
        }

        if (is_disposing)
          GC.SuppressFinalize(this);

        disposed_ = true;
      }
    }

    public byte[] Bytes { get; private set; }

    internal IntPtr UnmanagedDataPtr { get; private set; }
    internal UInt32 Size { get; private set; }
    internal UInt32 MaxSize { get; private set; }

    private bool disposed_ = false;
  }
}
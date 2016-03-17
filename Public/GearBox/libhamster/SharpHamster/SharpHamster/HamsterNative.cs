using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

internal static class HamsterNative
{
  [DllImport("libhamster", CallingConvention = CallingConvention.Cdecl)]
  public extern static int hamster_init();

  [DllImport("libhamster", CallingConvention = CallingConvention.Cdecl)]
  public extern static void hamster_shutdown();

  [DllImport("libhamster", CallingConvention = CallingConvention.Cdecl)] 
  public extern static IntPtr hamster_value_new(IntPtr ptr, UInt32 size, UInt32 max_size);

  [DllImport("libhamster", CallingConvention = CallingConvention.Cdecl)] 
  public extern static IntPtr hamster_value_empty();

  [DllImport("libhamster", CallingConvention = CallingConvention.Cdecl)]
  public extern static IntPtr hamster_value_ptr(IntPtr val);

  [DllImport("libhamster", CallingConvention = CallingConvention.Cdecl)]
  public extern static UInt32 hamster_value_size(IntPtr val);

  [DllImport("libhamster", CallingConvention = CallingConvention.Cdecl)] 
  public extern static void hamster_value_free(IntPtr val);

  [DllImport("libhamster", CallingConvention = CallingConvention.Cdecl)]
  public extern static int hamster_set([MarshalAs(UnmanagedType.LPStr)]string key, IntPtr value);

  [DllImport("libhamster", CallingConvention = CallingConvention.Cdecl)]
  public extern static int hamster_get([MarshalAs(UnmanagedType.LPStr)]string key, IntPtr value);

  [DllImport("libhamster", CallingConvention = CallingConvention.Cdecl)]
  public extern static uint hamster_count();
}

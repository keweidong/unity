using System;

namespace SharpHamster
{
  public enum EC
  {
    E_SHM_SYSTEM = -1,
    E_SHM_OK,
    E_SHM_CREAT_SEGINFO_FAILED,
    E_SHM_EMPTY,
    E_SHM_SAME_KEY_EXIST,
    E_SHM_DATA_CORRUPTED,
    E_SHM_TREE_NEW_FAILED,
    E_SHM_PTR_INVALID,
    E_SHM_KEY_NOT_FOUND,
    E_SHM_VAL_UPDATE_EXCEED_MAX_SIZE,
    E_SHM_VAL_SIZE_INVALID,
    E_SHM_KEY_ZERO_LENGTH,
    E_SHM_INIT_ONLY_ONCE,
    E_SHM_INVALID_PARAMS,
  }

  public class HamsterError : ApplicationException
  {
    public HamsterError(int ec)
      : base(string.Format("libhamster error: {0}({1})", ((EC)ec).ToString(), ec))
    {
      ECode = (EC)ec;
    }

    public EC ECode { get; private set; }
  }

  public class InvalidValueSize : ApplicationException
  {
    public InvalidValueSize(int size, UInt32 max_size)
      : base(string.Format("InvalidValueSize: size({0}), max_size({1})", size, max_size))
    { }
  }

  public class HamsterDisposed : ApplicationException
  {
    public HamsterDisposed() : base("HamsterDisposed") { }
  }
}
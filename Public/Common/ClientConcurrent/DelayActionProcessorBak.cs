using System;
using System.Collections.Generic;

namespace DashFire
{
  public sealed class DelayActionProcessor : IActionQueue
  {
    public int CurActionNum
    {
      get
      {
        return m_Actions.Count;
      }
    }

    public void QueueActionWithDelegation(Delegate action, params object[] args)
    {
      ObjectPool<PoolAllocatedAction> pool;
      m_ActionPools.GetOrNewData(out pool);
      PoolAllocatedAction helper = pool.Alloc();
      helper.Init(action, args);
      m_Actions.Enqueue(helper.Run);
    }

    public void QueueAction (MyAction action)
    {
      m_Actions.Enqueue(action);
    }

    public void QueueAction<T1>(MyAction<T1> action, T1 t1)
    {
      if (GlobalVariables.Instance.IsClient) {
        QueueActionWithDelegation(action, t1);
      } else {
        ObjectPool<PoolAllocatedAction<T1>> pool;
        m_ActionPools.GetOrNewData(out pool);
        PoolAllocatedAction<T1> helper = pool.Alloc();
        helper.Init(action, t1);
        m_Actions.Enqueue(helper.Run);
      }
    }

    public void QueueAction<T1,T2> (MyAction<T1,T2> action, T1 t1,T2 t2)
    {
      if (GlobalVariables.Instance.IsClient) {
        QueueActionWithDelegation(action, t1, t2);
      } else {
        ObjectPool<PoolAllocatedAction<T1, T2>> pool;
        m_ActionPools.GetOrNewData(out pool);
        PoolAllocatedAction<T1, T2> helper = pool.Alloc();
        helper.Init(action, t1, t2);
        m_Actions.Enqueue(helper.Run);
      }
    }

    public void QueueAction<T1,T2,T3> (MyAction<T1,T2,T3> action, T1 t1,T2 t2,T3 t3)
    {
      if (GlobalVariables.Instance.IsClient) {
        QueueActionWithDelegation(action, t1, t2, t3);
      } else {
        ObjectPool<PoolAllocatedAction<T1, T2, T3>> pool;
        m_ActionPools.GetOrNewData(out pool);
        PoolAllocatedAction<T1, T2, T3> helper = pool.Alloc();
        helper.Init(action, t1, t2, t3);
        m_Actions.Enqueue(helper.Run);
      }
    }

    public void QueueAction<T1,T2,T3,T4> (MyAction<T1,T2,T3,T4> action, T1 t1,T2 t2,T3 t3,T4 t4)
    {
      if (GlobalVariables.Instance.IsClient) {
        QueueActionWithDelegation(action, t1, t2, t3, t4);
      } else {
        ObjectPool<PoolAllocatedAction<T1, T2, T3, T4>> pool;
        m_ActionPools.GetOrNewData(out pool);
        PoolAllocatedAction<T1, T2, T3, T4> helper = pool.Alloc();
        helper.Init(action, t1, t2, t3, t4);
        m_Actions.Enqueue(helper.Run);
      }
    }

    public void QueueAction<T1,T2,T3,T4,T5> (MyAction<T1,T2,T3,T4,T5> action, T1 t1,T2 t2,T3 t3,T4 t4,T5 t5)
    {
      if (GlobalVariables.Instance.IsClient) {
        QueueActionWithDelegation(action, t1, t2, t3, t4, t5);
      } else {
        ObjectPool<PoolAllocatedAction<T1, T2, T3, T4, T5>> pool;
        m_ActionPools.GetOrNewData(out pool);
        PoolAllocatedAction<T1, T2, T3, T4, T5> helper = pool.Alloc();
        helper.Init(action, t1, t2, t3, t4, t5);
        m_Actions.Enqueue(helper.Run);
      }
    }

    public void QueueAction<T1,T2,T3,T4,T5,T6> (MyAction<T1,T2,T3,T4,T5,T6> action, T1 t1,T2 t2,T3 t3,T4 t4,T5 t5,T6 t6)
    {
      if (GlobalVariables.Instance.IsClient) {
        QueueActionWithDelegation(action, t1, t2, t3, t4, t5, t6);
      } else {
        ObjectPool<PoolAllocatedAction<T1, T2, T3, T4, T5, T6>> pool;
        m_ActionPools.GetOrNewData(out pool);
        PoolAllocatedAction<T1, T2, T3, T4, T5, T6> helper = pool.Alloc();
        helper.Init(action, t1, t2, t3, t4, t5, t6);
        m_Actions.Enqueue(helper.Run);
      }
    }

    public void QueueAction<T1,T2,T3,T4,T5,T6,T7> (MyAction<T1,T2,T3,T4,T5,T6,T7> action, T1 t1,T2 t2,T3 t3,T4 t4,T5 t5,T6 t6,T7 t7)
    {
      if (GlobalVariables.Instance.IsClient) {
        QueueActionWithDelegation(action, t1, t2, t3, t4, t5, t6, t7);
      } else {
        ObjectPool<PoolAllocatedAction<T1, T2, T3, T4, T5, T6, T7>> pool;
        m_ActionPools.GetOrNewData(out pool);
        PoolAllocatedAction<T1, T2, T3, T4, T5, T6, T7> helper = pool.Alloc();
        helper.Init(action, t1, t2, t3, t4, t5, t6, t7);
        m_Actions.Enqueue(helper.Run);
      }
    }

    public void QueueAction<T1,T2,T3,T4,T5,T6,T7,T8> (MyAction<T1,T2,T3,T4,T5,T6,T7,T8> action, T1 t1,T2 t2,T3 t3,T4 t4,T5 t5,T6 t6,T7 t7,T8 t8)
    {
      if (GlobalVariables.Instance.IsClient) {
        QueueActionWithDelegation(action, t1, t2, t3, t4, t5, t6, t7, t8);
      } else {
        ObjectPool<PoolAllocatedAction<T1, T2, T3, T4, T5, T6, T7, T8>> pool;
        m_ActionPools.GetOrNewData(out pool);
        PoolAllocatedAction<T1, T2, T3, T4, T5, T6, T7, T8> helper = pool.Alloc();
        helper.Init(action, t1, t2, t3, t4, t5, t6, t7, t8);
        m_Actions.Enqueue(helper.Run);
      }
    }

    public void QueueAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>(MyAction<T1, T2, T3, T4, T5, T6, T7, T8, T9> action, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
    {
      if (GlobalVariables.Instance.IsClient) {
        QueueActionWithDelegation(action, t1, t2, t3, t4, t5, t6, t7, t8, t9);
      } else {
        ObjectPool<PoolAllocatedAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>> pool;
        m_ActionPools.GetOrNewData(out pool);
        PoolAllocatedAction<T1, T2, T3, T4, T5, T6, T7, T8, T9> helper = pool.Alloc();
        helper.Init(action, t1, t2, t3, t4, t5, t6, t7, t8, t9);
        m_Actions.Enqueue(helper.Run);
      }
    }

    public void QueueAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(MyAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10)
    {
      if (GlobalVariables.Instance.IsClient) {
        QueueActionWithDelegation(action, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
      } else {
        ObjectPool<PoolAllocatedAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> pool;
        m_ActionPools.GetOrNewData(out pool);
        PoolAllocatedAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> helper = pool.Alloc();
        helper.Init(action, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
        m_Actions.Enqueue(helper.Run);
      }
    }

    public void QueueAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(MyAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11)
    {
      if (GlobalVariables.Instance.IsClient) {
        QueueActionWithDelegation(action, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
      } else {
        ObjectPool<PoolAllocatedAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> pool;
        m_ActionPools.GetOrNewData(out pool);
        PoolAllocatedAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> helper = pool.Alloc();
        helper.Init(action, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
        m_Actions.Enqueue(helper.Run);
      }
    }

    public void QueueAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(MyAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12)
    {
      if (GlobalVariables.Instance.IsClient) {
        QueueActionWithDelegation(action, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
      } else {
        ObjectPool<PoolAllocatedAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> pool;
        m_ActionPools.GetOrNewData(out pool);
        PoolAllocatedAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> helper = pool.Alloc();
        helper.Init(action, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
        m_Actions.Enqueue(helper.Run);
      }
    }

    public void QueueAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(MyAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13)
    {
      if (GlobalVariables.Instance.IsClient) {
        QueueActionWithDelegation(action, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
      } else {
        ObjectPool<PoolAllocatedAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> pool;
        m_ActionPools.GetOrNewData(out pool);
        PoolAllocatedAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> helper = pool.Alloc();
        helper.Init(action, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
        m_Actions.Enqueue(helper.Run);
      }
    }

    public void QueueAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(MyAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14)
    {
      if (GlobalVariables.Instance.IsClient) {
        QueueActionWithDelegation(action, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
      } else {
        ObjectPool<PoolAllocatedAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> pool;
        m_ActionPools.GetOrNewData(out pool);
        PoolAllocatedAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> helper = pool.Alloc();
        helper.Init(action, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
        m_Actions.Enqueue(helper.Run);
      }
    }

    public void QueueAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(MyAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15)
    {
      if (GlobalVariables.Instance.IsClient) {
        QueueActionWithDelegation(action, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
      } else {
        ObjectPool<PoolAllocatedAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> pool;
        m_ActionPools.GetOrNewData(out pool);
        PoolAllocatedAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> helper = pool.Alloc();
        helper.Init(action, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
        m_Actions.Enqueue(helper.Run);
      }
    }

    public void QueueAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(MyAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16)
    {
      if (GlobalVariables.Instance.IsClient) {
        QueueActionWithDelegation(action, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
      } else {
        ObjectPool<PoolAllocatedAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> pool;
        m_ActionPools.GetOrNewData(out pool);
        PoolAllocatedAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> helper = pool.Alloc();
        helper.Init(action, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
        m_Actions.Enqueue(helper.Run);
      }
    }

    public void QueueAction<R>(MyFunc<R> action)
    {
      if (GlobalVariables.Instance.IsClient) {
        QueueActionWithDelegation(action);
      } else {
        ObjectPool<PoolAllocatedFunc<R>> pool;
        m_ActionPools.GetOrNewData(out pool);
        PoolAllocatedFunc<R> helper = pool.Alloc();
        helper.Init(action);
        m_Actions.Enqueue(helper.Run);
      }
    }

    public void QueueAction<T1, R>(MyFunc<T1, R> action, T1 t1)
    {
      if (GlobalVariables.Instance.IsClient) {
        QueueActionWithDelegation(action, t1);
      } else {
        ObjectPool<PoolAllocatedFunc<T1, R>> pool;
        m_ActionPools.GetOrNewData(out pool);
        PoolAllocatedFunc<T1, R> helper = pool.Alloc();
        helper.Init(action, t1);
        m_Actions.Enqueue(helper.Run);
      }
    }

    public void QueueAction<T1, T2, R>(MyFunc<T1, T2, R> action, T1 t1, T2 t2)
    {
      if (GlobalVariables.Instance.IsClient) {
        QueueActionWithDelegation(action, t1, t2);
      } else {
        ObjectPool<PoolAllocatedFunc<T1, T2, R>> pool;
        m_ActionPools.GetOrNewData(out pool);
        PoolAllocatedFunc<T1, T2, R> helper = pool.Alloc();
        helper.Init(action, t1, t2);
        m_Actions.Enqueue(helper.Run);
      }
    }

    public void QueueAction<T1, T2, T3, R>(MyFunc<T1, T2, T3, R> action, T1 t1, T2 t2, T3 t3)
    {
      if (GlobalVariables.Instance.IsClient) {
        QueueActionWithDelegation(action, t1, t2, t3);
      } else {
        ObjectPool<PoolAllocatedFunc<T1, T2, T3, R>> pool;
        m_ActionPools.GetOrNewData(out pool);
        PoolAllocatedFunc<T1, T2, T3, R> helper = pool.Alloc();
        helper.Init(action, t1, t2, t3);
        m_Actions.Enqueue(helper.Run);
      }
    }

    public void QueueAction<T1, T2, T3, T4, R>(MyFunc<T1, T2, T3, T4, R> action, T1 t1, T2 t2, T3 t3, T4 t4)
    {
      if (GlobalVariables.Instance.IsClient) {
        QueueActionWithDelegation(action, t1, t2, t3, t4);
      } else {
        ObjectPool<PoolAllocatedFunc<T1, T2, T3, T4, R>> pool;
        m_ActionPools.GetOrNewData(out pool);
        PoolAllocatedFunc<T1, T2, T3, T4, R> helper = pool.Alloc();
        helper.Init(action, t1, t2, t3, t4);
        m_Actions.Enqueue(helper.Run);
      }
    }

    public void QueueAction<T1, T2, T3, T4, T5, R>(MyFunc<T1, T2, T3, T4, T5, R> action, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
    {
      if (GlobalVariables.Instance.IsClient) {
        QueueActionWithDelegation(action, t1, t2, t3, t4, t5);
      } else {
        ObjectPool<PoolAllocatedFunc<T1, T2, T3, T4, T5, R>> pool;
        m_ActionPools.GetOrNewData(out pool);
        PoolAllocatedFunc<T1, T2, T3, T4, T5, R> helper = pool.Alloc();
        helper.Init(action, t1, t2, t3, t4, t5);
        m_Actions.Enqueue(helper.Run);
      }
    }

    public void QueueAction<T1, T2, T3, T4, T5, T6, R>(MyFunc<T1, T2, T3, T4, T5, T6, R> action, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
    {
      if (GlobalVariables.Instance.IsClient) {
        QueueActionWithDelegation(action, t1, t2, t3, t4, t5, t6);
      } else {
        ObjectPool<PoolAllocatedFunc<T1, T2, T3, T4, T5, T6, R>> pool;
        m_ActionPools.GetOrNewData(out pool);
        PoolAllocatedFunc<T1, T2, T3, T4, T5, T6, R> helper = pool.Alloc();
        helper.Init(action, t1, t2, t3, t4, t5, t6);
        m_Actions.Enqueue(helper.Run);
      }
    }

    public void QueueAction<T1, T2, T3, T4, T5, T6, T7, R>(MyFunc<T1, T2, T3, T4, T5, T6, T7, R> action, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
    {
      if (GlobalVariables.Instance.IsClient) {
        QueueActionWithDelegation(action, t1, t2, t3, t4, t5, t6, t7);
      } else {
        ObjectPool<PoolAllocatedFunc<T1, T2, T3, T4, T5, T6, T7, R>> pool;
        m_ActionPools.GetOrNewData(out pool);
        PoolAllocatedFunc<T1, T2, T3, T4, T5, T6, T7, R> helper = pool.Alloc();
        helper.Init(action, t1, t2, t3, t4, t5, t6, t7);
        m_Actions.Enqueue(helper.Run);
      }
    }

    public void QueueAction<T1, T2, T3, T4, T5, T6, T7, T8, R>(MyFunc<T1, T2, T3, T4, T5, T6, T7, T8, R> action, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
    {
      if (GlobalVariables.Instance.IsClient) {
        QueueActionWithDelegation(action, t1, t2, t3, t4, t5, t6, t7, t8);
      } else {
        ObjectPool<PoolAllocatedFunc<T1, T2, T3, T4, T5, T6, T7, T8, R>> pool;
        m_ActionPools.GetOrNewData(out pool);
        PoolAllocatedFunc<T1, T2, T3, T4, T5, T6, T7, T8, R> helper = pool.Alloc();
        helper.Init(action, t1, t2, t3, t4, t5, t6, t7, t8);
        m_Actions.Enqueue(helper.Run);
      }
    }

    public void QueueAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, R>(MyFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, R> action, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
    {
      if (GlobalVariables.Instance.IsClient) {
        QueueActionWithDelegation(action, t1, t2, t3, t4, t5, t6, t7, t8, t9);
      } else {
        ObjectPool<PoolAllocatedFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, R>> pool;
        m_ActionPools.GetOrNewData(out pool);
        PoolAllocatedFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, R> helper = pool.Alloc();
        helper.Init(action, t1, t2, t3, t4, t5, t6, t7, t8, t9);
        m_Actions.Enqueue(helper.Run);
      }
    }

    public void QueueAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R>(MyFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R> action, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10)
    {
      if (GlobalVariables.Instance.IsClient) {
        QueueActionWithDelegation(action, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
      } else {
        ObjectPool<PoolAllocatedFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R>> pool;
        m_ActionPools.GetOrNewData(out pool);
        PoolAllocatedFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R> helper = pool.Alloc();
        helper.Init(action, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
        m_Actions.Enqueue(helper.Run);
      }
    }

    public void QueueAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, R>(MyFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, R> action, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11)
    {
      if (GlobalVariables.Instance.IsClient) {
        QueueActionWithDelegation(action, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
      } else {
        ObjectPool<PoolAllocatedFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, R>> pool;
        m_ActionPools.GetOrNewData(out pool);
        PoolAllocatedFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, R> helper = pool.Alloc();
        helper.Init(action, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
        m_Actions.Enqueue(helper.Run);
      }
    }

    public void QueueAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, R>(MyFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, R> action, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12)
    {
      if (GlobalVariables.Instance.IsClient) {
        QueueActionWithDelegation(action, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
      } else {
        ObjectPool<PoolAllocatedFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, R>> pool;
        m_ActionPools.GetOrNewData(out pool);
        PoolAllocatedFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, R> helper = pool.Alloc();
        helper.Init(action, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
        m_Actions.Enqueue(helper.Run);
      }
    }

    public void QueueAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, R>(MyFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, R> action, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13)
    {
      if (GlobalVariables.Instance.IsClient) {
        QueueActionWithDelegation(action, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
      } else {
        ObjectPool<PoolAllocatedFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, R>> pool;
        m_ActionPools.GetOrNewData(out pool);
        PoolAllocatedFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, R> helper = pool.Alloc();
        helper.Init(action, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
        m_Actions.Enqueue(helper.Run);
      }
    }

    public void QueueAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, R>(MyFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, R> action, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14)
    {
      if (GlobalVariables.Instance.IsClient) {
        QueueActionWithDelegation(action, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
      } else {
        ObjectPool<PoolAllocatedFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, R>> pool;
        m_ActionPools.GetOrNewData(out pool);
        PoolAllocatedFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, R> helper = pool.Alloc();
        helper.Init(action, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
        m_Actions.Enqueue(helper.Run);
      }
    }

    public void QueueAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, R>(MyFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, R> action, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15)
    {
      if (GlobalVariables.Instance.IsClient) {
        QueueActionWithDelegation(action, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
      } else {
        ObjectPool<PoolAllocatedFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, R>> pool;
        m_ActionPools.GetOrNewData(out pool);
        PoolAllocatedFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, R> helper = pool.Alloc();
        helper.Init(action, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
        m_Actions.Enqueue(helper.Run);
      }
    }

    public void QueueAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, R>(MyFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, R> action, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16)
    {
      if (GlobalVariables.Instance.IsClient) {
        QueueActionWithDelegation(action, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
      } else {
        ObjectPool<PoolAllocatedFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, R>> pool;
        m_ActionPools.GetOrNewData(out pool);
        PoolAllocatedFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, R> helper = pool.Alloc();
        helper.Init(action, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
        m_Actions.Enqueue(helper.Run);
      }
    }

    public void HandleActions (int maxCount)
    {
      HandleActions(maxCount, null);
    }

    public void Reset()
    {
      m_Actions.Clear();
    }

    internal void HandleActions(int maxCount, object lockObj)
    {
      try {
        for (int i = 0; i < maxCount; ++i) {
          if (m_Actions.Count > 0) {
            MyAction action = null;
            if (null != lockObj) {
              lock (lockObj) {
                action = m_Actions.Dequeue();
              }
            } else {
              action = m_Actions.Dequeue();
            }
            if (null != action)
              action();
          } else {
            break;
          }
        }
      } catch (Exception ex) {
        LogSystem.Error("DelayActionProcessor.HandleActions throw exception:{0}\n{1}", ex.Message, ex.StackTrace);
      }
    }

    private Queue<MyAction> m_Actions = new Queue<MyAction>();
    private TypedDataCollection m_ActionPools = new TypedDataCollection();
  }
}

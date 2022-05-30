
using System;

namespace Framework.Shared.Signals
{
    public interface ISignalBase { }
    public interface ISignal : ISignalBase { void Send(); }
    public interface ISignal<T> : ISignalBase { void Send(T parameter); }

    public interface IItemSelectedSignal<T> : ISignal<T> { }
    public interface IGameRestartSignal : ISignal { }
    public interface IMainMenuSignal : ISignal { }
    public interface IPlayerPassedSignal : ISignal { }
}

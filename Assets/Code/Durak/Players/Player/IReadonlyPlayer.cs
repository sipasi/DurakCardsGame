using System;
using System.Collections.Generic;

using Framework.Durak.Datas;


namespace Framework.Durak.Players
{
    public interface IReadonlyPlayer
    {
        Guid Id { get; }

        string Name { get; }

        IReadOnlyList<Data> Hand { get; }

        PlayerType Type { get; }

        bool Contains(Data data);
    }
}
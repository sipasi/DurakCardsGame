using System.Collections;
using System.Collections.Generic;

using Framework.Durak.Datas;

namespace Framework.Durak.Services.Movements
{
    public interface IBoardCardMovement : ICardMovement
    {
        void TeleportToAttacks(Data data);
        void TeleportToDefends(Data data);
    }
}
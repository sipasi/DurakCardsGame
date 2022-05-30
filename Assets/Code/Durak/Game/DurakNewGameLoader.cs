
using Framework.Durak.DependencyInjection;
using Framework.Durak.States;
using Framework.Shared.States;

using UnityEngine;

namespace Framework.Durak.Game
{
    public class DurakNewGameLoader : MonoBehaviour
    {
        [SerializeField] private DiContainerHolder holder;

        public void Load()
        {
            var machine = holder.Container.Get<IStateMachine<DurakGameState>>();

            machine.Fire(DurakGameState.GameStart);
        }
    }
}
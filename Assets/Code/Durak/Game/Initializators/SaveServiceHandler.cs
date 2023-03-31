using Framework.Durak.Saves;
using Framework.Durak.States;
using Framework.Shared.DependencyInjection;
using Framework.Shared.IO;
using Framework.Shared.Saves;
using Framework.Shared.States;

using UnityEngine;

namespace Framework.Durak.Game.Initializators
{
    internal class SaveServiceHandler : MonoBehaviour, IGameInitializable
    {
        private IStateTriggerInfo<DurakGameState> triggerInfo;
        private SaveEntities entities;

        public void Initialize(IDiContainer container)
        {
            triggerInfo = container.Get<IStateTriggerInfo<DurakGameState>>();
            entities = container.Get<SaveEntities>();
        }

        public void Save()
        {
            if (triggerInfo.CurrentTrigger is
                not DurakGameState.PlayerDefending and
                not DurakGameState.PlayerAttacking and
                not DurakGameState.Toss)
            {
                Debug.LogWarning($"Don't save. Current state is {triggerInfo.CurrentTrigger}. Allowed states are {DurakGameState.PlayerAttacking} or {DurakGameState.PlayerDefending}");

                return;
            }

            LocalBinaryFile<ISaveMetadata> file = new(SavePaths.durak.path);

            SaveEntitiesMapper mapper = new(entities);

            ISaveMetadata metadata = mapper.Map();

            bool success = file.Save(metadata);

            Debug.Log($"Save status: {success}");
        }
    }
}

using System;

using Cysharp.Threading.Tasks;

using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.ServiceModule.MovementModule;
using ProjectCard.Shared.ViewModule;

using UnityEngine;

namespace ProjectCard.DurakModule.ViewModule
{
    public class BoardPlaces : MonoBehaviour
    {
        [SerializeField] private CardMovementManager movementManager;

        [SerializeField] private Place[] places;

        private int index;

        private ref Place Current => ref places[index];

        public async UniTask AddToNext(ICard card)
        {
            if (Current.ContainsAttacker is false)
            {
                await AddToAttacks(card);

                return;
            }

            if (Current.ContainsDefender is false)
            {
                await AddToDefends(card);

                return;
            }

            Next();

            await AddToAttacks(card);
        }

        public UniTask AddToAttacks(ICard card)
        {
            if (Current.ContainsAttacker)
            {
                Next();
            }

            return AddToAttacks(card, ref Current);
        }
        public UniTask AddToDefends(ICard card)
        {
            if (Current.ContainsDefender)
            {
                Next();
            }

            return AddToDefends(card, ref Current);
        }

        public UniTask AddToAttacks(ICard card, int index)
        {
            return AddToAttacks(card, ref places[index]);
        }

        public UniTask AddToDefends(ICard card, int index)
        {
            return AddToDefends(card, ref places[index]);
        }

        private UniTask AddToAttacks(ICard card, ref Place place)
        {
            place.SetAttacker();

            return movementManager.MoveToPlace(card, place.Attacker, lookSide: CardLookSide.Face);
        }
        private UniTask AddToDefends(ICard card, ref Place place)
        {
            place.SetDefender();

            return movementManager.MoveToPlace(card, place.Defender, lookSide: CardLookSide.Face);
        }

        public void Clear()
        {
            index = 0;

            for (int i = 0; i < places.Length; i++)
            {
                ref Place place = ref places[i];

                place.Clear();
            }
        }

        private void Next()
        {
            index++;
        }


        [Serializable]
        private struct Place
        {
            [SerializeField] private Transform attacker;
            [SerializeField] private Transform defender;

            public Transform Attacker => attacker;
            public Transform Defender => defender;

            public bool ContainsAttacker { get; private set; }
            public bool ContainsDefender { get; private set; }

            public void SetAttacker() => ContainsAttacker = true;
            public void SetDefender() => ContainsDefender = true;

            public void Clear()
            {
                ContainsAttacker = false;
                ContainsDefender = false;
            }
        }
    }
}
using System;

using Framework.Shared.Cards.Scriptables;
using Framework.Shared.Cards.Views;

using UnityEngine;

namespace Framework.Shared.Cards.Entities
{
    public static class CardsBuilder
    {
        public static Info Create() => new();
        public static ref Info Create(out Info info)
        {
            info = new();

            return ref info;
        }

        public static ref Info SetPrefab(this ref Info info, CardPrefab value)
        {
            info.prefab = value;

            return ref info;
        }
        public static ref Info SetParent(this ref Info info, Transform value)
        {
            info.parent = value;

            return ref info;
        }
        public static ref Info SetTheme(this ref Info info, CardTheme value)
        {
            info.theme = value;

            return ref info;
        }
        public static ref Info SetCount(this ref Info info, int value)
        {
            info.count = value;

            return ref info;
        }

        public static ref Info SetLookSide(this ref Info info, CardLookSide value)
        {
            info.lookSide = value;

            return ref info;
        }

        public static ref Info SetOwner(this ref Info info, ICardOwner value)
        {
            info.owner = value;

            return ref info;
        }

        public static ref Info SetNavigationFactory(this ref Info info, Func<CardPrefab, ICardNavigation> value)
        {
            info.navigationFactory = value;

            return ref info;
        }

        public static ICard[] Build(this ref Info info)
        {
            ICard[] cards = new ICard[info.count];

            SpritePack faces = info.theme.Faces;
            Sprite back = info.theme.Back;

            for (int i = 0; i < info.count; i++)
            {
                var instance = UnityEngine.Object.Instantiate(info.prefab, info.parent, false);

                CardView view = new(instance.Image, face: faces[i], back)
                {
                    LookSide = info.lookSide,
                };

                cards[i] = new Card(view, navigation: info.navigationFactory.Invoke(instance));

                var proxy = instance.gameObject.AddComponent<CardProxy>();

                proxy.Card = cards[i];

                info.owner?.Take(cards[i]);
            }

            return cards;
        }

        public ref struct Info
        {
            internal CardPrefab prefab;
            internal Transform parent;
            internal CardTheme theme;
            internal int count;

            internal CardLookSide lookSide;

            internal ICardOwner owner;

            internal Func<CardPrefab, ICardNavigation> navigationFactory;
        }
    }
}
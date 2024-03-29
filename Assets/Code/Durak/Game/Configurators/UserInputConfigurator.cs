﻿
using Framework.Shared.DependencyInjection;
using Framework.Shared.Input;

using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Framework.Durak.Game.Configurators
{
    public class UserInputConfigurator : MonoBehaviour, IIdenticalGameConfigurator
    {
        private UserInputActions user;

        [SerializeField] private GraphicRaycaster raycaster;

        private void OnEnable()
        {
            user?.Enable();
        }
        private void OnDisable()
        {
            user?.Disable();
        }

        public void Configure(ServiceBuilder builder)
        {
            user = new UserInputActions();

            var tapListener = new TapListener(user, Pointer.current, EventSystem.current, raycaster);

            Assert.IsNotNull(tapListener, "Tap listener cannot be null");

            builder.singleton.Add<ITapService>(tapListener);
            builder.singleton.Add<ICardTapService, CardTapListener>();

            user.Enable();
        }
    }
}
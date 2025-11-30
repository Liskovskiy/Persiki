using CustomEventBus;
using System.Collections.Generic;
//using UnityEditor.iOS;
using UnityEngine;

namespace Examples.VerticalScrollerExample
{
    public class ServiceLocatorLoader_Main : MonoBehaviour
    {
        [SerializeField] private Player               _player;
        [SerializeField] private MousePositionHandler _mousePositionHandler;
        private EventBus _eventBus;

        private void Awake()
        {
            _eventBus = new EventBus();

            Register();
            Init();
            AddToDisposables();
        }


        private void Init()
        {
            _player.Initialize();
        }

        private void Register()
        {
            ServiceLocator.Initialize();
            ServiceLocator.Current.Register(_eventBus);
            ServiceLocator.Current.Register<Player>(_player);
            ServiceLocator.Current.Register<MousePositionHandler>(_mousePositionHandler);
        }

        private void AddToDisposables()
        {

        }

        private void OnDestroy()
        {

        }
    }
}
using CustomEventBus;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList.Internal;
using UnityEditor.iOS;
using UnityEngine;

namespace Examples.VerticalScrollerExample
{
    public class ServiceLocatorLoader_Main : MonoBehaviour
    {

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

        }

        private void Register()
        {
            ServiceLocator.Initialize();
            ServiceLocator.Current.Register(_eventBus);
        }

        private void AddToDisposables()
        {

        }

        private void OnDestroy()
        {

        }
    }
}
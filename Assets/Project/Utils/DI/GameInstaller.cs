using CustomEventBus;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<EventBus>()
            .FromNew()
            .AsSingle();
    }
}
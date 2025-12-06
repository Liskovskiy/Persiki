using UnityEngine;
using Zenject;

public class InputInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .BindInterfacesAndSelfTo<MousePositionHandler>()
            .AsSingle()
            .NonLazy();
    }
}
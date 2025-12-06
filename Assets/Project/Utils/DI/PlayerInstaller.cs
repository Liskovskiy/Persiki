using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<WeaponSlotController>()
            .FromComponentInHierarchy()
            .AsSingle();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlotController : MonoBehaviour, IService
{
    private Transform _slotTransform;

    public Transform GetWeaponSlotTransform()
    {
        return _slotTransform;
    }

    private void Awake()
    {
        _slotTransform = transform;
    }

}

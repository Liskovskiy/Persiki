using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] Player _player;
    private void Awake()
    {
        _player.Initialize();
    }

    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] Enemy _enemy;
    private void Awake()
    {
        _player.Initialize();
        _enemy.Initialize();
    }

    void Update()
    {
        
    }
}

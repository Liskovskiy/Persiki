using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEventBus;
using CustomEventBus.Signals;
using Zenject;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    private EventBus _eventBus;

    [Inject]
    public void Init(EventBus eventBus)
    {
        _eventBus = eventBus;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out var enemy))
        {
            _eventBus.Invoke(new EnemyDamagedSignal(enemy, 1));
        }
    }
}

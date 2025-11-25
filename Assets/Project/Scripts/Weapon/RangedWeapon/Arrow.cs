using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEventBus;
using CustomEventBus.Signals;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    private EventBus _eventBus;
    void Start()
    {
        _eventBus = ServiceLocator.Current.Get<EventBus>();
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

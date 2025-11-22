using UnityEngine;
namespace CustomEventBus.Signals
{
    public class MouseAttackInputSignal
    {
        public readonly Vector3 worldPos;
        public MouseAttackInputSignal(Vector3 newWorldPos)
        {
            worldPos = newWorldPos;
        }
    }
}
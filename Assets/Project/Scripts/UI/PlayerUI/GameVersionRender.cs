using UnityEngine;
using UnityEngine.UI;

public class GameVersionRender : MonoBehaviour
{
    [SerializeField] private Text label;

    private void Awake()
    {
        if (label != null)
        {
            label.text = $"v {GameVersion.Value}";
        }
    }
}

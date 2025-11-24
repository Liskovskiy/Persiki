using UnityEngine;

public static class GameVersion
{
    private static string _cached;

    public static string Value
    {
        get
        {
            if (_cached == null)
            {
                var textAsset = Resources.Load<TextAsset>("version"); // version.txt ? Assets/Resources
                _cached = textAsset != null ? textAsset.text.Trim() : "0.0.0";
            }

            return _cached;
        }
    }
}

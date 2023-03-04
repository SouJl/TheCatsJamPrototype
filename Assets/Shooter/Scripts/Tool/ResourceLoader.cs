using UnityEngine;

namespace Shooter.Tool
{
    internal static class ResourceLoader
    {
        public static GameObject LoadPrefab(string path) =>
            LoadObject<GameObject>(path);

        public static TObject LoadObject<TObject>(string path) where TObject : Object => 
            Resources.Load<TObject>(path);
    }
}

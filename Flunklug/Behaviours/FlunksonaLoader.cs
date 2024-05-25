using BepInEx;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Flunklug.Behaviours
{
    public static class FlunksonaLoader
    {
        public static List<Flunksona> flunksonas { get; set; } = new List<Flunksona>();

        public static void Load() 
        {
            string flunksonaDir = Path.Combine(Paths.PluginPath, "Flunksonas");
            if (!Directory.Exists(flunksonaDir))
            {
                Directory.CreateDirectory(flunksonaDir);
                return;
            }

            string[] flunksonaFiles = Directory.GetFiles(flunksonaDir, "*.flunksona");
            for (int i = 0; i < flunksonaFiles.Length; i++)
            {
                AssetBundle bundle = AssetBundle.LoadFromFile(flunksonaFiles[i]);
                GameObject flunklug = GameObject.Instantiate(bundle.LoadAsset<GameObject>("assets/tempsona.prefab"));
                flunksonas.Add(flunklug.AddComponent<Flunksona>());
                bundle.Unload(false);
            }
        }
    }
}

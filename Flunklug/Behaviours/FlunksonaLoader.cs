using BepInEx;
using BepInEx.Configuration;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Flunklug.Behaviours
{
    public static class FlunksonaLoader
    {
        public static List<Flunksona> flunksonas { get; set; } = new List<Flunksona>();

        public static void Load(ConfigFile config) 
        {
            bool monoSandboxSupport = config.Bind("Gameplay", "MonoSandboxSupport", true, "Enables mono sandbox support.").Value;

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
                Flunksona sona = flunklug.AddComponent<Flunksona>();

                flunklug.name = monoSandboxSupport ? $"MonoObject {sona.name}" : $"{sona.name}";

                flunksonas.Add(sona);
                bundle.Unload(false);
            }
        }
    }
}

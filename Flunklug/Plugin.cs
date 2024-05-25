using BepInEx;
using Flunklug.Behaviours;
using System;
using UnityEngine;

namespace Flunklug
{
    [BepInPlugin("pl2w.flunklug", "Flunklug", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public Plugin() => GorillaTagger.OnPlayerSpawned(delegate
        {
            try
            {
                FlunksonaLoader.Load();
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }
        });
    }
}

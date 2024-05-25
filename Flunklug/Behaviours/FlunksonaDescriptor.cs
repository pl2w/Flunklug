using System;
using UnityEngine;

namespace Flunklug
{
    [Serializable]
    public class FlunksonaDescriptor : MonoBehaviour
    {
        public string Author = string.Empty;
        public string Name = string.Empty;
        public float ThrowStrength = 1;
    }
}
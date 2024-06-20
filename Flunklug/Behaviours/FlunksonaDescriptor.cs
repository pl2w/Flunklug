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
        public float FastMoveSpeed = 5.0f;

        public AudioSource GrabAudio = null;
        public AudioSource DropAudio = null;
        public AudioSource FastMoveAudio = null;
        public AudioSource RespawnAudio = null;
        public AudioSource CollisionAudio = null;
    }
}
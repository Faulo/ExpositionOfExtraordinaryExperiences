using EEE.Interfaces;
using UnityEngine;

namespace EEE.FPS {
    sealed class NoClipCharacterSource : ICharacterSource {
        public string name { get; } = "noclip";
        public string description { get; } = "first-person camera without collision";

        public ICharacterController Spawn(Vector3 position, Quaternion rotation) => throw new System.NotImplementedException();
    }
}

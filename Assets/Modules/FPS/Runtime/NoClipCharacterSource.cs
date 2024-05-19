using EEE.Interfaces;
using UnityEngine;

namespace EEE.FPS {
    sealed class NoClipCharacterSource : ICharacterSource {
        public string name { get; } = "noclip";
        public string description { get; } = "first-person camera without collision";

        public ICharacterController Spawn(Vector3 position, Quaternion rotation) {
            var obj = new GameObject(name);
            obj.transform.SetPositionAndRotation(position, rotation);

            var character = obj.AddComponent<NoClipCharacterComponent>();

            return character;
        }
    }
}

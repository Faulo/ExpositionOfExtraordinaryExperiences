using EEE.Interfaces;
using UnityEngine;

namespace EEE.FPS {
    sealed class NoClipCharacterComponent : MonoBehaviour, ICharacterController {
        public Transform cameraTarget => transform;

        public void UpdateInput(ICharacterInput input, ICharacterCamera camera) => throw new System.NotImplementedException();
        public void UpdatePhysics(float deltaTime) => throw new System.NotImplementedException();
        public void UpdateVisuals(float deltaTime) => throw new System.NotImplementedException();
    }
}

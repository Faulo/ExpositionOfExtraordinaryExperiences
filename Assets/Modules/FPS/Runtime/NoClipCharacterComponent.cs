using EEE.Interfaces;
using Slothsoft.UnityExtensions;
using UnityEngine;

namespace EEE.FPS {
    sealed class NoClipCharacterComponent : MonoBehaviour, ICharacterController {
        [SerializeField]
        internal float movementSpeed = 5;

        public Transform cameraTarget => transform;

        public Vector3 characterPosition {
            get => transform.position;
            set => transform.position = value;
        }

        public Vector3 characterVelocity {
            get;
            set;
        }

        public void UpdateInput(ICharacterInput input, ICharacterCamera camera) {
            var direction = input.move.normalized;
            float magnitude = input.move.magnitude;
            var velocity = Mathf.Clamp01(magnitude) * movementSpeed * direction;

            characterVelocity = velocity.SwizzleXZ();
        }

        public void UpdatePhysics(float deltaTime) {
            characterPosition += characterVelocity * deltaTime;
        }

        public void UpdateVisuals(float deltaTime) {
        }
    }
}

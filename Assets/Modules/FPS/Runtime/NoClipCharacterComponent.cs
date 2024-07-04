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

        public Quaternion characterRotation {
            get => transform.rotation;
            set => transform.rotation = value;
        }

        public Vector3 characterVelocity {
            get;
            set;
        }

        void OnEnable() {
            Cursor.lockState = CursorLockMode.Locked;
        }

        void OnDisable() {
            Cursor.lockState = CursorLockMode.None;
        }

        [SerializeField]
        float yawMultiplier = 1;
        [SerializeField]
        float pitchMultiplier = 1;

        [Space]
        [SerializeField]
        float yaw;
        [SerializeField]
        float pitch;

        public void UpdateInput(ICharacterInput input, ICharacterCamera camera) {
            var direction = input.move.normalized;
            float magnitude = input.move.magnitude;
            var velocity = Mathf.Clamp01(magnitude) * movementSpeed * direction;

            characterVelocity = velocity.SwizzleXZ();

            (float yaw, float pitch) = input.look;

            this.yaw += yawMultiplier * yaw;
            this.pitch += pitchMultiplier * pitch;

            transform.rotation = Quaternion.Euler(this.yaw, 0, 0) * Quaternion.Euler(0, this.pitch, 0);
        }

        public void UpdatePhysics(float deltaTime) {
            characterPosition += characterVelocity * deltaTime;
        }

        public void UpdateVisuals(float deltaTime) {
        }
    }
}

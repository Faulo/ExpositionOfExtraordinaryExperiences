using UnityEngine;

namespace EEE.Interfaces {
    public interface ICharacterController {
        /// <summary>
        /// The root object of the character.
        /// Destroying this MUST clean up the character and any other objects it created during its lifetime.
        /// </summary>
        GameObject gameObject { get; }

        /// <summary>
        /// The transform that the camera should be looking at.
        /// </summary>
        Transform cameraTarget { get; }

        Vector3 characterPosition { get; set; }

        Vector3 characterVelocity { get; set; }

        Quaternion characterRotation { get; set; }

        /// <summary>
        /// This is called by the engine once per frame with the current input to the character.
        /// </summary>
        /// <param name="input"></param>
        void UpdateInput(ICharacterInput input, ICharacterCamera camera);

        /// <summary>
        /// This is called by the engine once per frame, in the FixedUpdate phase of processing.
        /// </summary>
        /// <param name="deltaTime"></param>
        void UpdatePhysics(float deltaTime);

        /// <summary>
        /// This is called by the engine once per frame, right before rending the character.
        /// </summary>
        /// <param name="deltaTime"></param>
        void UpdateVisuals(float deltaTime);
    }
}

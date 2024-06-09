using System.Collections;
using EEE.Core;
using EEE.Interfaces;
using UnityEngine;

namespace EEE.Player {
    sealed class SpawnCharacterComponent : MonoBehaviour {
        [SerializeField]
        ModLoader modLoader;
        [SerializeField]
        Transform spawnPoint;
        [SerializeField]
        new Transform camera;

        ICharacterController currentCharacter;

        Controls input;

        IEnumerator Start() {
            yield return new WaitUntil(() => modLoader.hasCharacterSource);

            currentCharacter = modLoader.currentCharacterSource.Spawn(spawnPoint.position, spawnPoint.rotation);

            input = new Controls();
            input.Enable();
        }

        void OnDestroy() {
            if (input is not null) {
                input.Disable();
                input.Dispose();
            }
        }

        void Update() {
            if (currentCharacter is not null && input is { Player: var player }) {
                var data = new CharacterInputData(player);

                currentCharacter.UpdateInput(data, default);
            }
        }

        void FixedUpdate() {
            if (currentCharacter is not null) {
                currentCharacter.UpdatePhysics(Time.deltaTime);
            }
        }

        void LateUpdate() {
            if (currentCharacter is not null) {
                currentCharacter.UpdateVisuals(Time.deltaTime);
                camera.position = currentCharacter.characterPosition;
            }
        }
    }
}

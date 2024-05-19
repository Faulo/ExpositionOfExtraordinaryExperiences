using System.Collections;
using EEE.Core;
using UnityEngine;

namespace EEE.Player {
    sealed class SpawnCharacterComponent : MonoBehaviour {
        [SerializeField]
        ModLoader modLoader;
        [SerializeField]
        Transform spawnPoint;

        IEnumerator Start() {
            yield return new WaitUntil(() => modLoader.hasCharacterSource);

            modLoader.currentCharacterSource.Spawn(spawnPoint.position, spawnPoint.rotation);
        }
    }
}

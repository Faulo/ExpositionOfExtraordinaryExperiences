using UnityEngine;

namespace EEE.Interfaces {
    public interface ICharacterSource {
        /// <summary>
        /// The name of the character controller.
        /// </summary>
        string name { get; }

        /// <summary>
        /// A short description of the character controller.
        /// </summary>
        string description { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <returns></returns>
        ICharacterController Spawn(Vector3 position, Quaternion rotation);
    }
}

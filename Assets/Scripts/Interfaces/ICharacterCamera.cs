using UnityEngine;

namespace EEE.Interfaces {
    public interface ICharacterCamera {
        GameObject gameObject { get; }

        /// <summary>
        /// Converts a north/south/west/east input to the appropriate directions when considering where the camera is pointing.
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        Vector3 TranslateToView(Vector2 direction);
    }
}

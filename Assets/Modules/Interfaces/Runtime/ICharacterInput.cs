using UnityEngine;

namespace EEE.Interfaces {
    public interface ICharacterInput {
        /// <summary>
        /// Movement intentions. Use <see cref="ICharacterCamera.TranslateToView(Vector2)"/> to convert them to world space.
        /// </summary>
        Vector2 move { get; }

        /// <summary>
        /// Camera intentions.
        /// </summary>
        Vector2 look { get; }

        /// <summary>
        /// Jump intention. Usually bound to the south button, or Space.
        /// </summary>
        bool jump { get; }

        /// <summary>
        /// Dash/evade/run intention. Usually bound to the east button, or Shift, or right mouse.
        /// </summary>
        bool dash { get; }

        /// <summary>
        /// Interact intention. Usually bound to the north button, or E.
        /// </summary>
        bool interact { get; }

        /// <summary>
        /// Interact intention. Usually bound to the west button, or Q.
        /// </summary>
        bool special { get; }

        /// <summary>
        /// Duck intention. Usually bound to the left bumper, or Ctrl.
        /// </summary>
        bool duck { get; }

        /// <summary>
        /// Attack intention. Usually bound to the right bumper, or F, or left mouse.
        /// </summary>
        bool attack { get; }
    }
}

﻿using EEE.Interfaces;
using UnityEngine;

namespace EEE.Player {
    readonly struct CharacterInputData : ICharacterInput {

        public CharacterInputData(Controls.PlayerActions player) {
            move = player.Move.ReadValue<Vector2>();
            look = Cursor.lockState is CursorLockMode.Locked
                ? player.Look.ReadValue<Vector2>()
                : default;
            jump = false;
            dash = player.Dash.IsPressed();
            interact = false;
            special = false;
            duck = false;
            attack = false;
        }

        public readonly Vector2 move { get; }
        public readonly Vector2 look { get; }
        public readonly bool jump { get; }
        public readonly bool dash { get; }
        public readonly bool interact { get; }
        public readonly bool special { get; }
        public readonly bool duck { get; }
        public readonly bool attack { get; }
    }
}

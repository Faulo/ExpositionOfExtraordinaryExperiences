using System;
using System.Collections.Generic;
using System.Linq;
using EEE.Interfaces;
using UnityEngine;

namespace EEE.Core {
    public sealed class ModLoader : MonoBehaviour, IModContext {
        static readonly Type[] bootstrapTypes = AppDomain
            .CurrentDomain
            .GetAssemblies()
            .SelectMany(a => a.GetTypes().Where(t => t.IsClass && !t.IsAbstract && typeof(IBootstrap).IsAssignableFrom(t)))
            .ToArray();

        internal static readonly IBootstrap[] mods = bootstrapTypes
            .Select(Activator.CreateInstance)
            .Cast<IBootstrap>()
            .ToArray();

        void OnEnable() {
            foreach (var mod in mods) {
                mod.LoadMod(this);
            }
        }

        void OnDisable() {
            foreach (var mod in mods) {
                mod.UnloadMod(this);
            }
        }

        internal readonly List<ICharacterSource> characters = new();

        public bool hasCharacterSource => characters.Count > 0;
        public ICharacterSource currentCharacterSource => characters[0];

        public void RegisterCharacterController(ICharacterSource source) {
            characters.Add(source);
        }

        public void UnregisterCharacterController(ICharacterSource source) {
            characters.Remove(source);
        }
    }
}

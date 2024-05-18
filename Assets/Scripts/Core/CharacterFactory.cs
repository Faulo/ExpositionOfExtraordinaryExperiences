using System;
using System.Collections.Generic;
using System.Linq;
using EEE.Interfaces;

namespace EEE.Core {
    public sealed class CharacterFactory {
        public IEnumerable<Type> GetAllSourceTypes() => AppDomain
            .CurrentDomain
            .GetAssemblies()
            .SelectMany(a => a.GetTypes().Where(t => t.IsClass && !t.IsAbstract && typeof(ICharacterSource).IsAssignableFrom(t)));
    }
}

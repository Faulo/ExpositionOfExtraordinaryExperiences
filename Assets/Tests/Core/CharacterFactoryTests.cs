using System;
using EEE.Interfaces;
using NUnit.Framework;
using UnityEngine;

namespace EEE.Core.Tests {
    [TestFixture]
    [TestOf(typeof(CharacterFactory))]
    sealed class CharacterFactoryTests {
        sealed class CharacterSourceStub : ICharacterSource {
            public string name { get; }
            public string description { get; }

            public ICharacterController Spawn(Vector3 position, Quaternion rotation) => throw new NotImplementedException();
        }

        [Test]
        public void GivenClassImplementingICharacterSource_WhenGetAllSources_ThenContains() {
            var sut = new CharacterFactory();

            Assert.That(sut.GetAllSourceTypes(), Does.Contain(typeof(CharacterSourceStub)));
        }
    }
}

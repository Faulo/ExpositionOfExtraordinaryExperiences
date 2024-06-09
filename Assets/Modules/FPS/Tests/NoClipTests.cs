using System;
using System.Collections;
using EEE.Interfaces;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityObject = UnityEngine.Object;

namespace EEE.FPS.Tests {
    [TestFixture]
    [TestOf(typeof(NoClipCharacterComponent))]
    [RequiresPlayMode]
    sealed class ModLoaderTests {
        sealed class BootstrapStub : IBootstrap {
            internal static event Action onLoaded;
            internal static event Action onUnloaded;
            public void LoadMod(IModContext context) => onLoaded?.Invoke();
            public void UnloadMod(IModContext context) => onUnloaded?.Invoke();

            public string name { get; } = nameof(BootstrapStub);
        }

        GameObject obj;
        NoClipCharacterComponent sut;

        ICharacterInput input;
        ICharacterCamera camera;

        [UnitySetUp]
        public IEnumerator SetUpObject() {
            obj = new();
            sut = obj.AddComponent<NoClipCharacterComponent>();

            input = Substitute.For<ICharacterInput>();
            camera = Substitute.For<ICharacterCamera>();

            yield return null;
        }

        [UnityTearDown]
        public IEnumerator TearDownObject() {
            if (obj) {
                UnityObject.Destroy(obj);
                yield return null;
            }
        }

        [TestCase(0, 1, 1)]
        [TestCase(0, 2, 1)]
        [TestCase(0, 2, 1)]
        [TestCase(-1, 3, 0)]
        [TestCase(1, 4, -1)]
        public void GivenInputAndSpeed_WhenUpdatePhysics_ThenUpdateVelocity(float inputX, float inputY, float speed) {
            input.move.Returns(new Vector2(inputX, inputY));

            sut.movementSpeed = speed;

            sut.UpdateInput(input, camera);

            Assert.That(sut.characterVelocity, Is.EqualTo(speed * Vector3.ClampMagnitude(new Vector3(inputX, 0, inputY), 1)));
        }

        [TestCase(0, 1, 0)]
        [TestCase(0, 1, 1)]
        [TestCase(-1, 0, 2)]
        [TestCase(1, -1, 3)]
        public void GivenCharacter_WhenSetCharacterPosition_ThenMoveTransform(float x, float y, float z) {
            sut.characterPosition = new Vector3(x, y, z);

            Assert.That(obj.transform.position, Is.EqualTo(new Vector3(x, y, z)));
        }

        [TestCase(0, 1, 0)]
        [TestCase(0, 1, 1)]
        [TestCase(-1, 0, 2)]
        [TestCase(1, -1, 3)]
        public void GivenCharacter_WhenSetTransformPosition_ThenMoveCharacter(float x, float y, float z) {
            obj.transform.position = new Vector3(x, y, z);

            Assert.That(sut.characterPosition, Is.EqualTo(new Vector3(x, y, z)));
        }

        [TestCase(0, 1, 0, 1)]
        [TestCase(0, 1, 1, 0)]
        [TestCase(-1, 0, 2, 2)]
        [TestCase(1, -1, 3, 4)]
        public void GivenCharacter_WhenSetCharacterVelocity_ThenMoveTransform(float x, float y, float z, float deltaTime) {
            sut.characterVelocity = new Vector3(x, y, z);

            sut.UpdatePhysics(deltaTime);

            Assert.That(obj.transform.position, Is.EqualTo(new Vector3(x, y, z) * deltaTime));
        }
    }
}

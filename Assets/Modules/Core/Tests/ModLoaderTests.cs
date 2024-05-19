using System;
using System.Collections;
using EEE.Interfaces;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityObject = UnityEngine.Object;

namespace EEE.Core.Tests {
    [TestFixture]
    [TestOf(typeof(ModLoader))]
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

        [UnitySetUp]
        public IEnumerator SetUpObject() {
            obj = new();

            yield return null;
        }

        [UnityTearDown]
        public IEnumerator TearDownObject() {
            if (obj) {
                UnityObject.Destroy(obj);
                yield return null;
            }
        }

        [Test]
        public void GivenEmptyScene_WhenAddModLoader_ThenLoadMod() {
            var loaded = Substitute.For<Action>();

            BootstrapStub.onLoaded += loaded;

            _ = obj.AddComponent<ModLoader>();

            loaded.Received(1);
        }

        [Test]
        public void GivenEmptyScene_WhenDestroyModLoader_ThenUnloadMod() {
            var unloaded = Substitute.For<Action>();

            BootstrapStub.onUnloaded += unloaded;

            var sut = obj.AddComponent<ModLoader>();

            UnityObject.Destroy(sut);

            unloaded.Received(1);
        }
    }
}

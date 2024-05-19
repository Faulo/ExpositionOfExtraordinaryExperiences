using EEE.Interfaces;

namespace EEE.FPS {
    sealed class Bootstrap : IBootstrap {
        readonly NoClipCharacterSource noClip = new();

        public void LoadMod(IModContext context) {
            context.RegisterCharacterController(noClip);
        }
        public void UnloadMod(IModContext context) {
            context.UnregisterCharacterController(noClip);
        }

        public string name { get; } = nameof(FPS);
    }
}

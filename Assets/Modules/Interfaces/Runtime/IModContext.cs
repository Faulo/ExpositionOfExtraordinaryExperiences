namespace EEE.Interfaces {
    public interface IModContext {
        void RegisterCharacterController(ICharacterSource source);

        void UnregisterCharacterController(ICharacterSource source);
    }
}

namespace EEE.Interfaces {
    public interface IBootstrap {
        string name { get; }

        void LoadMod(IModContext context);

        void UnloadMod(IModContext context);
    }
}

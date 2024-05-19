using System.Runtime.CompilerServices;
using EEE.Player;

[assembly: InternalsVisibleTo(AssemblyInfo.NAMESPACE_EDITOR)]
[assembly: InternalsVisibleTo(AssemblyInfo.NAMESPACE_TESTS)]
[assembly: InternalsVisibleTo(AssemblyInfo.NAMESPACE_PROXYGEN)]

namespace EEE.Player {
    static class AssemblyInfo {
        public const string NAMESPACE_RUNTIME = "EEE.Player";
        public const string NAMESPACE_EDITOR = "EEE.Player.Editor";
        public const string NAMESPACE_TESTS = "EEE.Player.Tests";
        public const string NAMESPACE_PROXYGEN = "DynamicProxyGenAssembly2";
    }
}

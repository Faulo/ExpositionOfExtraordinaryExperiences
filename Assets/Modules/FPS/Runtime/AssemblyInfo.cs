using System.Runtime.CompilerServices;
using EEE.FPS;

[assembly: InternalsVisibleTo(AssemblyInfo.NAMESPACE_EDITOR)]
[assembly: InternalsVisibleTo(AssemblyInfo.NAMESPACE_TESTS)]
[assembly: InternalsVisibleTo(AssemblyInfo.NAMESPACE_PROXYGEN)]

namespace EEE.FPS {
    static class AssemblyInfo {
        public const string NAMESPACE_RUNTIME = "EEE.FPS";
        public const string NAMESPACE_EDITOR = "EEE.FPS.Editor";
        public const string NAMESPACE_TESTS = "EEE.FPS.Tests";
        public const string NAMESPACE_PROXYGEN = "DynamicProxyGenAssembly2";
    }
}

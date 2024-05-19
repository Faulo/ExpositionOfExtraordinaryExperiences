using System.Runtime.CompilerServices;
using EEE.Interfaces;

[assembly: InternalsVisibleTo(AssemblyInfo.NAMESPACE_EDITOR)]
[assembly: InternalsVisibleTo(AssemblyInfo.NAMESPACE_TESTS)]
[assembly: InternalsVisibleTo(AssemblyInfo.NAMESPACE_PROXYGEN)]

namespace EEE.Interfaces {
    static class AssemblyInfo {
        public const string NAMESPACE_RUNTIME = "EEE.Interfaces";
        public const string NAMESPACE_EDITOR = "EEE.Interfaces.Editor";
        public const string NAMESPACE_TESTS = "EEE.Interfaces.Tests";
        public const string NAMESPACE_PROXYGEN = "DynamicProxyGenAssembly2";
    }
}

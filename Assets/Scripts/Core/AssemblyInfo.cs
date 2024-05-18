using System.Runtime.CompilerServices;
using EEE.Core;

[assembly: InternalsVisibleTo(AssemblyInfo.NAMESPACE_EDITOR)]
[assembly: InternalsVisibleTo(AssemblyInfo.NAMESPACE_TESTS)]
[assembly: InternalsVisibleTo(AssemblyInfo.NAMESPACE_PROXYGEN)]

namespace EEE.Core {
    static class AssemblyInfo {
        public const string NAMESPACE_RUNTIME = "EEE.Core";
        public const string NAMESPACE_EDITOR = "EEE.Core.Editor";
        public const string NAMESPACE_TESTS = "EEE.Core.Tests";
        public const string NAMESPACE_PROXYGEN = "DynamicProxyGenAssembly2";
    }
}

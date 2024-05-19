using System;

namespace EEE.Core {
    interface IProcessLogger {
        event Action<string, string> onStart;
        event Action<string> onOutput;
        event Action<string> onError;
        event Action<int> onExit;

        void LogStart(string directory, string command);
        void AppendOutput(string text);
        void AppendError(string text);
        void LogExit(int code);
    }
}

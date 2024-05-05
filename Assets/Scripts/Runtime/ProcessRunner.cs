using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ExpositionOfExtraordinaryExperiences {
    sealed class ProcessRunner : IDisposable {
        readonly IProcessLogger logger;

        readonly CancellationTokenSource cts = new();

        internal ProcessRunner(IProcessLogger logger) {
            this.logger = logger;
        }

        internal async Task RunAsync(string directory, string command) {
            var token = cts.Token;
            await Task.Run(() => {
                var processInfo = new ProcessStartInfo() {
                    WorkingDirectory = directory,
                    WindowStyle = ProcessWindowStyle.Normal,
                    FileName = Path.Combine(directory, command),
                    UseShellExecute = false,
                    CreateNoWindow = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                };

                logger.LogStart(directory, command);

                if (token.IsCancellationRequested) {
                    return;
                }

                using var process = Process.Start(processInfo);

                process.OutputDataReceived += (_, e) => {
                    UnityEngine.Debug.Log(e);
                    logger.AppendOutput(e.Data);
                };

                process.ErrorDataReceived += (_, e) => {
                    UnityEngine.Debug.Log(e);
                    logger.AppendError(e.Data);
                };

                while (!process.HasExited) {
                    if (token.IsCancellationRequested) {
                        process.Kill();
                        return;
                    }

                    Thread.Sleep(100);
                }

                logger.LogExit(process.ExitCode);
            }, token);
        }

        public void Dispose() {
            cts.Cancel();
            cts.Dispose();
        }
    }
}

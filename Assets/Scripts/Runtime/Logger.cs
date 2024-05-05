using System;
using System.Collections.Concurrent;
using UnityEngine;

namespace ExpositionOfExtraordinaryExperiences {
    sealed class Logger : MonoBehaviour, IProcessLogger {
        public event Action<string, string> onStart;
        public event Action<string> onOutput;
        public event Action<string> onError;
        public event Action<int> onExit;

        readonly ConcurrentQueue<(string directory, string command)> startQueue = new();
        readonly ConcurrentQueue<(string text, bool isError)> dataQueue = new();
        readonly ConcurrentQueue<int> exitQueue = new();

        void Update() {
            while (startQueue.TryDequeue(out var start)) {
                onStart?.Invoke(start.directory, start.command);
            }

            while (dataQueue.TryDequeue(out var data)) {
                if (data.isError) {
                    onError?.Invoke(data.text);
                } else {
                    onOutput?.Invoke(data.text);
                }
            }

            while (exitQueue.TryDequeue(out int code)) {
                onExit?.Invoke(code);
            }
        }

        public void LogStart(string directory, string command) {
            startQueue.Enqueue((directory, command));
        }
        public void AppendOutput(string text) {
            dataQueue.Enqueue((text, false));
        }
        public void AppendError(string text) {
            dataQueue.Enqueue((text, true));
        }
        public void LogExit(int code) {
            exitQueue.Enqueue(code);
        }
    }
}

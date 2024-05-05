using System.IO;
using Slothsoft.UnityExtensions;
using TMPro;
using UnityEngine;

namespace ExpositionOfExtraordinaryExperiences {
    sealed class PrintLog : MonoBehaviour {

        TextMeshProUGUI textMesh;

        void Start() {
            if (TryGetComponent(out textMesh) && transform.TryGetComponentInParent<IProcessLogger>(out var logger)) {
                logger.onStart += Logger_onStart;
                logger.onOutput += Logger_onOutput;
                logger.onError += Logger_onError;
                logger.onExit += Logger_onExit;
            }
        }

        const string EOL = "\r\n";

        void Logger_onStart(string directory, string command) {
            textMesh.text = $"> {Path.Combine(directory, command)}{EOL}".Replace(' ', ' ');
        }

        void Logger_onOutput(string text) {
            textMesh.text += text.Replace(' ', ' ');
        }

        void Logger_onError(string text) {
            textMesh.text += $"<color=red>{text}</color>".Replace(' ', ' ');
        }

        void Logger_onExit(int code) {
            textMesh.text += $"<color=green>{code}</color>{EOL}";
        }
    }
}

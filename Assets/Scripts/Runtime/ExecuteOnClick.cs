using Slothsoft.UnityExtensions;
using UnityEngine;
using UnityEngine.UI;

namespace ExpositionOfExtraordinaryExperiences {
    sealed class ExecuteOnClick : MonoBehaviour {
        [SerializeField]
        string directory;
        [SerializeField]
        string command;
        [SerializeField]
        string arguments;

        Button button;
        IProcessLogger logger;
        ProcessRunner runner;

        void Start() {
            if (TryGetComponent(out button) && transform.TryGetComponentInParent(out logger)) {
                runner = new ProcessRunner(logger);
                button.onClick.AddListener(OnClick);
            }
        }

        void OnDestroy() {
            runner?.Dispose();
        }

        [ContextMenu(nameof(OnClick))]
        public async void OnClick() {
            if (button) {
                button.interactable = false;
            }

            await runner.RunAsync(directory, command);

            if (button) {
                button.interactable = true;
            }
        }
    }
}

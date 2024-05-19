using UnityEditor;

namespace EEE.Core.Editor {
    [CustomEditor(typeof(ModLoader))]
    public class ModLoaderEditor : UnityEditor.Editor {
        public override void OnInspectorGUI() {
            DrawDefaultInspector();

            if (target is ModLoader loader) {
                EditorGUILayout.Space();

                EditorGUILayout.LabelField("Mods");

                EditorGUI.indentLevel++;
                foreach (var mod in ModLoader.mods) {
                    EditorGUILayout.LabelField(mod.name);
                }

                EditorGUI.indentLevel--;

                EditorGUILayout.LabelField("Character Controllers");

                EditorGUI.indentLevel++;
                foreach (var character in loader.characters) {
                    EditorGUILayout.LabelField(character.name, character.description);
                }

                EditorGUI.indentLevel--;
            }
        }
    }
}

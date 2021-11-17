using System.Reflection;

using ProjectCard.Shared.SaveModule;

using UnityEditor;

using UnityEngine;

namespace ProjectCard.EditorModule.Shared.SaveModule
{
    [CustomEditor(typeof(SaveKey))]
    [CanEditMultipleObjects]
    public class SaveKeyEditorDrawer : Editor
    {
        public override void OnInspectorGUI()
        {
            var type = typeof(SaveKey);

            var method = type.GetMethod("GenerateNewKey", BindingFlags.NonPublic | BindingFlags.Instance);

            UnityEngine.Object[] array = targets;

            foreach (SaveKey item in array)
            {
                GUILayout.BeginVertical();

                DrawText(item);

                DrawGenerateNewKeyButton(item, method, "New Key");

                GUILayout.Space(10);

                GUILayout.EndVertical();
            }
            if (array.Length > 1)
            {
                GUILayout.Space(20);
                DrawGenerateNewKeyButtonGroup(array, method, "New Key for Selected");
            }
        }

        private void DrawGenerateNewKeyButton(SaveKey save, MethodInfo method, string text)
        {
            if (GUILayout.Button(text))
            {
                InvokeGenerateAndSave(save, method);
            }
        }
        private void DrawGenerateNewKeyButtonGroup(UnityEngine.Object[] saves, MethodInfo method, string text)
        {
            if (GUILayout.Button(text))
            {
                foreach (SaveKey save in saves)
                {
                    InvokeGenerateAndSave(save, method);
                }
            }
        }

        public void InvokeGenerateAndSave(SaveKey save, MethodInfo method)
        {
            method.Invoke(save, null);

            EditorUtility.SetDirty(save);

            AssetDatabase.SaveAssetIfDirty(save);

            PrefabUtility.RecordPrefabInstancePropertyModifications(save);
        }

        private void DrawText(SaveKey save)
        {
            GUILayout.Label(save.name);

            GUI.enabled = false;

            GUILayout.TextField(save.ToString());

            GUI.enabled = true;

            GUILayout.Space(5);
        }
    }
}
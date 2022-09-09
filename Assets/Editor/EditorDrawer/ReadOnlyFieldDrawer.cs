
using Framework.Shared.Core.Attributes;

using UnityEditor;

using UnityEngine;

namespace ProjectCard.EditorModule.Shared.CoreModule.AttributeModule
{
    [CustomPropertyDrawer(typeof(ViewOnlyAttribute))]
    public class ReadOnlyFieldDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property,
                                                GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, includeChildren: true);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GUI.enabled = false;
            EditorGUI.PropertyField(position, property, label, includeChildren: true);
            GUI.enabled = true;
        }
    }
}

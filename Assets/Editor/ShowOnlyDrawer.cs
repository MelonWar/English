using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ShowOnlyAttribute))]
public class ShowOnlyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty p, GUIContent label)
    {
        string valueStr;

        switch(p.propertyType)
        {
            case SerializedPropertyType.Boolean:
                valueStr = p.boolValue.ToString();
                break;
            case SerializedPropertyType.String:
                valueStr = p.stringValue;
                break;
            case SerializedPropertyType.Float:
                valueStr = p.floatValue.ToString();
                break;
            case SerializedPropertyType.Integer:
                valueStr = p.intValue.ToString();
                break;
            case SerializedPropertyType.Vector2:
                valueStr = p.vector2Value.ToString();
                break;
            case SerializedPropertyType.Vector3:
                valueStr = p.vector3Value.ToString();
                break;
            default:
                valueStr = "(not supported)";
                break;
        }

        EditorGUI.LabelField(position, label.text, valueStr);
    }
}

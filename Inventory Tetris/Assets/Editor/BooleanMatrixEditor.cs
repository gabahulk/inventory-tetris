using System.Collections;
using UnityEngine;
using UnityEditor;
[CustomPropertyDrawer(typeof(Shape))]
public class BooleanMatrixEditor : PropertyDrawer
{

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.PrefixLabel(position, label);
        position.y += 20;
        SerializedProperty width = property.FindPropertyRelative("width");
        SerializedProperty height = property.FindPropertyRelative("height");
        using (var scope = new EditorGUI.PropertyScope(position, label, property))
        {
            Rect newposition = position;
            newposition.x += 18f;
            SerializedProperty data = property.FindPropertyRelative("rows");
            //data.rows[0][]
            for (int j = 0; j < width.intValue; j++)
            {
                SerializedProperty row = data.GetArrayElementAtIndex(j).FindPropertyRelative("row");
                newposition.height = 18f;
                newposition.width = 18f;
                if (row.arraySize != 7)
                    row.arraySize = 7;
                for (int i = (height.intValue - 1); i >= 0; i--)
                {
                    EditorGUI.PropertyField(newposition, row.GetArrayElementAtIndex(i),GUIContent.none);
                    newposition.y += newposition.width;
                }

                newposition.y = position.y;
                newposition.x += 18f;
            }
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return 18f * 8;
    }
}

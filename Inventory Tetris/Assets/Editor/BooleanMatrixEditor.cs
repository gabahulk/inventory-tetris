using System.Collections;
using UnityEngine;
using UnityEditor;
[CustomPropertyDrawer(typeof(Shape))]
public class BooleanMatrixEditor : PropertyDrawer
{
    int width = 3;
    int height = 3;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), new GUIContent("Width"));
        Vector2 sizePos = position.position + Vector2.right* 40;
        width = EditorGUI.IntField(new Rect(sizePos , new Vector2(70,20)),width);

        position.y += 20;
        sizePos = position.position + Vector2.right * 40;
        EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), new GUIContent("Height"));
        height = EditorGUI.IntField(new Rect(sizePos, new Vector2(70, 20)), height);

        // position.y += 20;

        // using (var scope = new EditorGUI.PropertyScope(position, label, property))
        // {
        //     Rect newposition = position;
        //     newposition.x += 18f;
        //     SerializedProperty data = property.FindPropertyRelative("rows");
        //     //data.rows[0][]
        //     for (int j = 0; j < width; j++)
        //     {
        //         SerializedProperty row = data.GetArrayElementAtIndex(j);
        //         newposition.height = 18f;
        //         newposition.width = 18f;
        //         // if (row.arraySize != 7)
        //         //     row.arraySize = 7;
        //         // for (int i = (height - 1); i >= 0; i--)
        //         // {
        //         //     EditorGUI.PropertyField(newposition, row.GetArrayElementAtIndex(i),GUIContent.none);
        //         //     newposition.y += newposition.width;
        //         // }

        //         newposition.y = position.y;
        //         newposition.x += 18f;
        //     }
        // }
        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return 18f * 8;
    }
}

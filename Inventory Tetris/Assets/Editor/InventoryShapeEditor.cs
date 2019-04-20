using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomPropertyDrawer(typeof(Shape),true)]
public class InventoryShapeEditor : PropertyDrawer
{

    float comboBoxHeight = 30;
    float comboBoxWidth = 30;

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        // Defines property height on editor
        int height = property.FindPropertyRelative("Height").intValue;

        return EditorGUIUtility.singleLineHeight * 3 + comboBoxHeight * height;
    }


    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        EditorGUI.LabelField(position, label);
        var propertyHeight = EditorGUIUtility.singleLineHeight;
        var widthRect = new Rect(position.x, position.y + propertyHeight, position.width, propertyHeight);
        var heightRect = new Rect(position.x, position.y + propertyHeight * 2, position.width, propertyHeight);

        EditorGUI.indentLevel++;

        EditorGUI.PropertyField(widthRect, property.FindPropertyRelative("Width"));
        EditorGUI.PropertyField(heightRect, property.FindPropertyRelative("Height"));

        int width = property.FindPropertyRelative("Width").intValue;
        int height = property.FindPropertyRelative("Height").intValue;
        int size = width * height;

        

        float initialYPos = heightRect.y + comboBoxHeight * height;
        
        float positionX;
        float positionY;
        float offset = 15;
        propertyHeight += offset;

        SerializedProperty data = property.FindPropertyRelative("Slots");
        for (int i = 0; i < size; i++)
        {
            if (data.GetArrayElementAtIndex(i) == null)
            {
                data.InsertArrayElementAtIndex(i);
            }

            positionY = initialYPos - (int)(i / width) * comboBoxHeight;
            positionX = position.x + comboBoxWidth * (i % width);
            var booleanMatrixComboBoxRect = new Rect(positionX, positionY, comboBoxWidth, comboBoxHeight);

            EditorGUI.PropertyField(booleanMatrixComboBoxRect, data.GetArrayElementAtIndex(i), GUIContent.none);
        }

        EditorGUI.indentLevel--;

        EditorGUI.EndProperty();
    }

}

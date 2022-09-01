using UnityEditor;

[CustomEditor(typeof(ScriptableObjectHandler))]
public class ObjectsEditor : Editor
{
    //private SerializedProperty filter;
    private SerializedProperty blacklist;
    private SerializedProperty newPaths;

    private void OnEnable()
    {
        //filter = serializedObject.FindProperty("filter");
        blacklist = serializedObject.FindProperty("blacklist");
        newPaths = serializedObject.FindProperty("newPaths");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        //EditorGUILayout.PropertyField(filter);
        EditorGUILayout.PropertyField(blacklist);
        EditorGUILayout.PropertyField(newPaths);
        newPaths.arraySize = 5;
        serializedObject.ApplyModifiedProperties();
    }
}
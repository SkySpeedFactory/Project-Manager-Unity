using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(ScriptableObjectHandler))]
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ProjectManager", order = 1)]
public class ScriptableObjectHandler : ScriptableObject
{
    //[Tooltip("The Asset you would like to Filter")]
    //public string filter;

    [Tooltip("The Folders you would like to Blacklist from changing the path of the Assets")]
    public string[] blacklist;

    [Tooltip("The Paths you would like to move the Assets to (Max. 5)")]
    public string[] newPaths;
}
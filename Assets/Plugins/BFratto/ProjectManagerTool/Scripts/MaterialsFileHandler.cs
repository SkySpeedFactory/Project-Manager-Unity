using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

public class MaterialsFileHandler : MonoBehaviour
{
    private static ScriptableObjectHandler _materialObjectHandler;

    [MenuItem("ProjectManager/Move Materials To/New Path/1st")]
    static void Move()
    {
        InitializeObject();
        MoveAssets(0);
    }

    [MenuItem("ProjectManager/Move Materials To/New Path/2nd")]
    static void Move1()
    {
        InitializeObject();
        MoveAssets(1);
    }

    [MenuItem("ProjectManager/Move Materials To/New Path/3nd")]
    static void Move2()
    {
        InitializeObject();
        MoveAssets(2);
    }

    [MenuItem("ProjectManager/Move Materials To/New Path/4th")]
    static void Move3()
    {
        InitializeObject();
        MoveAssets(3);
    }

    [MenuItem("ProjectManager/Move Materials To/New Path/5th")]
    static void Move4()
    {
        InitializeObject();
        MoveAssets(4);
    }
    
    static void MoveAssets(int i)
    {
        var blacklist = new List<string>();
        if (_materialObjectHandler.blacklist != null)
        {
            blacklist = _materialObjectHandler.blacklist.Where(item => !string.IsNullOrEmpty(item)).ToList();
        }
        foreach (var asset in AssetDatabase.FindAssets($"t: Material"))
        {
            var path = AssetDatabase.GUIDToAssetPath(asset);
            if (!path.Contains("Assets"))
            {
                continue;
            }
            var assetName = AssetDatabase.LoadMainAssetAtPath(path).name;

            if (!blacklist.Any(item => path.Contains(item)))
            {
                AssetDatabase.MoveAsset(path, $"{_materialObjectHandler.newPaths[i]}/{assetName}.mat");
            }
        }
    }

    static void InitializeObject()
    {
        _materialObjectHandler =
            AssetDatabase.LoadAssetAtPath<ScriptableObjectHandler>(
                "Assets/Plugins/BFratto/ProjectManagerTool/ManagerObjects/Materials.asset");
    }
}
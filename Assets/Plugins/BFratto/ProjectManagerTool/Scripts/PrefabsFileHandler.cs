using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

public class PrefabsFileHandler : MonoBehaviour
{
    private static ScriptableObjectHandler _prefabObjectHandler;

    [MenuItem("ProjectManager/Move Prefabs To/New Path/1st")]
    static void Move()
    {
        InitializeObject();
        MoveAssets(0);
    }

    [MenuItem("ProjectManager/Move Prefabs To/New Path/2nd")]
    static void Move1()
    {
        InitializeObject();
        MoveAssets(1);
    }

    [MenuItem("ProjectManager/Move Prefabs To/New Path/3nd")]
    static void Move2()
    {
        InitializeObject();
        MoveAssets(2);
    }

    [MenuItem("ProjectManager/Move Prefabs To/New Path/4th")]
    static void Move3()
    {
        InitializeObject();
        MoveAssets(3);
    }

    [MenuItem("ProjectManager/Move Prefabs To/New Path/5th")]
    static void Move4()
    {
        InitializeObject();
        MoveAssets(4);
    }

    static void MoveAssets(int i)
    {
        var blacklist = new List<string>();
        if (_prefabObjectHandler.blacklist != null)
        {
            blacklist = _prefabObjectHandler.blacklist.Where(item => !string.IsNullOrEmpty(item)).ToList();
        }
        foreach (var asset in AssetDatabase.FindAssets($"t: Prefab"))
        {
            var path = AssetDatabase.GUIDToAssetPath(asset);
            if (!path.Contains("Assets"))
            {
                continue;
            }
            var assetName = AssetDatabase.LoadMainAssetAtPath(path).name;

            if (!blacklist.Any(item => path.Contains(item)))
            {
                AssetDatabase.MoveAsset(path, $"{_prefabObjectHandler.newPaths[i]}/{assetName}.prefab");
            }
        }
    }

    static void InitializeObject()
    {
        _prefabObjectHandler =
            AssetDatabase.LoadAssetAtPath<ScriptableObjectHandler>(
                "Assets/Plugins/BFratto/ProjectManagerTool/ManagerObjects/Prefabs.asset");
    }
}
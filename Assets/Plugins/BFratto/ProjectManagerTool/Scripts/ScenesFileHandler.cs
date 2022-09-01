using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

public class ScenesFileHandler : MonoBehaviour
{
    private static ScriptableObjectHandler _scenesObjectHandler;

    [MenuItem("ProjectManager/Move Scenes To/New Path/1st")]
    static void Move()
    {
        InitializeObject();
        MoveAssets(0);
    }

    [MenuItem("ProjectManager/Move Scenes To/New Path/2nd")]
    static void Move1()
    {
        InitializeObject();
        MoveAssets(1);
    }

    [MenuItem("ProjectManager/Move Scenes To/New Path/3nd")]
    static void Move2()
    {
        InitializeObject();
        MoveAssets(2);
    }

    [MenuItem("ProjectManager/Move Scenes To/New Path/4th")]
    static void Move3()
    {
        InitializeObject();
        MoveAssets(3);
    }

    [MenuItem("ProjectManager/Move Scenes To/New Path/5th")]
    static void Move4()
    {
        InitializeObject();
        MoveAssets(4);
    }

    static void MoveAssets(int i)
    {
        var blacklist = new List<string>();
        if (_scenesObjectHandler.blacklist != null)
        {
            blacklist = _scenesObjectHandler.blacklist.Where(item => !string.IsNullOrEmpty(item)).ToList();
        }
        foreach (var asset in AssetDatabase.FindAssets($"t: Scene"))
        {
            var path = AssetDatabase.GUIDToAssetPath(asset);
            if (!path.Contains("Assets"))
            {
                continue;
            }
            var assetName = AssetDatabase.LoadMainAssetAtPath(path).name;

            if (!blacklist.Any(item => path.Contains(item)))
            {
                AssetDatabase.MoveAsset(path, $"{_scenesObjectHandler.newPaths[i]}/{assetName}.unity");
            }
        }
    }

    static void InitializeObject()
    {
        _scenesObjectHandler =
            AssetDatabase.LoadAssetAtPath<ScriptableObjectHandler>(
                "Assets/Plugins/BFratto/ProjectManagerTool/ManagerObjects/Scenes.asset");
    }
}
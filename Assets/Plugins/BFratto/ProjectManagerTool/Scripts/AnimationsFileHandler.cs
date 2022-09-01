using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

public class AnimationsFileHandler : MonoBehaviour
{
    private static ScriptableObjectHandler _animObjectHandler;

    [MenuItem("ProjectManager/Move Animations To/New Path/1st")]
    static void Move()
    {
        InitializeObject();
        MoveAssets(0);
    }

    [MenuItem("ProjectManager/Move Animations To/New Path/2nd")]
    static void Move1()
    {
        InitializeObject();
        MoveAssets(1);
    }

    [MenuItem("ProjectManager/Move Animations To/New Path/3nd")]
    static void Move2()
    {
        InitializeObject();
        MoveAssets(2);
    }

    [MenuItem("ProjectManager/Move Animations To/New Path/4th")]
    static void Move3()
    {
        InitializeObject();
        MoveAssets(3);
    }

    [MenuItem("ProjectManager/Move Animations To/New Path/5th")]
    static void Move4()
    {
        InitializeObject();
        MoveAssets(4);
    }
    
    static void MoveAssets(int i)
    {
        var blacklist = new List<string>();
        if (_animObjectHandler.blacklist != null)
        {
            blacklist = _animObjectHandler.blacklist.Where(item => !string.IsNullOrEmpty(item)).ToList();
        }
        foreach (var asset in AssetDatabase.FindAssets($"t: Animation"))
        {
            var path = AssetDatabase.GUIDToAssetPath(asset);
            if (!path.Contains("Assets"))
            {
                continue;
            }
            var assetName = AssetDatabase.LoadMainAssetAtPath(path).name;

            if (!blacklist.Any(item => path.Contains(item)))
            {
                AssetDatabase.MoveAsset(path, $"{_animObjectHandler.newPaths[i]}/{assetName}.anim");
            }
        }
    }

    static void InitializeObject()
    {
        _animObjectHandler =
            AssetDatabase.LoadAssetAtPath<ScriptableObjectHandler>(
                "Assets/Plugins/BFratto/ProjectManagerTool/ManagerObjects/Animations.asset");
    }
}
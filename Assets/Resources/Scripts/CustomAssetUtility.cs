﻿using UnityEngine;
using UnityEditor;
using System.IO;

public static class CustomAssetUtility {
    public static void CreateAsset<T>() where T : ScriptableObject {
        T asset = ScriptableObject.CreateInstance<T>();

        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        if (path == "") {
            path = "Assets/Resources";
        } else if (Path.GetExtension(path) != "") {
            path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
        }

        string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/New " + typeof(T).ToString() + ".asset");

        AssetDatabase.CreateAsset(asset, assetPathAndName);

        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }

    //if you call ScriptableObject.CreateInstance this will need to be invoked for persistance
    public static void AddAssetToDB(string folder, ScriptableObject obj) {

        string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(folder + "/" + obj.name + ".asset");
        Debug.Log("Adding object asset: " + assetPathAndName);
        AssetDatabase.CreateAsset(obj, assetPathAndName);
        AssetDatabase.SaveAssets();

    }

    public static void AddObjToAsset(ScriptableObject parent, ScriptableObject child) {
        Debug.Log("Adding asset child");
        if (!AssetDatabase.Contains(child)) {
            AddAssetToDB(getAssetFolder(parent), child);
        }
        AssetDatabase.AddObjectToAsset(child, parent);
        AssetDatabase.SaveAssets();
        AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(parent));
    }

    //Get just the folder name of an asset.  The asset must exist in the database
    public static string getAssetFolder(ScriptableObject asset) {
        if (!AssetDatabase.Contains(asset)) {
            Debug.LogError("Did you read the documentation?  Because I think it says your asset has to be in the database to call this.");
            return "RTFM";
        }
        string path = AssetDatabase.GetAssetPath(asset);
        return Path.GetDirectoryName(path);
    }
}
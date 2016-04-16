using UnityEngine;
using UnityEditor;
using System.IO;

public static class CustomAssetUtility {
    public static void CreateAsset<T>() where T : ScriptableObject {
        T asset = ScriptableObject.CreateInstance<T>();

        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        if (path == "") {
            path = "Assets";
        } else if (Path.GetExtension(path) != "") {
            path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
        }

        string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/New " + typeof(T).ToString() + ".asset");

        AssetDatabase.CreateAsset(asset, assetPathAndName);

        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }

    public static void AddObjToAsset(ScriptableObject parent, ScriptableObject child) {
        Debug.Log("Adding asset obj");
        //Debug.Log("Child is an asset? : " + AssetDatabase.Contains(child));
        if(!AssetDatabase.Contains(child)) {
            string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(getAssetFolder(parent) + child.name + ".asset");
            Debug.Log("Creating child asset: " + assetPathAndName);
            AssetDatabase.CreateAsset(child, assetPathAndName);
        }
        AssetDatabase.AddObjectToAsset(child, parent);
        AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(parent));
    }

    //Get just the folder name of an asset.  The asset must exist in the database
    public static string getAssetFolder(ScriptableObject asset) {
        if(!AssetDatabase.Contains(asset)) {
            Debug.LogError("Did you read the documentation?  Because I think it says your asset has to be in the database to call this.");
            return "RTFM";
        }
        string path = AssetDatabase.GetAssetPath(asset);
        return Path.GetDirectoryName(path);
    }
}
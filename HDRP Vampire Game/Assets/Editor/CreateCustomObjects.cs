using UnityEditor;
using UnityEngine;

public class CreateCustomObjects
{
    
    [MenuItem("GameObject/Custom", false, 1)]

    [MenuItem("GameObject/Custom/Examined Object", false, 0)]
    static void NewMenuOption(MenuCommand menuCommand)
    {
        var exString = AssetDatabase.FindAssets("Examined", new[] {"Assets/Prefabs"});
        var path = AssetDatabase.GUIDToAssetPath(exString[0]);
        var examinedObjectPrefab = AssetDatabase.LoadAssetAtPath(path, typeof(GameObject));
        Debug.Log(examinedObjectPrefab.name);
        var newObj = PrefabUtility.InstantiatePrefab(examinedObjectPrefab as GameObject);
        //var newObj =  Object.Instantiate(examinedObjectPrefab);
    }
    
}

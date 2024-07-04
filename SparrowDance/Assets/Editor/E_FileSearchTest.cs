using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class E_FileSearchTest : MonoBehaviour
{

    [MenuItem("Helpful Functions/Test")]
    static void Search()
    {
        /*var path = Application.dataPath;
        string[] files = Directory.GetFiles(path, "*.asset", SearchOption.AllDirectories);
         
        //We want to check if the TMP version of the font exists or not
        foreach (var file in files)
        {
            Debug.Log(file);
            
        }*/
        var selectedObjects = Selection.gameObjects;

        foreach (var obj in selectedObjects)
        { 
            var oFont = obj.GetComponent<Text>().font;
            // Debug.Log(AssetDatabase.GetAssetPath(oFont));
            // Debug.Log(oFont.ToString());
            var newNew = TMP_FontAsset.CreateFontAsset(oFont);
            Debug.Log(AssetDatabase.GetAssetPath(newNew));
        }

    }
}

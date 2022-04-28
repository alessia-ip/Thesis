
using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class E_ChangeTextToTmp : MonoBehaviour
{
   // Add a menu item named "Do Something" to MyMenu in the menu bar.
   [MenuItem("Helpful Functions/Replace Text with TMP")]
   static void ChangeText()
   {
      var selectedObjects = Selection.gameObjects;
      foreach (var obj in selectedObjects)
      {
         var oText = obj.GetComponent<Text>().text;
         var oColor = obj.GetComponent<Text>().color;
         var oSize = obj.GetComponent<Text>().fontSize;
         var oAlign = obj.GetComponent<Text>().alignment.ToString();
         DestroyImmediate(obj.GetComponent<Text>());
         var newTMP = obj.AddComponent<TextMeshProUGUI>();
         newTMP.text = oText;
         newTMP.color = oColor;
         newTMP.fontSize = oSize;
         
         HorizontalAlignmentOptions newHAlignment = HorizontalAlignmentOptions.Center;
         VerticalAlignmentOptions newVAlignment = VerticalAlignmentOptions.Middle;
            
         if (oAlign.Contains("left"))
         {
            newHAlignment = HorizontalAlignmentOptions.Left;
         } else if (oAlign.Contains("right"))
         {
            newHAlignment = HorizontalAlignmentOptions.Right;
         }
         
         if (oAlign.Contains("Bottom"))
         {
            newVAlignment = VerticalAlignmentOptions.Bottom;
         } else if (oAlign.Contains("Top"))
         {
            newVAlignment = VerticalAlignmentOptions.Top;
         }
         
         newTMP.horizontalAlignment = newHAlignment;
         newTMP.verticalAlignment = newVAlignment;
         
      }
   }
}

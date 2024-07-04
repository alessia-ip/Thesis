using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class E_ChangeTextToTmp : MonoBehaviour
{
   
   //A simple editor script that replaced Text components with a TextMeshPro component

   [MenuItem("Helpful Functions/Replace Text with TMP")]
   static void ChangeText()
   {
      //This information is just for clarity on what's happening
      //This info will show up in a debug, but isn't essential
      int NumReplaced = 0;
      int NumIgnored = 0;
      
      //This is all the gameobjects selected in the hierarchy when the function is called
      var selectedObjects = Selection.gameObjects;
      
      //For every gameobject, we want to check if it has a Text component or not
      foreach (var obj in selectedObjects)
      {
         //If it doesn't have a Text component we don't do anything to that's gameobject
         if (!obj.TryGetComponent(out Text text))
         {
            //we keep a record that there was an object selected that did not have a Text component
            NumIgnored++;
            //Then we're going to continue checking the rest of our list of objects
            continue;
         }
         
         //Here we get all of the important variables of the original Text component
         var oText = obj.GetComponent<Text>().text;
         var oColor = obj.GetComponent<Text>().color;
         var oSize = obj.GetComponent<Text>().fontSize;
         var oAlign = obj.GetComponent<Text>().alignment.ToString();
         var oFont = obj.GetComponent<Text>().font;
         
         //Then we destroy that component!
         DestroyImmediate(obj.GetComponent<Text>());
         
         //Next, we add a TextMeshPro component
         var newTMP = obj.AddComponent<TextMeshProUGUI>();
         
         //We can set some of these variables from what we collected earlier
         //Text, color, and font size are all using the same type of variable
         newTMP.text = oText;
         newTMP.color = oColor;
         newTMP.fontSize = oSize;
         
         //Alignment is handled differently between Text and TMP components
         //We have to do some extra conversion work here
         //This is the default alignment
         HorizontalAlignmentOptions newHAlignment = HorizontalAlignmentOptions.Center;
         VerticalAlignmentOptions newVAlignment = VerticalAlignmentOptions.Middle;
            
         //From what we gathered earlier, we try and see if the alignment was set to something else
         //EG. if it's left, it's a left align and if it's right it's a right align
         if (oAlign.ToLower().Contains("left"))
         {
            newHAlignment = HorizontalAlignmentOptions.Left;
         } else if (oAlign.ToLower().Contains("right"))
         {
            newHAlignment = HorizontalAlignmentOptions.Right;
         }
         
         //We do the same thing as above, but for the vertical alignment
         if (oAlign.ToLower().Contains("lower"))
         {
            newVAlignment = VerticalAlignmentOptions.Bottom;
         } else if (oAlign.ToLower().Contains("upper"))
         {
            newVAlignment = VerticalAlignmentOptions.Top;
         }
         
         //Then we can assign the alignment to the TextMeshPro component
         newTMP.horizontalAlignment = newHAlignment;
         newTMP.verticalAlignment = newVAlignment;

         //TMP also uses a different font format
         //We cannot just assign the font from the original Text component
         TMP_FontAsset newFont;

         //Here we're removing (GameObject) from the name of the font
         var oFontName = oFont.ToString().Split('(')[0];
         
         //This is to get directory info for the project
         var path = Application.dataPath;
         
         //Then we quickly get a list of files in the project
         //This will search through ALL project folders
         //Since TextMeshPro fonts are .asset files, we limit this to that file type for a quicker search
         string[] files = Directory.GetFiles(path, "*.asset", SearchOption.AllDirectories);

         //We want to check if the TMP version of the font exists or not
         bool foundTheFont = false;
         
         //For every .asset file, we compare to see if it's a match to the original font
         //This is done by name
         //This will NOT find the font if they are named differently!!
         foreach (var file in files)
         {
            //We store the file name so we can do a string comparison
            var nFile = file.ToLower();
            
            //If the file we're checking contains the name of the font, we assume that's the correct font
            if(nFile.Contains(oFontName.ToLower()))
            {
               //We get the datapath of the text mesh pro font
               var newPath = "Assets" + file.Replace(Application.dataPath, "");
               
               //then we keep a copy of that font, loading it from the asset database
               newFont = (TMP_FontAsset)AssetDatabase.LoadAssetAtPath(newPath, typeof(TMP_FontAsset));
               
               //once we've loaded the font, we assign that to our TextMeshPro component
               newTMP.font = newFont;
               
               //We mark this bool true, as we don't need to create a new font
               foundTheFont = true;
            }
         }

         //If we do not find a matching TextMeshPro font in the project, we try and make a new font to use
         if (!foundTheFont)
         {
            Debug.Log("Did not find font " + oFontName);
            
            //In the top level of the assets folder, we create the new font with the original font name
            //The font asset can be moved to a different location after the fact!!
            AssetDatabase.CreateAsset(
               TMP_FontAsset.CreateFontAsset(oFont),
               "Assets/" + oFontName + ".asset");
            
            //After the font has been created, we get the path to this font
            var newPath = "Assets/" + oFontName + ".asset";
            
            Debug.Log("Created new TMP font " + oFontName + " at: " + newPath);
            
            //Once the new font is created, we can use it the same way we can use pre-existing fonts
            var newTMPFont = (TMP_FontAsset)AssetDatabase.LoadAssetAtPath(newPath, typeof(TMP_FontAsset));
            newTMP.font = newTMPFont;
         }

         //This is to keep a record of the number of successfully replaced components 
         NumReplaced++;
      }

      //The below statements are just to keep track in the editor of the changes that were made
      if (NumReplaced > 0)
      {
         Debug.Log(NumReplaced + " text components have been successfully updated to TextMeshPro.");
      } else if (NumReplaced == 0)
      {
         Debug.Log("No GameObjects were updated from Text to TextMeshProComponents!");
      }

      if (NumIgnored > 0 && NumReplaced != 0) 
      {
         Debug.Log(NumIgnored + " GameObjects did not have Text components and have been ignored.");
      }
   }
}

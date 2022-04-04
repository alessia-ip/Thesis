using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialWiggler : MonoBehaviour
{

    //THANK YOU JULIAN

    public List<Material> WigglyMaterials;
    public bool makeSmaller = false;

    public float timeToChange = 2;
    public float currentTime;
    
    // Update is called once per frame
    void Update()
    {

        currentTime = currentTime + Time.deltaTime;

        if (currentTime >= timeToChange)
        {
            UpdateMaterial();
            currentTime = 0;
        }

    }

    void UpdateMaterial()
    {
        foreach (var material in WigglyMaterials)
        {
            var currentFloat = material.GetFloat("_OutlineSize");
            var newFloat = currentFloat;
            if (makeSmaller)
            {
                newFloat = currentFloat - 0.01f;
            }
            else
            {
                newFloat = currentFloat + 0.01f;
            }
            
            material.SetFloat("_OutlineSize", newFloat);
        }

        makeSmaller = !makeSmaller;
    }
}

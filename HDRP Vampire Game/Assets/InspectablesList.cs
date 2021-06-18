using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class InspectablesList : MonoBehaviour
{

    public List<detail> DetailsList; 

    [System.Serializable]
    public class detail
    {
        public string detailName;
        public string detailText;
        public AudioClip detailAudio;
        public GameObject detailObj;
    }

    public void CreateInspectablesList(int DetailNum)
    {
        var children = new List<GameObject>();
        foreach (Transform child in this.gameObject.transform)
        {
            children.Add(child.gameObject);
        }

        if (this.transform.childCount > DetailNum)
        {
            
            var cull = this.transform.childCount;
            for (int i = DetailNum; i < cull ; i++)
            {
                DestroyImmediate(children[i]);
            }

            var iVal = DetailsList.Count;
            for (int i = iVal; i >= 0; i--)
            {
                if (DetailsList[i - 1].detailObj == null)
                {
                    DetailsList.RemoveAt(i-1);
                }
            }
        } else if (this.transform.childCount < DetailNum)
        {
            var dif = DetailNum - this.transform.childCount;
            for (int i = 0; i < dif; i++)
            {
                var child = Instantiate(children[0]);
                child.name = "Inspectable";
                child.transform.parent = this.transform;
                child.SetActive(true);
                var newDetail = new detail();
                newDetail.detailObj = child;
                DetailsList.Add(newDetail);
            }
        }

    }
    
}

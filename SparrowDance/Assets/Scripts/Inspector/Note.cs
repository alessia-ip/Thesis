using UnityEngine;

public class Note : MonoBehaviour
{
     [TextArea(4,20)]
     [Tooltip("Doesn't do anything. Just comments shown in inspector")]
     public string Notes = "This component shouldn't be removed, it does important stuff.";
}

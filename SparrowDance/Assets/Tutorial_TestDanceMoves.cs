using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_TestDanceMoves : MonoBehaviour
{

    public GameObject ImgInputOne;
    public GameObject ImgInputTwo;

    public int NumInputOne = 10;
    public int NumInputTwo = 10;
    
    public Sprite Calm;
    public Sprite Spontaneous;
    public Sprite Passionate;
    public Sprite Encouraging;

    public bool BInputOne = false;
    public bool BInputTwo = false;
    
    public Animator playerAnimator;

    // Update is called once per frame
    void Update()
    {
        if (BInputOne && BInputTwo)
        {
            var playerMove = this.gameObject.GetComponent<ds_playerActionsList>().allPlayerDanceActionCombos[NumInputOne, NumInputTwo];
            
            if (playerMove.actionName.ToLower().Contains("wiggle"))
            {
                playerAnimator.SetTrigger("Wiggle");
            } else if (playerMove.actionName.ToLower().Contains("wavey"))
            {
                playerAnimator.SetTrigger("Wavey");
            }else if (playerMove.actionName.ToLower().Contains("foot"))
            {
                playerAnimator.SetTrigger("FootTap");
            }else if (playerMove.actionName.ToLower().Contains("twirl"))
            {
                playerAnimator.SetTrigger("Twirl");
            }else if (playerMove.actionName.ToLower().Contains("leg"))
            {
                playerAnimator.SetTrigger("StretchLeg");
            }else if (playerMove.actionName.ToLower().Contains("point"))
            {
                playerAnimator.SetTrigger("Point");
            }else if (playerMove.actionName.ToLower().Contains("sway"))
            {
                playerAnimator.SetTrigger("Sway");
            }else if (playerMove.actionName.ToLower().Contains("kiss"))
            {
                playerAnimator.SetTrigger("BlowKiss");
            }else if (playerMove.actionName.ToLower().Contains("pose"))
            {
                playerAnimator.SetTrigger("Pose");
            }
            else if (playerMove.actionName.ToLower().Contains("beckon"))
            {
                playerAnimator.SetTrigger("Beckon");
            }
            
            Invoke(nameof(ResetMoves), 0.5f);
        }
    }

    void ResetMoves()
    {
        ResetAllTriggers(playerAnimator);
        
        ImgInputOne.GetComponent<Image>().sprite = null;
        ImgInputTwo.GetComponent<Image>().sprite = null;

        NumInputOne = 10;
        NumInputTwo = 10;

        BInputOne = false;
        BInputTwo = false;
    }
    
    private void ResetAllTriggers(Animator anim)
    {
        foreach (var param in anim.parameters)
        {
            if (param.type == AnimatorControllerParameterType.Trigger)
            {
                anim.ResetTrigger(param.name);
            }
        }
    }
}

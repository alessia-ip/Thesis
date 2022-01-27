using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ds_PlayerCharacterAnimations : MonoBehaviour
{
    private void Awake()
    {
        ds_Service.PlayerCharacterAnimationsInGame = this;
    }
}

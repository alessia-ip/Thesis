using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ds_EmotionModifiersToCall : MonoBehaviour
{
   
   public void ModifyVibe(float AmountToModifyBy)
   {
      ds_Service.GameManagerInGame.sceneDanceInformation.vibe =
         ds_Service.GameManagerInGame.sceneDanceInformation.vibe + AmountToModifyBy;
   }
   
   public void ModifyExcitement(float AmountToModifyBy)
   {
      ds_Service.GameManagerInGame.sceneDanceInformation.excitement =
         ds_Service.GameManagerInGame.sceneDanceInformation.excitement + AmountToModifyBy;
   }
   
   public void ModifyContentment(float AmountToModifyBy)
   {
      ds_Service.GameManagerInGame.sceneDanceInformation.contentment =
         ds_Service.GameManagerInGame.sceneDanceInformation.contentment + AmountToModifyBy;
   }
   
   public void ModifyAffection(float AmountToModifyBy)
   {
      ds_Service.GameManagerInGame.sceneDanceInformation.affection =
         ds_Service.GameManagerInGame.sceneDanceInformation.affection + AmountToModifyBy;
   }
   
   public void ModifySurprise(float AmountToModifyBy)
   {
      ds_Service.GameManagerInGame.sceneDanceInformation.surprise =
         ds_Service.GameManagerInGame.sceneDanceInformation.surprise + AmountToModifyBy;
   }
   
   public void ModifyNervousness(float AmountToModifyBy)
   {
      ds_Service.GameManagerInGame.sceneDanceInformation.nervousness =
         ds_Service.GameManagerInGame.sceneDanceInformation.nervousness + AmountToModifyBy;
   }
   
   public void ModifyFrustration(float AmountToModifyBy)
   {
      ds_Service.GameManagerInGame.sceneDanceInformation.frustration =
         ds_Service.GameManagerInGame.sceneDanceInformation.frustration + AmountToModifyBy;
   }
   
   public void ModifyContempt(float AmountToModifyBy)
   {
      ds_Service.GameManagerInGame.sceneDanceInformation.frustration =
         ds_Service.GameManagerInGame.sceneDanceInformation.frustration + AmountToModifyBy;
   }
 
   public void ModifyWorry(float AmountToModifyBy)
   {
      ds_Service.GameManagerInGame.sceneDanceInformation.worry =
         ds_Service.GameManagerInGame.sceneDanceInformation.worry + AmountToModifyBy;
   }
   
   public void ModifyConfusion(float AmountToModifyBy)
   {
      ds_Service.GameManagerInGame.sceneDanceInformation.confusion =
         ds_Service.GameManagerInGame.sceneDanceInformation.confusion + AmountToModifyBy;
   }
}

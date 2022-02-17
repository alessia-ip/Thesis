using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic; //This allows the IComparable Interface

[CreateAssetMenu(fileName = "Action", menuName = "ScriptableObjects/Action")]
public class Action  : ScriptableObject
{
    public string name;
    public MoodEnums.TypesOfAction moodOfAction;
    /*public Action preferableCompatibleAction = new Action();
    public List<Action> compatibleWith = new List<Action>();*/
    public string WithOrAgainstBonus;
    public int preferedActionVibeAmount;
    public MoodEnums.MoodTypes preferedActionMoodOutcome;
    public int compatibleActionVibeAmount;
    public MoodEnums.MoodTypes compatibleActionMoodOutcome;
    public int otherActionVibeAmount;
    public MoodEnums.MoodTypes otherActionMoodOutcome;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Quest/Quest")]
public class QuestData : ScriptableObject
{
    public string questName => questName_;
    [SerializeField] string questName_;

    public string[] contents => contents_;
    [SerializeField] string[] contents_;

    public string[] AcceptContents => AcceptContents_;
    [SerializeField] string[] AcceptContents_;

    public string[] completeContents => completeContents_;
    [SerializeField] string[] completeContents_;


}

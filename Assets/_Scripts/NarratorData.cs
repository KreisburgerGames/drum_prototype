using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NarratorData", menuName = "MagicDrum/Narrator")]
public class NarratorData : ScriptableObject
{
    [SerializeReference, SubclassSelector]
    public INarratorAction[] actions;
}

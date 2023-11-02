using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Villager", menuName = "ScriptableObjects/Units/Villager", order = 4)]
public class Villager_SO : ScriptableObject
{
    public float constructionRange;
    public float ressourceRange;
    public float storageRange;
}

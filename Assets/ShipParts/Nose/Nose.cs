using UnityEngine;

[CreateAssetMenu(fileName = "Nose", menuName = "ScriptableObjects/Nose", order = 0)]
public class Nose : ScriptableObject
{
    [Header("Sprite")]
    public GameObject sprite;
    [Header("Classification")]
    public int partType;
    public int family;
    [Header("Stats")]
    public float hitPoints;
    public float thrust;
    public float turnSpeed;
    public float system;
    public float heatSink;
    public float damage;
 
}
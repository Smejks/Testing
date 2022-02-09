using UnityEngine;

[CreateAssetMenu(fileName = "Tail", menuName = "ScriptableObjects/Tail", order = 0)]
public class Tail : ScriptableObject
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
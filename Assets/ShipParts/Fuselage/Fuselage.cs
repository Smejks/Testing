using UnityEngine;

[CreateAssetMenu(fileName = "Fuselage", menuName = "ScriptableObjects/Fuselage", order = 0)]
public class Fuselage : ScriptableObject
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
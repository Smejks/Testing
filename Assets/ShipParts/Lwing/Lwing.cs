using UnityEngine;

[CreateAssetMenu(fileName = "Lwing", menuName = "ScriptableObjects/Lwing", order = 0)]
public class Lwing : ScriptableObject
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
using UnityEngine;

[CreateAssetMenu(fileName = "UnitAudioData", menuName = "Scriptable Objects/UnitAudioData")]
public class UnitAudioData : ScriptableObject
{
    [Range(0, 1)] public float volumeUnit = 1.0f;
    public AudioClip attack;
    public AudioClip death;
    public AudioClip specialAttack; 
    public AudioClip hit;
    public AudioClip spawn;
}

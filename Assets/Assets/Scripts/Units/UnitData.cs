using UnityEngine;

[CreateAssetMenu(fileName = "UnitData", menuName = "Scriptable Objects/UnitData")]
public class UnitData : ScriptableObject
{
    public string unitName = "";

    public string unitDescription = "";

    public UnitType unitType;
    public int cost = 0;
    public int dangerScore = 1;
    public Sprite unitIcon;
}

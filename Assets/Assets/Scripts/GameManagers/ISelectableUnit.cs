using UnityEngine;

public interface ISelectableUnit
{

    public void selectUnit(int unitIndex);

    event System.Action<int> OnUnitSelected;
}

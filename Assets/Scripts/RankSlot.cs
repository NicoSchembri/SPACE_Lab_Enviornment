using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class RankSlot : MonoBehaviour, IPointerClickHandler
{
    public TextMeshProUGUI itemName; 
    [HideInInspector] public NumberCube currentNumber;

    public void ClearSlot()
    {
        currentNumber = null;

        if (itemName != null)
            itemName.text = "";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SelectionManager.Instance.PlaceInSlot(this);
    }
}
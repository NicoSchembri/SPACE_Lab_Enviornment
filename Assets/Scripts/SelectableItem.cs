using UnityEngine;
using UnityEngine.EventSystems;

public class SelectableItem : MonoBehaviour, IPointerClickHandler
{
    public NumberCube linkedCube;

    void Start()
    {
        if (linkedCube == null)
            linkedCube = GetComponent<NumberCube>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SelectionManager.Instance.SelectCube(linkedCube);
    }
}
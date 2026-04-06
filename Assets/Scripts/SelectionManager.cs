using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager Instance;

    private NumberCube selectedCube;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void SelectCube(NumberCube cube)
    {
        // Deselect previous cube
        if (selectedCube != null && selectedCube != cube)
            selectedCube.SetHighlight(false);

        selectedCube = cube;

        if (selectedCube != null)
            selectedCube.SetHighlight(true);

        Debug.Log("Selected: " + cube.itemName.text);
    }

    public void PlaceInSlot(RankSlot slot)
    {
        if (selectedCube == null) return;

        if (selectedCube.currentSlot != null)
            selectedCube.currentSlot.ClearSlot();

        if (slot.currentNumber != null)
            slot.currentNumber.ReturnToOriginal();

        slot.currentNumber = selectedCube;
        selectedCube.currentSlot = slot;

        Transform attach = selectedCube.transform.Find("AttachPoint");
        if (attach != null)
            selectedCube.transform.position = slot.transform.position + attach.localPosition;
        else
            selectedCube.transform.position = slot.transform.position;

        selectedCube.transform.rotation = Quaternion.identity;

        if (slot.itemName != null)
            slot.itemName.text = selectedCube.itemName.text;

        selectedCube.SetHighlight(false);
        selectedCube = null;
    }
}
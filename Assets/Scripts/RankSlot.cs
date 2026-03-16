using UnityEngine;

public class RankSlot : MonoBehaviour
{
    public TMPro.TextMeshProUGUI itemName;
    [HideInInspector] public NumberCube currentNumber;

    private void OnTriggerEnter(Collider other)
    {
        NumberCube cube = other.GetComponent<NumberCube>();

        if (cube != null)
        {
            if (currentNumber != null)
            {
                currentNumber.ReturnToOriginal();
            }

            currentNumber = cube;
            cube.currentSlot = this;
            cube.transform.position = transform.position;
            cube.transform.rotation = Quaternion.identity;
        }
    }

    public void ClearSlot()
    {
        currentNumber = null;
    }
}
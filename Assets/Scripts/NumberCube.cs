using UnityEngine;
using TMPro;

public class NumberCube : MonoBehaviour
{
    public int numberValue;
    public TextMeshProUGUI numberText;

    [HideInInspector] public Vector3 originalPosition;
    [HideInInspector] public RankSlot currentSlot;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        originalPosition = transform.position;

        if (numberText != null)
            numberText.text = numberValue.ToString();
    }

    public void ReturnToOriginal()
    {
        if (currentSlot != null)
        {
            currentSlot.ClearSlot();
        }

        currentSlot = null;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = originalPosition;
    }
}
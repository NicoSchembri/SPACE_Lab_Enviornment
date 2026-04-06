using UnityEngine;
using TMPro;

public class NumberCube : MonoBehaviour
{
    [HideInInspector] public RankSlot currentSlot;
    [HideInInspector] public Vector3 originalPosition;

    private Rigidbody rb;

    public TextMeshProUGUI itemName;
    public GameObject highlight;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (originalPosition == Vector3.zero)
            originalPosition = transform.position;

        if (highlight != null)
            highlight.SetActive(false);
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
        transform.rotation = Quaternion.identity;

        SetHighlight(false);
    }

    public void SetHighlight(bool state)
    {
        if (highlight != null)
            highlight.SetActive(state);
    }
}
using UnityEngine;
using System.Collections.Generic;

public class RankingManager : MonoBehaviour
{
    public RankSlot[] allSlots;

    public Dictionary<string, int> GetCurrentRanking()
    {
        Dictionary<string, int> currentRanking = new Dictionary<string, int>();

        int maxSlots = Mathf.Min(5, allSlots.Length);

        for (int i = 0; i < maxSlots; i++)
        {
            var slot = allSlots[i];

            string name = slot.itemName.text;
            int value = slot.currentNumber != null ? slot.currentNumber.numberValue : 0;

            currentRanking[name] = value;
        }

        return currentRanking;
    }

    public void ResetBoard()
    {
        foreach (var slot in allSlots)
        {
            if (slot.currentNumber != null)
            {
                slot.currentNumber.ReturnToOriginal();
            }

            slot.ClearSlot();
        }
    }
}
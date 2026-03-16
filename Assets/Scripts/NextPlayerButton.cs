using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

public class NextPlayerButton : MonoBehaviour
{
    public RankingManager rankingManager;
    public TextMeshProUGUI playerTitleText;

    private int currentPlayerIndex = 0;

    private string[] playerTitles = new string[]
{
    "Player 1 Top 5",
    "Player 2 Top 5",
    "Player 3 Top 5",
    "Team Top 5",

    "Player 1 Bottom 5",
    "Player 2 Bottom 5",
    "Player 3 Bottom 5",
    "Team Bottom 5",

    "Player 1 Middle 5",
    "Player 2 Middle 5",
    "Player 3 Middle 5",
    "Team Middle 5"
};

    private List<Dictionary<string, int>> savedTurns = new List<Dictionary<string, int>>();

    private void Start()
    {
        playerTitleText.text = playerTitles[currentPlayerIndex];
    }

    public void OnNextButtonPressed()
    {
        Dictionary<string, int> currentData = rankingManager.GetCurrentRanking();
        savedTurns.Add(currentData);

        rankingManager.ResetBoard();

        currentPlayerIndex++;

        if (currentPlayerIndex < playerTitles.Length)
        {
            playerTitleText.text = playerTitles[currentPlayerIndex];
        }
        else
        {
            SaveAllTurns();
            GetComponent<Button>().interactable = false;
        }
    }

    private void SaveAllTurns()
    {
        string json = JsonUtility.ToJson(new SerializationWrapper(savedTurns), true);
        string path = Path.Combine(Application.persistentDataPath, "MoonSurvivalData.json");
        File.WriteAllText(path, json);
        Debug.Log("Saved all turn data to: " + path);
    }
}

[System.Serializable]
public class SerializationWrapper
{
    public List<DictionaryWrapper> list = new List<DictionaryWrapper>();

    public SerializationWrapper(List<Dictionary<string, int>> dictList)
    {
        foreach (var dict in dictList)
            list.Add(new DictionaryWrapper(dict));
    }
}

[System.Serializable]
public class DictionaryWrapper
{
    public string[] keys;
    public int[] values;

    public DictionaryWrapper(Dictionary<string, int> dict)
    {
        keys = new string[dict.Count];
        values = new int[dict.Count];
        int i = 0;

        foreach (var kv in dict)
        {
            keys[i] = kv.Key;
            values[i] = kv.Value;
            i++;
        }
    }
}
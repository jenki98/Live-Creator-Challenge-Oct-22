
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;

public class LeaderboardManager : MonoBehaviour
{
    public GameObject rowPrefab;
    public Transform rowsParent;
    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "InfiniteScrollerScore",
            StartPosition = 0,
            MaxResultsCount = 10

        };

        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    private void OnLeaderboardGet(GetLeaderboardResult result)
    {
        foreach(var item in result.Leaderboard)
        {
            GameObject newRow = Instantiate(rowPrefab, rowsParent);
            TextMeshProUGUI[] texts = newRow.GetComponentsInChildren<TextMeshProUGUI>();
            texts[0].text = item.Position.ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();
            Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
        }
    }

    void OnError(PlayFabError error)
    {
        Debug.Log("Error Logging in/Creating Account");
        Debug.Log(error.GenerateErrorReport());
    }
}
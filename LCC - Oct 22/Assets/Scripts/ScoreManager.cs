using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class ScoreManager : MonoBehaviour
{
   

    // Update is called once per frame
    
    public void SendLeaderboard()
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate{
                StatisticName = "InfiniteScrollerScore",
                Value = PlayerPrefs.GetInt("Score")
            }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    private void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successfull leaderboard sent");
    }
    void OnError(PlayFabError error)
    {
        Debug.Log("Error Logging in/Creating Account");
        Debug.Log(error.GenerateErrorReport());
    }
}

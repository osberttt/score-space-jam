using System.Collections;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class LootLockerManager : MonoBehaviour
{
    private string leaderboardKey = "doomsdaykickoff";


    private void Start()
    {
        StartCoroutine(LoginRoutine());
    }

    private IEnumerator LoginRoutine()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("Player was logged in");
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                done = true;
            }
            else
            {
                Debug.Log("Could not start session");
                done = true;
            }

        });
        yield return new WaitWhile(() => done == false);
    }

    public IEnumerator SubmitScoreRoutine(int scoreToUpload)
    {
        bool done = false;
        string playerID = PlayerPrefs.GetString("PlayerID");
        LootLockerSDKManager.SubmitScore(playerID, scoreToUpload, leaderboardKey, (response) =>
        { 
		    if (!response.success)
            {
                Debug.Log("Failed: " + response.errorData.ToString());
			}
            done = true;
            Debug.Log("Successfully uploaded score: " + scoreToUpload.ToString());
        });
        yield return new WaitWhile(() => done == false);
	}
}

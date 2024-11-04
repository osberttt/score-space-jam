using System.Collections;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class LootLockerManager : MonoBehaviour
{
    private string leaderboardKey = "doomsdaykickoff";
    public TMP_Text playerNames;
    public TMP_Text playerScores;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(FatchTopHighscoresRoutine());
        }
    }

    public void SetPlayerName()
    {
        LootLockerSDKManager.SetPlayerName("PlayerName", (response) => 
		{ 
		    if (response.success)
            {
                Debug.Log("Successfully set player name");
			}
            else 
			{ 
                Debug.Log("Could not set player name: " + response.errorData.ToString());
			}
		});	
	}

    public IEnumerator SubmitScoreRoutine(int scoreToUpload)
    {
        bool done = false;
        //string playerID = PlayerPrefs.GetString("PlayerID");
        LootLockerSDKManager.SubmitScore("", scoreToUpload, leaderboardKey, (response) =>
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

    public IEnumerator FatchTopHighscoresRoutine()
    {
        bool done = false;
        LootLockerSDKManager.GetScoreList(leaderboardKey, 10, 0, (response) =>
        { 
		    if (response.success)
            {
                string tempPlayerNames = "Names\n";
                string tempPlayerScores= "Scores\n";
                
                LootLockerLeaderboardMember[] members = response.items;

                for (int i=0; i<members.Length; i++)
                {
                    if (members[i].player.name != "")
                    {
                        tempPlayerNames += members[i].player.name;
					}
                    else
                    {
                        tempPlayerNames += members[i].player.id;
					}
                    tempPlayerScores += members[i].score + "\n";
                    tempPlayerNames += "\n"; 
                }
                playerNames.text = tempPlayerNames;
                playerScores.text = tempPlayerScores;
            }
            else 
			{
                Debug.Log("Failed:" + response.errorData.ToString());
			}
            done = true;
		});
        yield return new WaitWhile(() => done == false);
	}
}

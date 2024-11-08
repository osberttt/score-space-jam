using System.Collections;
using UnityEngine;
using LootLocker.Requests;
using TMPro;
using LootLocker;

public class LootLockerManager : MonoBehaviour
{
    private string leaderboardKey = "doomsdaykickoff";
    public TMP_Text playerNames;
    public TMP_Text playerScores;
    public WhiteLabelLogin login;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(FatchTopHighscoresRoutine());
        }
    }

    public void SetPlayerName()
    {
        LootLockerSDKManager.SetPlayerName(login.existingUserEmailInputField.text, (response) => 
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
                LootLockerLeaderboardMember[] members = response.items;

                for (int i=0; i<members.Length; i++)
                {
                    if (members[i].player.name != "")
                    {
                        playerNames.text += members[i].player.name + "\n";
					}
                    else
                    {
                        playerNames.text += members[i].player.id + "\n";
					}
                    playerScores.text += members[i].score + "\n";
                }
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

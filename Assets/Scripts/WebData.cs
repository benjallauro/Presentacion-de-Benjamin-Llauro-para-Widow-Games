using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using OVRSimpleJSON;
using System;

public class WebData : MonoBehaviour
{
    [SerializeField] private TournametDataPanelUI UIBoard;
    [SerializeField] private GameObject errorMessage;
    
    #region Unity methods
    private void Start()
    {
        StartCoroutine(ReceiveTournaments());
    }

    public void RequestTournaments()
    {
        StartCoroutine(ReceiveTournaments());
    }

    public IEnumerator ReceiveTournaments()
    {
        string myKey = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJqdGkiOiJjMjkzNWUzMC0zOTE5LTAxM2EtZGVkNS00NTZkNzI5YmRlMmUiLCJpc3MiOiJnYW1lbG9ja2VyIiwiaWF0IjoxNjM4ODMzMTQ1LCJwdWIiOiJibHVlaG9sZSIsInRpdGxlIjoicHViZyIsImFwcCI6ImJlbmphbWluLXMtcHJlIn0.A_osDMGur_mJmPKkC5-5rxVH3ZyKgSnAUAGIxSl7pjY";
        UnityWebRequest tournamentData = UnityWebRequest.Get("https://api.pubg.com/tournaments");
        tournamentData.SetRequestHeader("Authorization", "Bearer " + myKey);
        tournamentData.SetRequestHeader("Accept", "application/vnd.api+json");
        yield return tournamentData.SendWebRequest();
        if (!tournamentData.isNetworkError && !tournamentData.isHttpError)
            Debug.Log("Returns: " + tournamentData.downloadHandler.text);
        else
            Debug.Log("Request error: " + tournamentData.downloadHandler.text);
        try
        {
            JSONObject tournamentsJson = (JSONObject)JSON.Parse(tournamentData.downloadHandler.text);

            UIBoard.Populate(tournamentsJson);
        } catch (Exception exception)
        {
            Debug.Log("Error. Posible connection failure");
            errorMessage.SetActive(true);
        }

    }
    #endregion
}
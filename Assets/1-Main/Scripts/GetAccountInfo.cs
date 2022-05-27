using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetAccountInfo : MonoBehaviour
{
    [SerializeField] Text _displayName;

    private void Awake()
    {
        GetDisplayName();
    }

    public void GetDisplayName()
    {


        PlayFabClientAPI.GetPlayerProfile(new GetPlayerProfileRequest()
        {

            PlayFabId = RegisterAndLogin._playerID
        },
        Result =>
        {

            _displayName.text = Result.PlayerProfile.DisplayName;
            Debug.Log("Kullanici DisplayName Çekildi.");


        },
        Error =>
        {
            Debug.Log("Kullanici Verileri Çekilemedi!");
        });
    }
}

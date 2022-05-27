using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;
using System;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class RegisterAndLogin : MonoBehaviour
{
    [SerializeField] InputField _emailRegister, _passwordRegister, _usernameRegister, _repeatPasswordRegister;
    [SerializeField] InputField _passwordLogin, _usernameAndEmailLogin;
    [SerializeField] Text _resultText;
    [SerializeField] Button _loginButton, _registerButton;
    [Header("Guest Login Settings")]
    [SerializeField] bool _guestLoginActive;
    [SerializeField] GameObject _registerPanel, _loginPanel;
    [SerializeField] Animator _animator;
    
    public static string _playerID;

    private void Start()
    {
        SwitchLoginOrRegister();
        

    }
    public void LoginControls()
    {
        if (_passwordLogin.text.Length < 3)
        {
            _loginButton.interactable = false;

        }
        else
        {
            _loginButton.interactable = true;
        }

        _passwordLogin.text = Regex.Replace(_passwordLogin.text, "[ç, ý, ü, ð, ö, þ, Ý, Ð, Ü, Ö, Þ, Ç]", "");
    }

    public void RegisterControls()
    {
        if (_emailRegister.text.IndexOf('@') < 0 || _emailRegister.text.IndexOf('.') < 0 || _passwordRegister.text != _repeatPasswordRegister.text || _passwordRegister.text.Length < 3)
        {
            _registerButton.interactable = false;

        }
        else
        {
            _registerButton.interactable = true;
        }
        _usernameRegister.text = Regex.Replace(_usernameRegister.text, "[^\\w\\._]", "");
        _usernameRegister.text = Regex.Replace(_usernameRegister.text, "[ç, ý, ü, ð, ö, þ, Ý, Ð, Ü, Ö, Þ, Ç,.]", "");
        _passwordRegister.text = Regex.Replace(_passwordRegister.text, "[ç, ý, ü, ð, ö, þ, Ý, Ð, Ü, Ö, Þ, Ç]", "");
    }

    void LoginEmail()
    {
        PlayFabClientAPI.LoginWithEmailAddress(new LoginWithEmailAddressRequest() 
        { Email = _usernameAndEmailLogin.text, Password = _passwordLogin.text },
            Result => 
            {
                _playerID = Result.PlayFabId;
                Debug.Log("Giris Basarili"); SceneManager.LoadScene(1); 
            },
            Error => 
            { 
                Debug.Log("Giris Basarisiz!"); 
            });
    }

    public void LoginUsername()
    {
        PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest() { Username = _usernameAndEmailLogin.text, Password = _passwordLogin.text },
          Result =>
          {
              _playerID = Result.PlayFabId;
              Debug.Log("Giris Basarili");
              SceneManager.LoadScene(1);
          },
          Error =>
          {
              //_animator.Play("Fail");
          });
    }
    public void LoginOnClick()
    {
        if (_usernameAndEmailLogin.text.IndexOf('@') > 0)
            LoginEmail();
        else
            LoginUsername();
    }
    public void RegisterOnClick()
    {
        PlayFabClientAPI.RegisterPlayFabUser(new RegisterPlayFabUserRequest() 
         { Username = _usernameRegister.text, Email = _emailRegister.text, Password = _passwordRegister.text },
         Result => { /*_animator.Play("Success");*/Debug.Log("Giris Basarili"); },
         Error => { /*_animator.Play("Fail");*/Debug.Log("Giris Basarisiz"); });
    }


    public void PlayGuest()
    {
        PlayFabClientAPI.LoginWithAndroidDeviceID(new LoginWithAndroidDeviceIDRequest() { CreateAccount = _guestLoginActive, AndroidDeviceId = SystemInfo.deviceUniqueIdentifier },

         Result => 
         {
             /*_animator.Play("Success")*/
             GuestDisplayName();
             Debug.Log("Giris Basarili"); 
             
         },
         Error => 
         {
             /*_animator.Play("Fail")*/
             Debug.Log("Giris Basarisiz"); ;
         });
    }
    public void GuestDisplayName()
    {
        PlayFabClientAPI.UpdateUserTitleDisplayName(new UpdateUserTitleDisplayNameRequest()
        {
            DisplayName = "Guest" + UnityEngine.Random.Range(1, 1000).ToString()

        },
        Result =>
        {
            SceneManager.LoadScene(1);
        },
        Error =>
        {
            Debug.Log("Hatalý Giris");
        }); ;

    }
    public void SwitchLoginOrRegister()
    {
        switch (_registerPanel.activeInHierarchy)
        {
            case true:
                _loginPanel.SetActive(true);
                _registerPanel.SetActive(false);
                break;

            default:
                _loginPanel.SetActive(false);
                _registerPanel.SetActive(true);
                break;
        }
    }
}
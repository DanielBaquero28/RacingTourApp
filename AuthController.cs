using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;

public class AuthController : MonoBehaviour
{
    public Text NameInput;
    public Text EmailInput;
    public Text UsernameInput;
    public Text PasswordInput;

    public GameObject ErrorDisplay;

    public void Login()
    {
        FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(EmailInput.text, PasswordInput.text).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Firebase.FirebaseException exep = task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;
                GetErrorMessage((AuthError)exep.ErrorCode);
                return;
            }

            if (task.IsFaulted)
            {
                Firebase.FirebaseException exep = task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;
                GetErrorMessage((AuthError)exep.ErrorCode);

                return;
            }
            if (task.IsCompleted)
            {
                Firebase.Auth.FirebaseUser newUser = task.Result;
                Debug.LogFormat("User signed in successfully: {0} [{1}]", newUser.Email, newUser.UserId);
            }
        });
    }

    public void SignUpUser()
    {
        if (EmailInput.text.Equals("") || PasswordInput.text.Equals("") || NameInput.text.Equals("") || UsernameInput.text.Equals(""))
        {
            DisplayErrorMessage("PLEASE FILL OUT THE WHOLE SIGN UP FORM");

            return;
        }

        if (!(EmailInput.text.Contains("@")))
        {
            DisplayErrorMessage("PLEASE PROVIDE A VALID EMAIL");

            return;
        }

        FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(EmailInput.text, PasswordInput.text).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Firebase.FirebaseException exep = task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;
                GetErrorMessage((AuthError)exep.ErrorCode);

                return;
            }

            if (task.IsFaulted)
            {
                Firebase.FirebaseException exep = task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;
                GetErrorMessage((AuthError)exep.ErrorCode);

                return;
            }

            if (task.IsCompleted)
            {
                Firebase.Auth.FirebaseUser newUser = task.Result;
                print("User signed up successfully");
            }
        });
    }

    public void Logout()
    {
        if (FirebaseAuth.DefaultInstance.CurrentUser != null)
        {
            FirebaseAuth.DefaultInstance.SignOut();
        }
    }

    void GetErrorMessage(AuthError ErrorCode)
    {
        string msg = "";
        msg = ErrorCode.ToString();

        print(msg);
    }

    public void DisplayErrorMessage(string errMsg)
    {
        ErrorDisplay.SetActive(true);
        ErrorDisplay.GetComponent<Text>().text = "Error: " + errMsg;
    }

}

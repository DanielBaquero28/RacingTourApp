using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;

public class AuthController : MonoBehaviour
{
    public Text EmailInput;
    public Text PasswordInput;

    public static Text RetrieveEmail;

    public GameObject ErrorDisplay;
    private string ErrorMessage;
    private string msg;
    public GameObject SignUpSuccessful;
    public GameObject LoginSuccessful;

    public GameObject DoubleCheck;

    public static bool Flag = false;
    private int NumClick = 0;
    private int NumClickTwo = 0;

    public void Login()
    {
        //Flag = false;
        FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(EmailInput.text, PasswordInput.text).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Flag = true;
                Firebase.FirebaseException exep = task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;
                ErrorMessage = exep.ErrorCode + "";
                GetErrorMessage((AuthError)exep.ErrorCode);
                LoginSuccessful.SetActive(false);
                return;
            }

            if (task.IsFaulted)
            {
                Flag = true;
                Firebase.FirebaseException exep = task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;
                ErrorMessage = exep.ErrorCode + "";
                GetErrorMessage((AuthError)exep.ErrorCode);
                LoginSuccessful.SetActive(false);
                return;
            }
            if (task.IsCompleted)
            {
                Flag = false;
                Firebase.Auth.FirebaseUser newUser = task.Result;
                print(EmailInput + ": Signed in succesfully");
            }
        });

        if (Flag == true)
        {
            print(msg);
            DisplayError(msg);
            SignUpSuccessful.SetActive(false);
        }
        else
        {
            ErrorDisplay.SetActive(false);
            //SignUpSuccessful.SetActive(true);
        }
        if (NumClickTwo == 0)
        {
            DoubleCheck.SetActive(true);
        }

        if (NumClickTwo >= 1)
        {
            if (Flag == false)
            {
                LoginSuccessful.SetActive(true);
            }
            else
            {
                LoginSuccessful.SetActive(false);
            }
        }
        NumClickTwo += 1;
    }

    public void SignUpUser()
    {
        print("Numclick: " + NumClick);
        print("SignUpUser01: " + Flag);
        RetrieveEmail = EmailInput;
        if (EmailInput.text.Equals("") || PasswordInput.text.Equals(""))
        {
            ErrorDisplay.SetActive(true);
            ErrorDisplay.GetComponent<Text>().text = "PLEASE FILL OUT THE FORM";
            return;
        }
        FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(EmailInput.text, PasswordInput.text).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Flag = true;
                Firebase.FirebaseException exep = task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;
                ErrorMessage = exep.ErrorCode + "";
                GetErrorMessage((AuthError)exep.ErrorCode);
                SignUpSuccessful.SetActive(false);
                //DisplayError((AuthError)exep.ErrorCode);
                return;
            }

            if (task.IsFaulted)
            {
                Flag = true;
                Firebase.FirebaseException exep = task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;
                GetErrorMessage((AuthError)exep.ErrorCode);
                //DisplayError(exep.ErrorCode);
                SignUpSuccessful.SetActive(false);
                return;
            }
            //print("SignUpUserMiddle(After isFaulted): " + Flag);
            if (task.IsCompleted)
            {
                Flag = false;
                Firebase.Auth.FirebaseUser newUser = task.Result;
                //SignUpSuccessful.SetActive(true);
                print("User signed up successfully");
            }
        });
        if (Flag == true)
        {
            print(msg);
            DisplayError(msg);
            SignUpSuccessful.SetActive(false);
        }
        else
        {
            ErrorDisplay.SetActive(false);
            //SignUpSuccessful.SetActive(true);
        }
        if (NumClick == 0)
        {
            DoubleCheck.SetActive(true);
        }

        if (NumClick >= 1)
        {
            if (Flag == false)
            {
                SignUpSuccessful.SetActive(true);
            }
            else
            {
                SignUpSuccessful.SetActive(false);
            }
        }
        //print("SignUpUser02: " + Flag);
        NumClick += 1;
    }

    public void Logout()
    {
        if (FirebaseAuth.DefaultInstance.CurrentUser != null)
        {
            ErrorDisplay.GetComponent<Text>().text = "Logged out successfully";
	    ErrorDisplay.SetActive(true);
	    FirebaseAuth.DefaultInstance.SignOut();
            print("Logged out successfully");
        }
    }

    void GetErrorMessage(AuthError ErrorCode)
    {
        msg = ErrorCode.ToString();
        print(msg);
    }

    public void DisplayError(string errorCode)
    {
        ErrorDisplay.SetActive(true);
        ErrorDisplay.GetComponent<Text>().text = "" + errorCode;
    }
}

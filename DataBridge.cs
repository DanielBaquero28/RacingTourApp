using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

// In charge of managing the Database in Google Firebase
public class DataBridge : MonoBehaviour
{
    public Text NameInput, UsernameInput;

    private Player player;


    private string PlayerDataUrl = "https://racing-tour-app.firebaseio.com/";
    private DatabaseReference DataBaseRef;
    private Guid guid;
    private bool AuthErrorLocal;


    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(PlayerDataUrl);
        DataBaseRef = FirebaseDatabase.DefaultInstance.RootReference;
    }
    // Saves player's data
    public void SaveData()
    {
        HandleAuthError();
        if (NameInput.text.Equals("") && UsernameInput.text.Equals("") && AuthController.RetrieveEmail.text.Equals(""))
        {
            print("No data to store");
            return;
        }
         // Creating a Globally Unique ID
         guid = Guid.NewGuid();

        if (AuthErrorLocal == true)
        {
            //DataBaseRef.Child("User" + guid).removeValue();
        }
        else
        {
            // Created an instance
            player = new Player(guid, NameInput.text, AuthController.RetrieveEmail.text, UsernameInput.text, LapComplete.BestTime);
            // Storing the object as a json
            string JsonData = JsonUtility.ToJson(player);
            // Adding the data to the database by creating a child
            DataBaseRef.Child("User" + guid).SetRawJsonValueAsync(JsonData);
        }
    }

    // Loads player's data
    public void LoadData()
    {
        FirebaseDatabase.DefaultInstance.GetReferenceFromUrl(PlayerDataUrl).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Firebase.FirebaseException exep = task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;
                GetErrorMessage(exep.ErrorCode);
                return;
            }

            if (task.IsFaulted)
            {
                Firebase.FirebaseException exep = task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;
                GetErrorMessage(exep.ErrorCode);
                return;
            }

            if (task.IsCompleted)
            {
                // DataSnapshot is an object that stores all of the player's data
                DataSnapshot SnapshotData = task.Result;

                string PlayerData = SnapshotData.GetRawJsonValue();
                print(PlayerData);

                foreach(var child in SnapshotData.Children)
                {
                    string childData = child.GetRawJsonValue();
                    Player eachField = JsonUtility.FromJson<Player>(childData);

                    //Ready to retrieve any of it's childs easily

                    //print("The Player's id is: " + eachField.Id);
                    //print("The Player's name is : " + eachField.Name);
                    //print("The Player's email is: " + eachField.Email);
                    //print("The Player's username is: " + eachField.Username);
                    //print("The Player's password is: " + eachField.Password);
                }
            }
        });
    }

    public void HandleAuthError()
    {
        List<string> myList;
        FirebaseDatabase.DefaultInstance.GetReferenceFromUrl(PlayerDataUrl).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Firebase.FirebaseException exep = task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;
                GetErrorMessage(exep.ErrorCode);
                return;
            }

            if (task.IsFaulted)
            {
                Firebase.FirebaseException exep = task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;
                GetErrorMessage(exep.ErrorCode);
                return;
            }
            
           
                // DataSnapshot is an object that stores all of the player's data
                DataSnapshot SnapshotData = task.Result;

                string PlayerData = SnapshotData.GetRawJsonValue();
                print(PlayerData);

                myList = new List<string>();

                foreach (var child in SnapshotData.Children)
                {
                    string childData = child.GetRawJsonValue();
                    Player eachField = JsonUtility.FromJson<Player>(childData);

                    if (eachField.Email != "")
                    {
                        myList.Add(eachField.Email);
                    }

                    foreach(string s in myList)
                    {
                        AuthErrorLocal = false;
                        Console.WriteLine(s);
                        if (s == eachField.Email)
                        {
                            AuthErrorLocal = true;
                            // break;
                        }
                        else
                        {
                            AuthErrorLocal = false;
                        }
                    }
                }

                
            
        });
    }

    // This method is in beta and will be used to save the user's best time
    /* public void SaveBestTime()
    {
        FirebaseDatabase.DefaultInstance.GetReferenceFromUrl(PlayerDataUrl).GetValueAsync().ContinueWith(task =>
        {
        if (task.IsCanceled)
        {
            Firebase.FirebaseException exep = task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;
            GetErrorMessage(exep.ErrorCode);
            return;
        }

        if (task.IsFaulted)
        {
            Firebase.FirebaseException exep = task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;
            GetErrorMessage(exep.ErrorCode);
            return;
        }


        // DataSnapshot is an object that stores all of the player's data
        DataSnapshot SnapshotData = task.Result;

        string PlayerData = SnapshotData.GetRawJsonValue();
        print(PlayerData);


        foreach (var child in SnapshotData.Children)
        {
            string childData = child.GetRawJsonValue();
            Player eachField = JsonUtility.FromJson<Player>(childData);

            DatabaseReference DataBaseBest;
            string EmailKey = "";

            if (eachField.Email == AuthController.RetrieveEmail.ToString())
            {
                   DataBaseBest.getParent();
                   

                    EmailKey = DataBaseBest.getKey();

                    DataBaseBest = DataBaseRef.Child(EmailKey);
                    DataBaseBest.Child("Email").SetValue(LapComplete.BestTime);
                }
            }



        });
    } */

    void GetErrorMessage(int ErrorCode)
    {
        switch (ErrorCode)
        {
            case (-1):
                print("Internal use");
                break;

            case (-4):
                print("The operation had to be aborted due to a network disconnect");
                break;

            case (-6):
                print("The supplied auth token has expired");
                break;

            case (-7):
                print("The specified authentication token is invalid.");
                break;

            case (-8):
                print("The transaction had too many retries");
                break;
            case (-24):
                print("The operation could not be performed due to a network error.");
                break;

            case (-2):
                print("The server indicated that this operation failed");
                break;

            case (-9):
                print("The transaction was overridden by a subsequent set");
                break;

            case (-3):
                print("This client does not have permission to perform this operation");
                break;

            case (-10):
                print("The service is unavailable");
                break;

            case (-999):
                print("An unknown error occurred.");
                break;

            case (-11):
                print("An exception occurred in user code");
                break;

            case (-25):
                print("The write was canceled locally");
                break;
        }
    }
}

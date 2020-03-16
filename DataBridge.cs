using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class DataBridge : MonoBehaviour
{
    public Text NameInput, EmailInput, UsernameInput, PasswordInput;

    private Player player;

    
    private string PlayerDataUrl = "https://racing-tour-app.firebaseio.com/";
    private DatabaseReference DataBaseRef;

    private int id = 0;

    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(PlayerDataUrl);
        DataBaseRef = FirebaseDatabase.DefaultInstance.RootReference;
    }
    // Saves player's data
    public void SaveData()
    {
        if (UsernameInput.text.Equals("") && EmailInput.text.Equals("") && NameInput.text.Equals("") && PasswordInput.text.Equals(""))
        {
            print("No data found");
            return;
        }
        // Created an instance
        player = new Player(id, NameInput.text, EmailInput.text, UsernameInput.text, PasswordInput.text);
        // Storing the object as a json
        string JsonData = JsonUtility.ToJson(player);

        // Creating a unique id for each user and storing it as a raw json
        DataBaseRef.Child("User" + id).SetRawJsonValueAsync(JsonData);
        id += 1;
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

                    // Ready to retrieve any of it's childs easily

                    /* print("The Player's id is: " + eachField.Id);
                    print("The Player's name is : " + eachField.Name);
                    print("The Player's email is: " + eachField.Email);
                    print("The Player's username is: " + eachField.Username);
                    print("The Player's password is: " + eachField.Password); */
                }
            }
        });
    }

    void GetErrorMessage(int ErrorCode)
    {
        int errorCode;
        errorCode = ErrorCode;

        switch (errorCode)
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

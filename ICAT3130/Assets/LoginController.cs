using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.UI;

public class LoginController : MonoBehaviour
{
    //These objects are needed throughout the object code
    public Firebase.FirebaseApp app;
    public Firebase.Auth.FirebaseAuth auth;
    Firebase.Auth.FirebaseUser user;

    // Ienumerators are asynchronous tasks with an option to wait until something(such as a timer) is complete.They are fired with StartCoroutine(INSERT_IENUMERATOR_NAME());

    public string email;
    public string password;
    public GameObject inputfieldEmail;
    public GameObject inputfieldPassword;
    public UnityEngine.Events.UnityEvent LoggedIn;

    public void StoreInformation()
    {
        email = inputfieldEmail.GetComponent<InputField>().text;
        password = inputfieldPassword.GetComponent<InputField>().text;
    }



    void Start()
    {

        StartCoroutine(CheckDependencies());

    }



    IEnumerator CheckDependencies()

    {

        var checkTask = Firebase.FirebaseApp.CheckAndFixDependenciesAsync();

        yield return new WaitUntil(() => checkTask.IsCompleted);

        if (checkTask.Result == Firebase.DependencyStatus.Available)

        {

            app = Firebase.FirebaseApp.Create();

            FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://mobileproject-25450.firebaseio.com/");

            InitializeFirebase();
        }
        else
        {
            Debug.LogError("Could not resolve all Firebase dependencies");
        }
    }

    //Initialization script:

    void InitializeFirebase()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }



    //The event listener for authorization state changes:

    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != user)
        {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && user != null)
            {

                //USER IS NOT SIGNED IN

            }

            user = auth.CurrentUser;

            if (user != null)

            {

                //USER IS SIGNED IN AND EXISTS IN DATABASE

            }

        }

        if (user == null)

        {

            //USER IS SIGNED IN BUT DOES NOT EXIST IN DATABASE

        }

    }



    //Login and signup operations:

 public void attemptLogin()
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))

            return;

        StartCoroutine(loginProcess());

    }

    IEnumerator loginProcess()

    {

        var loginTask = auth.SignInWithEmailAndPasswordAsync(email, password);

        yield return new WaitUntil(() => loginTask.IsCompleted);


        if (loginTask.IsCanceled)

        {

            //USER HAS CANCELED LOGIN

        }

        else if (loginTask.IsFaulted)

        {

            //SOME ERROR HAS HAPPENED

            Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + loginTask.Exception);

        }
        else
        {
            LoggedIn.Invoke();
        }
      

    }

    public void attemptSignup()

    {

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))

            return;

        StartCoroutine(signupProcess());

    }

    IEnumerator signupProcess()
    {

        var signupTask = auth.CreateUserWithEmailAndPasswordAsync(email, password);

        yield return new WaitUntil(() => signupTask.IsCompleted);

        if (signupTask.IsCanceled)

        {

            Debug.LogError("canceled");

        }

        else if (signupTask.IsFaulted)

        {

            Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + signupTask.Exception);

        }
        else
        {
            LoggedIn.Invoke();
        }
    }
}
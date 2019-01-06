using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class shareScreenshot : MonoBehaviour
{



  




    /*Share functionalties trial*/

   public  void takeScreenShotAndShare()
    {
        StartCoroutine(takeScreenshotAndSave());
    }

    private IEnumerator takeScreenshotAndSave()
    {
        string path = "";
        yield return new WaitForEndOfFrame();

        Texture2D screenImage = new Texture2D(Screen.width, Screen.height);

        //Get Image from screen
        screenImage.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenImage.Apply();

        //Convert to png
        byte[] imageBytes = screenImage.EncodeToPNG();


        System.IO.Directory.CreateDirectory(Application.persistentDataPath + "/GameOverScreenShot");
        path = Application.persistentDataPath + "/GameOverScreenShot" + "/DiedScreenShot.png";
        System.IO.File.WriteAllBytes(path, imageBytes);

        StartCoroutine(shareScreenshot(path));
    }

    private IEnumerator shareScreenshot(string destination)
    {
        string ShareSubject = "Picture Share";
        string shareLink = "Test Link" + "\nhttp://stackoverflow.com/questions/36512784/share-image-on-android-application-from-unity-game";
        string textToShare = "Text To share";

        Debug.Log(destination);


        if (!Application.isEditor)
        {

            AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
            AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
            intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
            AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
            AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "file://" + destination);

            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), textToShare + shareLink);
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), ShareSubject);
            intentObject.Call<AndroidJavaObject>("setType", "image/png");
            AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
            currentActivity.Call("startActivity", intentObject);
        }
        yield return null;
    }


}

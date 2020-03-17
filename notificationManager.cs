using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class notificationManager : MonoBehaviour
{

    private void Start()
    {
        createNotificationnChannelll();
        sendNotification();
    }

    void createNotificationnChannelll()
    {
        var c = new AndroidNotificationChannel()
        {
            Id = "notif1",
            Name = "Default Channel",
            Importance = Importance.High,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(c);
    }
  

      void sendNotification()
    {
        var notification = new AndroidNotification();
        notification.Title = "Goddess is in BattleGround";
        notification.Text = "Play Now...";
        // notification.FireTime = System.DateTime.Now.AddHours(24);
         notification.FireTime = System.DateTime.Now.AddSeconds(5);

        AndroidNotificationCenter.SendNotification(notification, "notif1");
    }
    //////now ALL YOU NEED TO IS ADD ICONS AND SCHEDULE IT FOR 6HRS OR MAYBE 12....THESE ARE REPEATIVE NOTIFICATIONS...
    /////THAT WILL BE SCHEDULED ON START OF THIS.


    //https://www.youtube.com/watch?v=qhC6OZPgd5Q

}

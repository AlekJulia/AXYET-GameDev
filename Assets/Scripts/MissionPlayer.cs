using UnityEngine;
using System.Collections;

public class MissionPlayer : MonoBehaviour
{
    public bool quest; //  отображает название квеста на экране;
    public string MissionText; // название квеста;
    public string ObjectCollected; //надпись что объект собран
    public string ObjectTag; // тэг объекта;
    public bool MissionObjects; //отображает собран предмет или нет;
    public int Money; // количество денег;

    void OnGUI()
    {
        if (quest)
        {
            GUI.Label(new Rect(20, 80, 300, 30), "" + MissionText + ObjectCollected); // значение названия квеста будет браться из скрипта Misson Bot;
            if (MissionObjects)
            { // если предмет собран;
                ObjectCollected = " [Предмет собран]";
            }
        } // выводит надпись;
                GUI.Label(new Rect(20, 100, 100, 30), "Деньги: " + Money);
            }
        }
    
// отображает количество денег на экране;
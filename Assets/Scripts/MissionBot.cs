using UnityEngine;
using System.Collections;

public class MissionBot : MonoBehaviour
{
    public bool trigger = false;
    public bool quest; //переменная, которая обозначает взят квест или нет
    public bool vis; // переменная, которая будет отображать диалог между персонажами
    public bool MissionDone = false; //переменная, которая определеяет, что квест уже сделан
    public string MissionName; // Текст который будет отображать наименование квеста
    public string MissionDialoge; // Текст диалога в квесте
    public string MissionDialogeDone; // Текст диалога в квесте
    public string MissionObjectName;
    private MissionPlayer MP; // подключаем скрипт MissionPlayer
    private Inventory Inv;

    void Start()
    {
        MP = GameObject.FindGameObjectWithTag("Player").GetComponent<MissionPlayer>(); // определяем что скрипт MissionPlayer будет находится на персонаже с тэгом player;
        Inv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    void OnTriggerStay2D(Collider2D obj) //игрок рядом с НПС
    {
        if (obj.tag == "Player")
        {
            trigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D obj) //игрок отошел от НПС
    {
        if (obj.tag == "Player")
        {
            trigger = false;
        }
    }

    void Update()
    {
        GameObject MissionTagScanner = GameObject.FindGameObjectWithTag("Player"); // персонаж у которого берем квест будет взаимодействовать только с тем объектом у которого тэг Player;

        if (Input.GetKeyDown(KeyCode.E) && trigger == true) // При нажатии на клавишу Е и если игрок рядом с НПС
        {
            vis = true;
        }
    }

    void OnGUI()
    {
        if (vis)
        {
            if (!quest && !MissionDone) //если квест еще не взят и не выполнен;
            {
                GUI.Box(new Rect((Screen.width - 300) / 2, (Screen.height - 300) / 2, 300, 300), MissionName); //на экране отображается окно с названием Квест;
                GUI.Label(new Rect((Screen.width - 300) / 2 + 10, (Screen.height - 300) / 2 + 20, 290, 250), MissionDialoge); //текстом описывает квест;
                if (GUI.Button(new Rect((Screen.width - 100) / 2 - 25, (Screen.height - 300) / 2 + 250, 150, 40), "Принять квест")) // при нажатии на кнопку Ok;
                {
                    quest = true; // квест взят;
                    MP.quest = true; // отображает название квеста на экране;
                    MP.MissionText = MissionName; // название квеста;
                    MP.MissionObjectName = MissionObjectName;
                    vis = false; // все диалоговые окна закрываются;
                }
            }

            if (quest && !MissionDone)
            { // если квест уже взят;
                GUI.Box(new Rect((Screen.width - 300) / 2, (Screen.height - 300) / 2, 300, 300), MissionName);
                GUI.Label(new Rect((Screen.width - 300) / 2 + 10, (Screen.height - 300) / 2 + 20, 290, 250), MissionDialogeDone); //то описание квеста меняется на другой текст;
                //if (MP.MissionObjects) // если вы уже подобрали объект;
                if (Inv.InventoryObjects.Contains(MissionObjectName))
                {
                    if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 300) / 2 + 250, 100, 40), "Да")) // то появится кнопка да, при нажатии на которую;
                    {
                        Inv.InventoryObjects.Remove(MissionObjectName);
                        quest = false; // переменная квест принимает значение false, т.е. не взят ;
                        MP.quest = false; // название квеста не будет отображаться на экране ;
                        MP.MissionText = ""; // убирается название квеста;
                        MP.MissionObjectName = "";
                        MP.MissionObjects = false; // объект считается не подобранным;
                        MP.Money = MP.Money + 100; //добавление денег за выполнение квеста;
                        vis = false; // диалоговое окно закрывается;
                        MissionDone = true;
                    }
                }

                else
                { // если вы еще не подобрали объект;
                    if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 300) / 2 + 250, 100, 40), "Нет")) // то вместо кнопки да, будет кнопка нет;
                    {
                        vis = false; // при нажатии на которую, окно просто закроется;
                    }
                }
            }
        }
    }
}
   
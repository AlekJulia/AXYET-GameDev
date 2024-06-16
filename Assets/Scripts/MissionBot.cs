using UnityEngine;
using System.Collections;

public class MissionBot : MonoBehaviour
{
    public bool trigger = false;
    public bool quest; //переменная, которая обозначает взят квест или нет
    public bool vis; // переменная, которая будет отображать диалог между персонажами
    public bool MissionDone = false; //переменная, которая определеяет, что квест уже сделан
    public string missionText; // Текст который будет отображать наименование квеста
    public string missionTag; //Тэг объекта, который необходимо принести
    private MissionPlayer MP; // подключаем скрипт MissionPlayer

    void Start()
    {
        MP = GameObject.FindGameObjectWithTag("Player").GetComponent<MissionPlayer>(); // определяем что скрипт MissionPlayer будет находится на персонаже с тэгом player;
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
                GUI.Box(new Rect((Screen.width - 300) / 2, (Screen.height - 300) / 2, 300, 300), "Найти Лунную Лилию"); //на экране отображается окно с названием Квест;
                GUI.Label(new Rect((Screen.width - 300) / 2 + 10, (Screen.height - 300) / 2 + 20, 290, 250), "Здравствуй, путник! Сегодня такая прекрасная ночь... Мне как раз нужна Лунная Лилия, которая растет на горе, прямо под лунным светом. Не мог бы ты сорвать и принести для меня одну?"); //текстом описывает квест;
                if (GUI.Button(new Rect((Screen.width - 100) / 2 - 25, (Screen.height - 300) / 2 + 250, 150, 40), "Принять квест")) // при нажатии на кнопку Ok;
                {
                    quest = true; // квест взят;
                    MP.quest = true; // отображает название квеста на экране;
                    MP.MissionText = "Найти Лунную Лилию"; // текст квеста;
                    MP.ObjectTag = missionTag; // тэг объекта который необходимо принести;
                    vis = false; // все диалоговые окна закрываются;
                }
            }

            else
            { // если квест уже взят;
                GUI.Box(new Rect((Screen.width - 300) / 2, (Screen.height - 300) / 2, 300, 300), "Найти Лунную Лилию");
                GUI.Label(new Rect((Screen.width - 300) / 2 + 10, (Screen.height - 300) / 2 + 20, 290, 250), "Ты уже нашел Лунную Лилию?"); //то описание квеста меняется на другой текст;
                if (MP.MissionObjects) // если вы уже подобрали объект;
                {
                    if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 300) / 2 + 250, 100, 40), "Да")) // то появится кнопка да, при нажатии на которую;
                    {
                        quest = false; // переменная квест принимает значение false, т.е. не взят ;
                        MP.quest = false; // название квеста не будет отображаться на экране ;
                        MP.MissionText = ""; // убирается название квеста;
                        MP.ObjectTag = ""; // обнуляется тэг объекта;
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
   
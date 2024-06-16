using UnityEngine;
using System.Collections;
public class MissionObject : MonoBehaviour

{
    private MissionPlayer MP; // подключаем скрипт MissionPlayer;
    public bool trigger = false;

    void Start() {
        MP = GameObject.FindGameObjectWithTag("Player").GetComponent<MissionPlayer>();// определяем что скрипт MissionPlayer будет находится на персонаже с тэгом player;
    }

    void OnTriggerStay2D(Collider2D obj) //«Наезд» на объект
    {
        if (obj.tag == "Player")
        {
            trigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D obj) //анти наезд на объект
    {
        if (obj.tag == "Player")
        {
            trigger = false;
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.E) && trigger == true) // если игрок рядом с объектом и нажал Е
        {
            if (MP.ObjectTag == gameObject.tag) // и при том что тэг объекта равен тому значению которое написано в ObjectTag;
            {
                MP.MissionObjects = true; // то переменная принимает значение true, т.е. считается что предмет собран;
                Destroy(gameObject); // и удаляем этот объект со сцены;
             }
        }
    }

    void OnGUI() //кнопка собрать
    {
        if (trigger && MP.quest) //игрок наступил на объект + у него есть квест
        {
            GUI.Box(new Rect(Screen.width / 2 + 20, Screen.height / 2 + 40, 90, 25), "[E] Собрать");
        }
    }
}

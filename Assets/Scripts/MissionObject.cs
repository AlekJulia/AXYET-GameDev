using UnityEngine;
using System.Collections;
public class MissionObject : MonoBehaviour

{
    private MissionPlayer MP; // подключаем скрипт MissionPlayer;
    public bool trigger = false;
    public string ObjectName;
    private Inventory Inv;
    public bool IsObjectCollected; //выводит уведомление о собраном предмете

    void Start() {
        MP = GameObject.FindGameObjectWithTag("Player").GetComponent<MissionPlayer>();// определяем что скрипт MissionPlayer будет находится на персонаже с тэгом player;
        Inv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
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
            IsObjectCollected = true;

            Inv.Icon[Inv.i].sprite = Inv.Sprites[5];
            Inv.InventoryObjects.Add(ObjectName);
            Inv.i++;

            Destroy(gameObject); // и удаляем этот объект со сцены;
        }
    }

    void OnGUI() //кнопка собрать
    {
        if (trigger) //игрок наступил на объект
        {
            GUI.Box(new Rect(Screen.width / 2 + 20, Screen.height / 2 + 40, 90, 25), "[E] Собрать");
        }

        if (IsObjectCollected)
        {
            GUI.Label(new Rect(5, Screen.height - 25, 400, 25), "Получено [" + ObjectName + "]");
        }
    }
}

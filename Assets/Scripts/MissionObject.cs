using UnityEngine;
using System.Collections;
public class MissionObject : MonoBehaviour

{
    private MissionPlayer MP; // ���������� ������ MissionPlayer;
    public bool trigger = false;
    public string ObjectName;
    private Inventory Inv;
    public bool IsObjectCollected; //������� ����������� � �������� ��������

    void Start() {
        MP = GameObject.FindGameObjectWithTag("Player").GetComponent<MissionPlayer>();// ���������� ��� ������ MissionPlayer ����� ��������� �� ��������� � ����� player;
        Inv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    void OnTriggerStay2D(Collider2D obj) //������ �� ������
    {
        if (obj.tag == "Player")
        {
            trigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D obj) //���� ����� �� ������
    {
        if (obj.tag == "Player")
        {
            trigger = false;
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.E) && trigger == true) // ���� ����� ����� � �������� � ����� �
        {
            IsObjectCollected = true;

            Inv.Icon[Inv.i].sprite = Inv.Sprites[5];
            Inv.InventoryObjects.Add(ObjectName);
            Inv.i++;

            Destroy(gameObject); // � ������� ���� ������ �� �����;
        }
    }

    void OnGUI() //������ �������
    {
        if (trigger) //����� �������� �� ������
        {
            GUI.Box(new Rect(Screen.width / 2 + 20, Screen.height / 2 + 40, 90, 25), "[E] �������");
        }

        if (IsObjectCollected)
        {
            GUI.Label(new Rect(5, Screen.height - 25, 400, 25), "�������� [" + ObjectName + "]");
        }
    }
}

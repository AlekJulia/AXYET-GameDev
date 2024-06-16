using UnityEngine;
using System.Collections;
public class MissionObject : MonoBehaviour

{
    private MissionPlayer MP; // ���������� ������ MissionPlayer;
    public bool trigger = false;

    void Start() {
        MP = GameObject.FindGameObjectWithTag("Player").GetComponent<MissionPlayer>();// ���������� ��� ������ MissionPlayer ����� ��������� �� ��������� � ����� player;
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
            if (MP.ObjectTag == gameObject.tag) // � ��� ��� ��� ��� ������� ����� ���� �������� ������� �������� � ObjectTag;
            {
                MP.MissionObjects = true; // �� ���������� ��������� �������� true, �.�. ��������� ��� ������� ������;
                Destroy(gameObject); // � ������� ���� ������ �� �����;
             }
        }
    }

    void OnGUI() //������ �������
    {
        if (trigger && MP.quest) //����� �������� �� ������ + � ���� ���� �����
        {
            GUI.Box(new Rect(Screen.width / 2 + 20, Screen.height / 2 + 40, 90, 25), "[E] �������");
        }
    }
}

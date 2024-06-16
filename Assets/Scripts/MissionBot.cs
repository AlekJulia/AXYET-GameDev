using UnityEngine;
using System.Collections;

public class MissionBot : MonoBehaviour
{
    public bool trigger = false;
    public bool quest; //����������, ������� ���������� ���� ����� ��� ���
    public bool vis; // ����������, ������� ����� ���������� ������ ����� �����������
    public bool MissionDone = false; //����������, ������� �����������, ��� ����� ��� ������
    public string missionText; // ����� ������� ����� ���������� ������������ ������
    public string missionTag; //��� �������, ������� ���������� ��������
    private MissionPlayer MP; // ���������� ������ MissionPlayer

    void Start()
    {
        MP = GameObject.FindGameObjectWithTag("Player").GetComponent<MissionPlayer>(); // ���������� ��� ������ MissionPlayer ����� ��������� �� ��������� � ����� player;
    }

    void OnTriggerStay2D(Collider2D obj) //����� ����� � ���
    {
        if (obj.tag == "Player")
        {
            trigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D obj) //����� ������ �� ���
    {
        if (obj.tag == "Player")
        {
            trigger = false;
        }
    }

    void Update()
    {
        GameObject MissionTagScanner = GameObject.FindGameObjectWithTag("Player"); // �������� � �������� ����� ����� ����� ����������������� ������ � ��� �������� � �������� ��� Player;
        if (Input.GetKeyDown(KeyCode.E) && trigger == true) // ��� ������� �� ������� � � ���� ����� ����� � ���
        {
            vis = true;
        }
    }

    void OnGUI()
    {
        if (vis)
        {
            if (!quest && !MissionDone) //���� ����� ��� �� ���� � �� ��������;
            {
                GUI.Box(new Rect((Screen.width - 300) / 2, (Screen.height - 300) / 2, 300, 300), "����� ������ �����"); //�� ������ ������������ ���� � ��������� �����;
                GUI.Label(new Rect((Screen.width - 300) / 2 + 10, (Screen.height - 300) / 2 + 20, 290, 250), "����������, ������! ������� ����� ���������� ����... ��� ��� ��� ����� ������ �����, ������� ������ �� ����, ����� ��� ������ ������. �� ��� �� �� ������� � �������� ��� ���� ����?"); //������� ��������� �����;
                if (GUI.Button(new Rect((Screen.width - 100) / 2 - 25, (Screen.height - 300) / 2 + 250, 150, 40), "������� �����")) // ��� ������� �� ������ Ok;
                {
                    quest = true; // ����� ����;
                    MP.quest = true; // ���������� �������� ������ �� ������;
                    MP.MissionText = "����� ������ �����"; // ����� ������;
                    MP.ObjectTag = missionTag; // ��� ������� ������� ���������� ��������;
                    vis = false; // ��� ���������� ���� �����������;
                }
            }

            else
            { // ���� ����� ��� ����;
                GUI.Box(new Rect((Screen.width - 300) / 2, (Screen.height - 300) / 2, 300, 300), "����� ������ �����");
                GUI.Label(new Rect((Screen.width - 300) / 2 + 10, (Screen.height - 300) / 2 + 20, 290, 250), "�� ��� ����� ������ �����?"); //�� �������� ������ �������� �� ������ �����;
                if (MP.MissionObjects) // ���� �� ��� ��������� ������;
                {
                    if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 300) / 2 + 250, 100, 40), "��")) // �� �������� ������ ��, ��� ������� �� �������;
                    {
                        quest = false; // ���������� ����� ��������� �������� false, �.�. �� ���� ;
                        MP.quest = false; // �������� ������ �� ����� ������������ �� ������ ;
                        MP.MissionText = ""; // ��������� �������� ������;
                        MP.ObjectTag = ""; // ���������� ��� �������;
                        MP.MissionObjects = false; // ������ ��������� �� �����������;
                        MP.Money = MP.Money + 100; //���������� ����� �� ���������� ������;
                        vis = false; // ���������� ���� �����������;
                        MissionDone = true;
                    }
                }

                else
                { // ���� �� ��� �� ��������� ������;
                    if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 300) / 2 + 250, 100, 40), "���")) // �� ������ ������ ��, ����� ������ ���;
                    {
                        vis = false; // ��� ������� �� �������, ���� ������ ���������;
                    }
                }
            }
        }
    }
}
   
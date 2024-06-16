using UnityEngine;
using System.Collections;

public class MissionPlayer : MonoBehaviour
{
    public bool quest; //  ���������� �������� ������ �� ������;
    public string MissionText; // �������� ������;
    public string ObjectCollected; //������� ��� ������ ������
    //public string ObjectTag; // ��� �������;
    public bool MissionObjects; //���������� ������ ������� ��� ���;
    public int Money; // ���������� �����;
    public string MissionObjectName;
    private MissionObject MO;
    private Inventory Inv;

    void OnTriggerEnter2D(Collider2D obj) //�������� ��������������� � ��������
    {
        MO = obj.GetComponent<MissionObject>();//�������� ���� �� �������, �� ������� ���������
        Inv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    void OnGUI()
    {
        if (quest)
        {
            GUI.Label(new Rect(20, 80, 300, 30), "" + MissionText + ObjectCollected); // �������� �������� ������ ����� ������� �� ������� Misson Bot;
        }
        GUI.Label(new Rect(20, 100, 100, 30), "������: " + Money);
    }
}
    
// ���������� ���������� ����� �� ������;
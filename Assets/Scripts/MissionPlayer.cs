using UnityEngine;
using System.Collections;

public class MissionPlayer : MonoBehaviour
{
    public bool quest; //  ���������� �������� ������ �� ������;
    public string MissionText; // �������� ������;
    public string ObjectCollected; //������� ��� ������ ������
    public string ObjectTag; // ��� �������;
    public bool MissionObjects; //���������� ������ ������� ��� ���;
    public int Money; // ���������� �����;

    void OnGUI()
    {
        if (quest)
        {
            GUI.Label(new Rect(20, 80, 300, 30), "" + MissionText + ObjectCollected); // �������� �������� ������ ����� ������� �� ������� Misson Bot;
            if (MissionObjects)
            { // ���� ������� ������;
                ObjectCollected = " [������� ������]";
            }
        } // ������� �������;
                GUI.Label(new Rect(20, 100, 100, 30), "������: " + Money);
            }
        }
    
// ���������� ���������� ����� �� ������;
using UnityEngine;
using System.Collections;

public class MissionPlayer : MonoBehaviour
{
    public bool quest; //  ���������� �������� ������ �� ������;
    public string MissionText; // �������� ������;
    public string ObjectTag; // ��� �������;
    public bool MissionObjects; //���������� ������ ������� ��� ���;
    public int Money; // ���������� �����;

    void OnGUI()
    {
        if (quest)
        {
            GUI.Label(new Rect(20, 80, 300, 30), " " + MissionText); // �������� �������� ������ ����� ������� �� ������� Misson Bot;
            if (MissionObjects)
            { // ���� ������� ������;
                GUI.Label(new Rect(150, 80, 200, 30), "[������� ������]");
            }
        } // ������� �������;
                GUI.Label(new Rect(20, 100, 100, 30), "������: " + Money);
            }
        }
    
// ���������� ���������� ����� �� ������;
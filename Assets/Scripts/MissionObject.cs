using UnityEngine;
using System.Collections;
public class MissionObject : MonoBehaviour

{
    private MissionPlayer MP; // ���������� ������ MissionPlayer;

    void Start() {
        MP = GameObject.FindGameObjectWithTag("Player").GetComponent<MissionPlayer>();// ���������� ��� ������ MissionPlayer ����� ��������� �� ��������� � ����� player;
    }
    void OnMouseUp() {
        if (Input.GetMouseButtonUp(0)) // ���� ��� ������� �� ������ ������ ����;
        {
            if (MP.ObjectTag == gameObject.tag) // � ��� ��� ��� ��� ������� ����� ���� �������� ������� �������� � ObjectTag;
            {
                MP.MissionObjects = true; // �� ���������� ��������� �������� true, �.�. ��������� ��� ������� ������;
                Destroy(gameObject); // � ������� ���� ������ �� �����;
             }
        }
    }
}

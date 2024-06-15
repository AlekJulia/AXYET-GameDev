using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[System.Serializable]

public class ItemPick : MonoBehaviour
{
	public Image[] Items;
	public Sprite[] Sprites;

	int i = 0;
	private void OnTriggerEnter2D(Collider2D obj)
	{
			if (obj.tag == "BluePotion" && Items[i].sprite == Sprites[4] && (i < 12))
			{
				Items[i].sprite = Sprites[0];
				i++;
			}

			if (obj.tag == "GreenPotion" && Items[i].sprite == Sprites[4] && (i < 12))
			{
				Items[i].sprite = Sprites[1];
				i++;
			}

			if (obj.tag == "PurplePotion" && Items[i].sprite == Sprites[4] && (i < 12))
			{
				Items[i].sprite = Sprites[2];
				i++;
			}

			if (obj.tag == "RedPotion" && Items[i].sprite == Sprites[4] && (i < 12))
			{
				Items[i].sprite = Sprites[3];
				i++;
			}
	}
}
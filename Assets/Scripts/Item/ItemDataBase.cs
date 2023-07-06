using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDataBase", menuName = "CreateItemDataBase")]
public class ItemDataBase : ScriptableObject
{
	[SerializeField] private List<CharaItem> charaItemList = new List<CharaItem>();

	public List<CharaItem> GetCharaItemList()
	{
		return charaItemList;
	}
	public CharaItem GetCharaItemFromName(string str)
	{
		return charaItemList.Find(x => x.GetItemName() == str);
	}

	public List<CharaItem> GetHasCharaItemList()
	{
		return charaItemList.FindAll(x => x.GetHasItem() == true);
	}
	public List<CharaItem> GetRegisterCharaItemList()
	{
		return charaItemList.FindAll(x => x.GetIsRegister() == true);
	}
	public List<CharaItem> GetItemListFromCategory(Category cat)
	{
		return charaItemList.FindAll(x => x.GetCategory() == cat);
	}
	// �A�C�e���̓��肵����ސ���Ԃ�
	public int GetHasItemNum()
	{
		int sum = 0;
		foreach (var ch in charaItemList)
		{
			if (ch.GetHasItem() == true)
			{
				sum++;
			}
		}
		sum -= 6; //none�̐�
		return sum;
	}
	// �A�C�e���̓o�^������ސ���Ԃ�
	public int GetRegisterItemNum()
	{
		int sum = 0;
		foreach (var ch in charaItemList)
		{
			if (ch.GetIsRegister() == true)
			{
				sum++;
			}
		}
		sum -= 6; //none�̐�
		return sum;
	}
	// �f�[�^���폜����
	public void ResetData()
	{
		foreach (CharaItem item in charaItemList)
		{
				item.SetHasItem(false);
				item.SetIsRegister(false);
		}
		// none��true�ɂ���
		GetCharaItemFromName("hat_none").SetHasItem(true);
		GetCharaItemFromName("hat_none").SetIsRegister(true);
		GetCharaItemFromName("body_none").SetHasItem(true);
		GetCharaItemFromName("body_none").SetIsRegister(true);
		GetCharaItemFromName("bottoms_none").SetHasItem(true);
		GetCharaItemFromName("bottoms_none").SetIsRegister(true);
		GetCharaItemFromName("tops_none").SetHasItem(true);
		GetCharaItemFromName("tops_none").SetIsRegister(true);
		GetCharaItemFromName("sox_none").SetHasItem(true);
		GetCharaItemFromName("sox_none").SetIsRegister(true);
		GetCharaItemFromName("shoes_none").SetHasItem(true);
		GetCharaItemFromName("shoes_none").SetIsRegister(true);
	}
	// �S�A�C�e�����̃J�e�S�����̃A�C�e������Ԃ�
	public int GetCategoryItemNum(Category cat)
    {
		int sum = 0;
		foreach (var ch in charaItemList)
		{
			if (ch.GetCategory() == cat)
			{
				sum++;
			}
		}
		sum -= 1; //none
		return sum;
	}
	// �o�^����Ă���A�C�e���̂̃J�e�S�����̃A�C�e������Ԃ�
	public int GetRegisterCategoryItemNum(Category cat)
	{
		int sum = 0;
		List<CharaItem> selectList = GetRegisterCharaItemList();
		foreach (var ch in selectList)
		{
			if (ch.GetCategory() == cat)
			{
				sum++;
			}
		}
		sum -= 1; //none
		return sum;
	}
}
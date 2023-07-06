using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Category
{
	Hat,
	Body,
	Bottoms,
	Tops,
	Sox,
	Shoes,
}

[Serializable]
public struct SelectedItem
{
	public string hat;
	public string body;
	public string bottoms;
	public string tops;
	public string sox;
	public string shoes;
}

[Serializable]
[CreateAssetMenu(fileName = "CharaItem", menuName = "CreateCharaItem")]
public class CharaItem : ScriptableObject
{
	public static SelectedItem selectedName; //�I�����Ă���A�C�e����
	[SerializeField] private string itemName;   // �A�C�e����
	[SerializeField] private bool hasItem;      // �A�C�e���������Ă��邩�ǂ���
	[SerializeField] private bool isRegister;	// �}�ӂɓo�^����Ă��邩[�ۑ������f�[�^]
	[SerializeField] private Category category; // �A�C�e���̕��ށi������A�ߕ��Ȃǁj
	[SerializeField] private GameObject gameObject;
	[SerializeField] private Sprite sprite;
	[SerializeField] private float weight; //�A�C�e���̏o����
	[SerializeField] private float score;  //�A�C�e���̓_��

	// �R���X�g���N�^
	public CharaItem()
    {
		selectedName.hat = "hat_none";
		selectedName.body = "body_none";
		selectedName.bottoms = "bottoms_none";
		selectedName.shoes = "shoes_none";
		selectedName.sox = "sox_none";
		selectedName.tops = "tops_none";
	}
	public string GetItemName()
	{
		return itemName;
	}
	public bool GetHasItem()
	{
		return hasItem;
    }
	public bool GetIsRegister()
	{
		return isRegister;
	}
	public Category GetCategory()
    {
		return category;
    }
	public GameObject GetGameObject()
    {
		return gameObject;
    }
	public Sprite GetSprite()
    {
		return sprite;
    }
	public float GetWeight()
    {
		return weight;
    }
	public float GetScore()
    {
		return score;
    }
	public void SetItemName(string value)
	{
		itemName = value;
	}
	public void SetHasItem(bool value)
	{
		hasItem = value;
	}
	public void SetIsRegister(bool value)
	{
		isRegister = value;
	}
	public void SetWeight(float value)
	{
		weight = value;
	}
	// �Q�[���ɕK�v�ȏ�����
    public void ResetNeedFlag()
    {
		if (itemName != "hat_none" && itemName != "body_none" && itemName != "bottoms_none" && itemName != "tops_none" && itemName != "sox_none" && itemName != "shoes_none")
		{
			hasItem = false;
		}
	}
}

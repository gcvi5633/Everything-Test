using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {
	#region 角色基本資料
	[System.Serializable]
	public struct hpSetting{
	public float hp;
	public float maxHp;
	public float hpByLevel;
	}
	[System.Serializable]
	public struct mpSetting{
	public float mp;
	public float maxMp;
	public float MpByLevel;
	}
	[System.Serializable]
	public struct atkSetting{
	public float attack;
	public float attackByLevel;
	}
	[System.Serializable]
	public struct allSetting{
		public hpSetting hpSet;
		public mpSetting mpSet;
		public atkSetting atkSet;
	}
	#endregion
	public allSetting warrior,wizard,archer;
	// Use this for initialization
	void Start () {
		warrior.hpSet.hp = 50;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

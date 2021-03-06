﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
//岩
public class LevelControl : MonoBehaviour {

	public AudioSource AudioSource;
	public LRSelectLevelButton LeftButton;
	public LRSelectLevelButton RightButton;
	public Sprite SelectLevelButtonInSprite;
	public Sprite SelectLevelButtonOutSprite;
	public Transform LevelIcon;
	public GameObject NowButton;
	public Text LevelNameZh_CNLabel;
	public Text LevelNameEnLabel;
	public Text DiamondLabel;
	public Texture CrownInSprite;
	public RawImage CrownIcon1;
	public RawImage CrownIcon2;
	public RawImage CrownIcon3;
	public Text ProgressText;
	public int NowLevelID;
	public int NowSceneID;
	public string NowLevelNameZh_CN;
	public string NowLevelNameEn;
    public GameObject Piano;
    public GameObject Rollin;

    public void Start () {
		SelectLevel (NowButton, 0);
        Piano = GameObject.Find("Pinao_L");
        Rollin = GameObject.Find("Rollin_L");
     // Piano.SetActive(false);
    }

	public void Update () {
        GameObject.Find("Piano_L");
        if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			LeftButton.Click ();
            //
            Piano.SetActive(true);
            Rollin.SetActive(false);
        }
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			RightButton.Click ();
            Piano.SetActive(false);
            Rollin.SetActive(true);
        }
	}

	public void SelectLevel (GameObject SelectLevelButton, float LevelToPos) {
        //AudioSource.Stop ();
        // Piano.SetActive(false);
       // Piano = GameObject.Find("Pinao_L");
       // Rollin = GameObject.Find("Rollin_L");
        LevelInfo LevelInfo = SelectLevelButton.GetComponent<LevelInfo> ();
		NowButton.GetComponent<Image> ().sprite = SelectLevelButtonOutSprite;
		NowButton = SelectLevelButton;
		NowButton.GetComponent<Image> ().sprite = SelectLevelButtonInSprite;
		NowLevelNameZh_CN = SelectLevelButton.GetComponent<LevelInfo> ().LevelNameZh_CN;
		NowLevelNameEn = SelectLevelButton.GetComponent<LevelInfo> ().LevelNameEn;
		LevelNameZh_CNLabel.text = NowLevelNameZh_CN;
		LevelNameEnLabel.text = NowLevelNameEn;
		LevelIcon.DOMoveX (LevelToPos, 0.5f, false);
		NowLevelID = SelectLevelButton.GetComponent<LevelInfo> ().LevelID;
		NowSceneID = SelectLevelButton.GetComponent<LevelInfo> ().SceneID;
        //
        if (NowLevelID == 1)
        {
            Piano.SetActive(true);
            Rollin.SetActive(false);
        }

        if (NowLevelID == 2) { Piano.SetActive(false);
            Rollin.SetActive(true);
        }

        AudioSource.clip = LevelInfo.Audio;
		AudioSource.Play ();
		if (!PlayerPrefs.HasKey (LevelInfo.LevelNameEn + "_Wined")) {
			PlayerPrefs.SetString (LevelInfo.LevelNameEn + "_Wined", "false");
			PlayerPrefs.SetInt (LevelInfo.LevelNameEn + "_Crown", 0);
			PlayerPrefs.SetInt (LevelInfo.LevelNameEn + "_Diamond", 0);
			PlayerPrefs.SetInt (LevelInfo.LevelNameEn + "_Percentage", 0);
			PlayerPrefs.SetString (LevelInfo.LevelNameEn + "_Unlocked", "true");
		}
		if (PlayerPrefs.GetInt(LevelInfo.LevelNameEn + "_Crown") >= 1){
			CrownIcon1.texture = CrownInSprite;
		}
		if (PlayerPrefs.GetInt(LevelInfo.LevelNameEn + "_Crown") >= 2){
			CrownIcon2.texture = CrownInSprite;
		}
		if (PlayerPrefs.GetInt(LevelInfo.LevelNameEn + "_Crown") >= 3){
			CrownIcon3.texture = CrownInSprite;
		}
		ProgressText.text = PlayerPrefs.GetInt (LevelInfo.LevelNameEn + "_Percentage").ToString() + "%";
		DiamondLabel.text = PlayerPrefs.GetInt (LevelInfo.LevelNameEn + "_Diamond").ToString() + "/" + LevelInfo.MaxDiamond.ToString();
	}
}

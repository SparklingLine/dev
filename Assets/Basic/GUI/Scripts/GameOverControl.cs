using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameOverControl : MonoBehaviour {

	public LevelInfo LevelInfo;
	public Text LevelNameZh_CNLabel;
	public Text LevelNameEnLabel;
	public Text DiamondLabel;
	public RawImage CrownIcon1;
	public RawImage CrownIcon2;
	public RawImage CrownIcon3;
	public Image ProgressImage;
	public RawImage ProgressTextBar;
	public Text ProgressText;
	public Color PrefaceColor;

	// Use this for initialization
	public void GameOver (bool win, int Percentage, int PickDimaondCount, int PickCrownCount){
		LevelNameZh_CNLabel.text = LevelInfo.LevelNameZh_CN;
		LevelNameEnLabel.text = LevelInfo.LevelNameEn;
		DiamondLabel.text = PickDimaondCount.ToString() + "/" + LevelInfo.MaxDiamond.ToString();
		ProgressImage.DOFillAmount (float.Parse(Percentage.ToString ()) / 100, 3f);
		ProgressText.text = Percentage.ToString() + "%";
		if (win == true) {
			if (PickCrownCount == 0) {
				PickCrownCount = 1;
			}
			if (PickCrownCount >= 1) {
				CrownIcon1.DOFade (1, 3);
			}
			if (PickCrownCount >= 2) {
				CrownIcon2.DOFade (1, 3);
			}
			if (PickCrownCount == 3) {
				CrownIcon3.DOFade (1, 3);
			}
			if (PickDimaondCount == LevelInfo.MaxDiamond && PickCrownCount == 3) {
				ProgressTextBar.DOColor (PrefaceColor, 2f);
			}
			PlayerPrefs.SetString (LevelInfo.LevelNameEn + "_Wined", "true");
			if (PlayerPrefs.GetInt (LevelInfo.LevelNameEn + "_Crown") < PickCrownCount){
				PlayerPrefs.SetInt (LevelInfo.LevelNameEn + "_Crown", PickCrownCount);
			}
		}
		if (PlayerPrefs.GetInt (LevelInfo.LevelNameEn + "_Diamond") < PickDimaondCount) {
			PlayerPrefs.SetInt (LevelInfo.LevelNameEn + "_Diamond", PickDimaondCount);
		}
		if (PlayerPrefs.GetInt (LevelInfo.LevelNameEn + "_Percentage") < Percentage) {
			PlayerPrefs.SetInt (LevelInfo.LevelNameEn + "_Percentage", Percentage);
		}
		PlayerPrefs.SetString (LevelInfo.LevelNameEn + "_Unlocked", "true");
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MainLine : MonoBehaviour {
	/// <summary>
	/// 线身
	/// </summary>
	public GameObject cube;
	public GameObject die_effect;
	public AudioClip die_sound;
	public AudioSource start_audio;
	public GameObject jump_effect;
	public MainLine Other_Line;
	public Text PercentageOnUI;
	public GameObject ContinueTab;
	public float Jump_Effect_Deviation = 0;
	private int HitCount = 0;
	private bool isFall = true;
	public Vector3 NowForward;
	public float Speed;
	public bool No_Clip = false;
	[HideInInspector]public Queue<GameObject> Way = new Queue<GameObject>();
	private GameObject Jump_Effect_temp;
	public Vector3 Block_Foward1;
	public Vector3 Block_Foward2;
	public bool Over = true;
	public bool canuse = true;
	public bool Is_Stop = false;
	public bool fly = false;
	[HideInInspector]public int NowPercentage = 0;
	[HideInInspector]public GameObject LineBody;
	[HideInInspector]public GameObject LastLineBody;
	[HideInInspector]public bool Pause = false;
	public bool start = false;
	[HideInInspector]public bool keydown = false;
	[HideInInspector]public GameObject Crown1;
	[HideInInspector]public GameObject Crown2;
	[HideInInspector]public GameObject Crown3;
	[HideInInspector]public int PickDiamondCount = 0;
	[HideInInspector]public bool Win = false;
	public GameObject Camera;
	public GameObject OverTab;
	void Start () {
		NowForward = Block_Foward1;
		this.transform.localEulerAngles = NowForward;
		if (PercentageOnUI)
		{
			InvokeRepeating ("setPercentage", 0f, start_audio.GetComponent<AudioSource> ().clip.length / 100);
		}
	}
	public void GameOver(bool win, bool stop)
	{
		if (win != true) {
			Over = true;
			Destroy(Instantiate (die_effect, this.transform.position, this.transform.rotation), 10f);
			AudioSource.PlayClipAtPoint (die_sound, this.transform.position);
			if (start_audio) {
				float Time = start_audio.time;
				start_audio.Pause ();
				start_audio.time = Time;
			}
			if (Other_Line.Over == false) {
				Other_Line.GameOver (win, stop);
			}
			Is_Stop = stop;
			this.GetComponent<Rigidbody> ().isKinematic = stop;
			if (Crown1 != null) {
				if (ContinueTab != null) {
					ContinueTab.GetComponent<CanvasGroup> ().alpha = 0;
					ContinueTab.SetActive (true);
					DOTween.To (() => ContinueTab.GetComponent<CanvasGroup> ().alpha, x => ContinueTab.GetComponent<CanvasGroup> ().alpha = x, 1, 2);
				}
			} else {
				if (OverTab != null) {
					OverTab.GetComponent<CanvasGroup> ().alpha = 0;
					OverTab.SetActive (true);
					DOTween.To (() => OverTab.GetComponent<CanvasGroup> ().alpha, x => OverTab.GetComponent<CanvasGroup> ().alpha = x, 1, 2);
					OverTab.GetComponent<GameOverControl> ().GameOver (false, NowPercentage, PickDiamondCount, GetPickCrownCount ());
				}
			}
		} else {
			Win = true;
			Is_Stop = true;
			NowPercentage = 100;
			OverTab.GetComponent<CanvasGroup> ().alpha = 0;
			OverTab.SetActive (true);
			DOTween.To (() => OverTab.GetComponent<CanvasGroup> ().alpha, x => OverTab.GetComponent<CanvasGroup> ().alpha = x, 1, 2);
			OverTab.GetComponent<GameOverControl> ().GameOver (true, NowPercentage, PickDiamondCount, GetPickCrownCount());
		}
	}
	void Update (){
		if (!Over && !Is_Stop && start) {
			if (isGrounded() == true || fly == true) {
				if (canuse == true) {
					if ((Input.GetMouseButton (0) || Input.GetKeyDown (KeyCode.Space)) && keydown == false) {
						keydown = true;
						TurnBlock ();
					} else if (!(Input.GetMouseButton (0) && keydown == true)) {
						keydown = false;
					}
				}
			} else {
				if (LineBody != null) {
					Way.Enqueue (LineBody);
					LineBody = null;
				}
			}
			this.transform.Translate (Vector3.forward * Speed * 5f * Time.deltaTime, Space.Self);
			if (LineBody != null) {
				LineBody.transform.localScale = new Vector3 (LineBody.transform.localScale.x, LineBody.transform.localScale.y, LineBody.transform.localScale.z + 5f * Speed * Time.deltaTime);
				LineBody.transform.Translate (Vector3.forward * 2.5f * Speed * Time.deltaTime, Space.Self);
			}
		}
		if (start == false) {
			if (Input.GetMouseButtonDown (0) || Input.GetKeyDown(KeyCode.Space)) {
				keydown = true;
				start = true;
				Over = false;
				Is_Stop = false;
				CreateLineBody ();
				if(start_audio)
					start_audio.GetComponent<AudioSource> ().Play ();
			}
		}
	}
	void OnCollisionEnter(Collision collision) {
		if (Over == false)
		{
			if (No_Clip == true)
			{
				HitCount++;
				if (jump_effect && isFall == true)
				{
					Jump_Effect_temp = Instantiate (jump_effect, new Vector3 (this.transform.position.x, this.transform.position.y - this.transform.lossyScale.y / 2 + 0.2f, this.transform.position.z), this.transform.rotation);
					Destroy (Jump_Effect_temp, 0.8f);
				}
			}
			else
			{
				if (collision.collider.tag == "Wall") {
					GameOver (false, true);
				}
				else
				{
					if (jump_effect && isFall == true) {
						Jump_Effect_temp = Instantiate (jump_effect, new Vector3 (this.transform.position.x, this.transform.position.y - this.transform.lossyScale.y / 2 + 0.2f, this.transform.position.z), this.transform.rotation);
						Destroy (Jump_Effect_temp, 0.8f);
					}
				}
			}
			CreateLineBody ();
		}
		isFall = false;
	}
	void OnCollisionExit(Collision collision) {
		isFall = !isGrounded ();
	}

	public void TurnBlock() {
		if (NowForward == Block_Foward1) {
			NowForward = Block_Foward2;
		} else {
			NowForward = Block_Foward1;
		}
		this.transform.eulerAngles = NowForward;
		CreateLineBody ();
	}

	public void CreateLineBody() {
		if (LineBody != null)
			LastLineBody = LineBody;
		LineBody = Instantiate (cube, this.transform.position, this.transform.rotation);
		LineBody.AddComponent<MeshCollider> ();
		LineBody.GetComponent<MeshCollider> ().convex = true;
		if (LastLineBody != null) {
			Way.Enqueue (LastLineBody);
		}
	}

	public void setPercentage() {
		PercentageOnUI.GetComponent<Text>().text = NowPercentage + "%";
		if (start && Over != true && NowPercentage < 100)
		{
			NowPercentage = NowPercentage + 1;
		}
		if (start && Win)
			NowPercentage = 100;
	}

	public bool isGrounded () {
		return Physics.Raycast (this.transform.position, Vector3.down, this.transform.localScale.y / 2 + 0.1f);
	}

	public int GetPickCrownCount () {
		int PickCrownCount = 0;
		if (Crown3 != null && Crown3.GetComponent<pick_crown> ().used == false) {
			PickCrownCount++;
		}
		if (Crown2 != null && Crown2.GetComponent<pick_crown> ().used == false) {
			PickCrownCount++;
		}
		if (Crown1 != null && Crown1.GetComponent<pick_crown> ().used == false) {
			PickCrownCount++;
		}
		return PickCrownCount;
	}

	public void PC () {
		if (Over != true) {
			if (Pause == false) {
				Time.timeScale = 0;
				Pause = true;
				if (start_audio) {
					start_audio.GetComponent<AudioSource> ().Pause ();
				}
			} else {
				Time.timeScale = 1;
				Pause = false;
				if (start_audio) {
					start_audio.GetComponent<AudioSource> ().Play ();
				}
			}
			TurnBlock ();
		}
	}

	public void GoToEaster () {
		if (Crown3 != null) {
			Crown3.GetComponent<pick_crown> ().Easter ();
		} else if (Crown2 != null) {
			Crown2.GetComponent<pick_crown> ().Easter ();
		} else {
			Crown1.GetComponent<pick_crown> ().Easter ();
		}
	}
}
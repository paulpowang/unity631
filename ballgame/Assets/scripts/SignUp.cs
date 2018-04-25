using UnityEngine;

using System;
using System.Collections;
using System.IO;
using System.Net.Sockets;
using UnityEngine.SceneManagement;

public class SignUp : MonoBehaviour {
	
	//private GameObject mainObject;
	// Window Properties
	private float width = 280;
	private float height = 100;
	// Other
	public Texture background;
	private string user_id = "";
	private string password = "";
	private string email = "";
	private Rect windowRect;
	private bool isHidden;
	
	void Awake() {
		//mainObject = GameObject.Find("MainObject");

		//mainObject.GetComponent<MessageQueue>().AddCallback(Constants.SMSG_AUTH, ResponseLogin);
	}
	
	// Use this for initialization
	void Start() {

	}
	
	void OnGUI() {
		// Background
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), background);
		
		// Client Version Label
		GUI.Label(new Rect(Screen.width - 75, Screen.height - 20, 65, 20), "v" + Constants.CLIENT_VERSION + " Test");

		// Login Interface
		if (!isHidden) {
			windowRect = new Rect ((Screen.width - width) / 2, Screen.height / 2 - height, width, height);
			windowRect = GUILayout.Window((int) Constants.GUI_ID.Login, windowRect, MakeWindow, "SignUp");
		
			if (Event.current.type == EventType.KeyUp && Event.current.keyCode == KeyCode.Return) {
				Submit();
			}
		}
	}
	
	void MakeWindow(int id) {
		GUILayout.Label("User ID");
		GUI.SetNextControlName("username_field");
		user_id = GUI.TextField(new Rect(30, 45, windowRect.width - 60, 30), user_id, 25);

		GUILayout.Space(32);
		
		GUILayout.Label("Password");
		GUI.SetNextControlName("password_field");
		password = GUI.PasswordField(new Rect(30, 100, windowRect.width - 60, 30), password, "*"[0], 25);

		GUILayout.Space(31);

		GUILayout.Label("Email");
		GUI.SetNextControlName("email_field");
		email = GUI.TextField(new Rect(30, 155, windowRect.width - 60, 30), email, 50);

		GUILayout.Space(130);

		if (GUI.Button(new Rect(windowRect.width / 2 - 50, 200, 100, 30), "Sign up")) {
			Submit();
		}
		if (GUI.Button(new Rect(windowRect.width / 2 - 50, 240, 100, 30), "Return to login")) {
			SceneManager.LoadSceneAsync("Login");
		}
		
	}
	
	public void Submit() {
		user_id = user_id.Trim();
		password = password.Trim();
		
		if (user_id.Length == 0) {
			Debug.Log("User ID Required");
			GUI.FocusControl("username_field");
		} else if (password.Length == 0) {
			Debug.Log("Password Required");
			GUI.FocusControl("password_field");
		} else {
			//ConnectionManager cManager = mainObject.GetComponent<ConnectionManager>();
			
			//if (cManager) {
			//	cManager.send(requestLogin(user_id, password));
			//}
		}
	}

	public void Show() {
		isHidden = false;
	}
	
	public void Hide() {
		isHidden = true;
	}
	
	// Update is called once per frame
	void Update() {
	}
}

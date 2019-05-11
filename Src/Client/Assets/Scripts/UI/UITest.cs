using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UITest : UIWindow {

    // Use this for initialization
    public Text title;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetTitle(string title)
    {
        this.title.text = title;
    }
}

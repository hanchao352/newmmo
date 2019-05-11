using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;
public class MapController : MonoBehaviour {

    // Use this for initialization
    public Collider minimapBoundingbox;
	void Start () {
        MinimapManager.Instance.UpdateMinimap(minimapBoundingbox);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

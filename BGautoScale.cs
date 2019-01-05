using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgScaleHeadache : MonoBehaviour {

	// Use this for initialization
	void Start () {
        resize();
	}
	
	// Update is called once per frame
	void resize () {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        float worldScreenHeight = Camera.main.orthographicSize * 2;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        transform.localScale = new Vector3(
            worldScreenWidth / sr.sprite.bounds.size.x,
            worldScreenHeight / sr.sprite.bounds.size.y, 1);
    }
}

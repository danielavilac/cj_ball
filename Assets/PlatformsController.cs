using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformsController : MonoBehaviour
{
    public List<GameObject> platforms;
    public Color[] colors = new Color[5] {Color.red, Color.blue, Color.green, Color.yellow, Color.white};

    void Awake ()
    {
        ShuffleArray(colors);
    }

    void Start ()
    {
        for (int i = 0; i < platforms.Count; i++) 
        {
            platforms[i].renderer.material.color = colors[i];
        }
    }
	
	void Update ()
    {
        foreach (GameObject platform in platforms)
        {
            platform.transform.Translate(Input.acceleration.x, 0, 0);
        }
	}

    public void ShuffleArray<T>(T[] arr) {
        for (int i = arr.Length - 1; i > 0; i--) {
            int r = Random.Range(0, i);
            T tmp = arr[i];
            arr[i] = arr[r];
            arr[r] = tmp;
        }
    }
}

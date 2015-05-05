using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{
    public PlatformsController platformsController;

    void Awake ()
    {
        platformsController = Camera.main.GetComponent<PlatformsController>();
        SetInitialColor();
    }

    void OnCollisionEnter (Collision col)
    {
        Color ballColor = gameObject.renderer.material.color;
        Color platformColor = col.gameObject.renderer.material.color;
        if (ballColor == platformColor)
        {
            Debug.Log("Same color");
        } 
        else
        {
            Debug.Log("Different color");
        }
        SetColor();
    }

    private void SetColor ()
    {
        int index = Random.Range(0, platformsController.colors.Length);
        gameObject.renderer.material.color = platformsController.colors[index];
    }

    private void SetInitialColor ()
    {
        // Initial color has to be always the same color of the center platform
        gameObject.renderer.material.color = platformsController.colors[0];
    }
}

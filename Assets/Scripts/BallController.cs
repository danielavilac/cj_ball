using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{
    public PlatformsController platformsController;
    private ScoreController scoreController;
    private Vector3 initialPosition;

    void Awake ()
    {
        platformsController = Camera.main.GetComponent<PlatformsController>();
        scoreController = Camera.main.GetComponent<ScoreController>();
    }

    void Start ()
    {
        initialPosition = transform.position;
        SetInitialColor();
        Invoke("StartGame", 3);
    }

    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.name == "Endcollider")
        {
            EndGame();
            return;
        }

        Color ballColor = gameObject.renderer.material.color;
        Color platformColor = col.gameObject.renderer.material.color;

        if (ballColor == platformColor)
        {
            Debug.Log("Same color");
            scoreController.Increase();
        } 

        else
        {
            Debug.Log("Game over");
            EndGame();
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

    private void EndGame ()
    {
        transform.position = initialPosition;
        rigidbody.velocity = Vector3.zero;
        rigidbody.useGravity = false;
        Invoke("StartGame", 3);
    }

    private void StartGame ()
    {
        scoreController.Reset();
        rigidbody.useGravity = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExploedCubes : MonoBehaviour
{
    public Text gameOver;
    public Text scoreText;
    public GameObject restartButton;
    private bool _collisionSet;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cubes" && !_collisionSet)
        {
            // про методы которые используются в этом цикле.
            for(int i = collision.transform.childCount - 1; i>= 0; i--)
            {
                Transform child = collision.transform.GetChild(i);
                child.gameObject.AddComponent<Rigidbody>();
                child.gameObject.GetComponent<Rigidbody>().AddExplosionForce(70f, Vector3.up, 5f);
                child.SetParent(null);
            }
            restartButton.SetActive(true);
            Camera.main.transform.position -=new Vector3(0, 0, 3f);
            gameOver.text = "GAME OVER!";
            scoreText.text = "Score - " + GameController.score.ToString();
            Destroy(collision.gameObject);
            _collisionSet = true;
            

        }
    }
}

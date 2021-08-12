using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{

    [SerializeField] private float speed = 10f;
    [SerializeField] private float speedDelta = 0.2f;
    [SerializeField] private float turnSpeed = 200f;
    
    private float turn = 0;

    private int steerValue;

    // Update is called once per frame
    void Update()
    {
        speed += speedDelta * Time.deltaTime;
        turn = steerValue * turnSpeed * Time.deltaTime;
        transform.Rotate(0f,steerValue * turnSpeed * Time.deltaTime, 0f);

        transform.Translate(Vector3.forward* speed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Obstacle")) {
            SceneManager.LoadScene("Scene_MainMenu");
        }
    }

    public void Steer(int value) {
        steerValue = value;
    }
}

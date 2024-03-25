using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class SquareController: MonoBehaviour 
{
    // Start is called before the first frame update
    public float timeRemaining = 60;
    public Text countdownText;
    void Start()
    {
        StartCoroutine(Countdown());
    }
    IEnumerator Countdown()
    {
        while(timeRemaining>0) 
        {
            yield return new WaitForSeconds(1);
            timeRemaining--;
            countdownText.text ="Time: " + timeRemaining.ToString();
        }
        countdownText.text = "Time's up!";
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, vertical, 0f).normalized;
        transform.Translate(movement* 5f * Time.deltaTime);
    }
    public void LoadNextScene()
    {
        int currentsceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentsceneIndex +1);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Circle"))
        {
            Debug.Log("xxx");
            Vector2 fistPosition = new Vector2(-6, 1);
            transform.position = fistPosition;
        }
        if (collision.gameObject.name.Equals("Box"))
        {
            Debug.Log("win");
            LoadNextScene();
        }
        if (collision.gameObject.tag.Equals("SpinWheel"))
        {
            Vector2 fistPosition = new Vector2(-9, 1);
            transform.position = fistPosition;
        }
           
    }
}

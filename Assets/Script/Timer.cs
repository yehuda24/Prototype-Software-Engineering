using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float remainingTime;


    
    // Update is called once per frame
    void Update()
    {
        if(remainingTime > 11)
        {
            remainingTime -= Time.deltaTime;
            timerText.color = Color.green;
        }
        else if( remainingTime <= 11 && remainingTime > 6)
        {
           remainingTime -= Time.deltaTime;
           timerText.color = new Color(1f, 0.5f, 0f, 1f);
        }
        else if( remainingTime <= 6 && remainingTime > 0 )
        {
           remainingTime -= Time.deltaTime;
           timerText.color = Color.red;
        }
        else if( remainingTime <= 0)
        {
            remainingTime = 0;
        }
        
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}",minutes ,seconds);
    }
}

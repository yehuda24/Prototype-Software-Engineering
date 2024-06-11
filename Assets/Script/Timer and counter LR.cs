using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI CompletionText;
    [SerializeField] private float remainingTime;
    private SceneChanger changer;
    [SerializeField] private float Banyak_sampah;
    public float current_sampahLR;
    public float current_completionLR;
    
    void Start()
    {
        current_sampahLR = 0f;
        current_completionLR = 0f;
        GameObject obj = GameObject.Find("SceneManager"); 
        changer = obj.GetComponent<SceneChanger>();
    }
    
    public void CorrectLR()
    {
        current_sampahLR += 1;
        current_completionLR += 100 / Banyak_sampah;
        CompletionManager.Instance.current_completionLR = current_completionLR;
    }

    public void WrongLR()
    {
        current_sampahLR += 1;
    }



    

    
    // Update is called once per frame
    void Update()
    {
        if(remainingTime > 11 && current_sampahLR < Banyak_sampah)
        {
            remainingTime -= Time.deltaTime;
            timerText.color = Color.green;
        }
        else if( remainingTime <= 11 && remainingTime > 6 && current_sampahLR < Banyak_sampah)
        {
           remainingTime -= Time.deltaTime;
           timerText.color = new Color(1f, 0.5f, 0f, 1f);
        }
        else if( remainingTime <= 6 && remainingTime > 0 && current_sampahLR < Banyak_sampah)
        {
           remainingTime -= Time.deltaTime;
           timerText.color = Color.red;
        }
        else if( remainingTime <= 0 || current_sampahLR >= Banyak_sampah)
        {
            remainingTime = 0;
            changer.ChangeScene("Kitchen");
        }
        
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}",minutes ,seconds);
        CompletionText.text = "Completion: " + current_completionLR +"%";
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerB : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI CompletionText;
    [SerializeField] private float remainingTime;
    private SceneChanger changer;
    [SerializeField] private float Banyak_sampah;
    public float current_sampahB;
    public float current_completionB;
    public float current_completionB1;
    
    void Start()
    {
        current_sampahB = 0f;
        current_completionB = 0f;
        GameObject obj = GameObject.Find("SceneManager"); 
        changer = obj.GetComponent<SceneChanger>();
    }
    
    public void CorrectB()
    {
        current_sampahB += 1;
        current_completionB += 100 / Banyak_sampah;
        current_completionB1 = (float)System.Math.Round(current_completionB, 2);
        CompletionManager.Instance.current_completionB = current_completionB1;
    }

    public void WrongB()
    {
        current_sampahB += 1;
    }



    

    
    // Update is called once per frame
    void Update()
    {
        if(remainingTime > 11 && current_sampahB < Banyak_sampah)
        {
            remainingTime -= Time.deltaTime;
            timerText.color = Color.white;
        }
        else if( remainingTime <= 11 && remainingTime > 6 && current_sampahB < Banyak_sampah)
        {
           remainingTime -= Time.deltaTime;
           timerText.color = Color.white;
        }
        else if( remainingTime <= 6 && remainingTime > 0 && current_sampahB < Banyak_sampah)
        {
           remainingTime -= Time.deltaTime;
           timerText.color = Color.red;
        }
        else if( remainingTime <= 0 || current_sampahB >= Banyak_sampah)
        {
            remainingTime = 0;
            changer.ChangeScene("END");
        }
        
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}",minutes ,seconds);
        CompletionText.text = "Completion:\n " + current_completionB1 +"%";
    }

}

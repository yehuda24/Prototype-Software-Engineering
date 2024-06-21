using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerDR : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI CompletionText;
    [SerializeField] private float remainingTime;
    private SceneChanger changer;
    [SerializeField] private float Banyak_sampah;
    public float current_sampahDR;
    public float current_completionDR;
    public float current_completionDR1;

    void Start()
    {
        current_sampahDR = 0f;
        current_completionDR = 0f;
        GameObject obj = GameObject.Find("SceneManager"); 
        changer = obj.GetComponent<SceneChanger>();
    }
    
    public void CorrectDR()
    {
        current_sampahDR += 1;
        current_completionDR += 100 / Banyak_sampah;
        current_completionDR1 = (float)System.Math.Round(current_completionDR, 2);
        CompletionManager.Instance.current_completionDR = current_completionDR1;
    }

    public void WrongDR()
    {
        current_sampahDR += 1;
    }



    

    
    // Update is called once per frame
    void Update()
    {
        if(remainingTime > 11 && current_sampahDR < Banyak_sampah)
        {
            remainingTime -= Time.deltaTime;
            timerText.color = Color.green;
        }
        else if( remainingTime <= 11 && remainingTime > 6 && current_sampahDR < Banyak_sampah)
        {
           remainingTime -= Time.deltaTime;
           timerText.color = new Color(1f, 0.5f, 0f, 1f);
        }
        else if( remainingTime <= 6 && remainingTime > 0 && current_sampahDR < Banyak_sampah)
        {
           remainingTime -= Time.deltaTime;
           timerText.color = Color.red;
        }
        else if( remainingTime <= 0 || current_sampahDR >= Banyak_sampah)
        {
            remainingTime = 0;
            changer.ChangeScene("Bedroom");
        }
        
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}",minutes ,seconds);
        CompletionText.text = "Completion: " + current_completionDR1 +"%";
    }

}

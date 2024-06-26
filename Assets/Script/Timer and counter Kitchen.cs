using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerK : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI CompletionText;
    [SerializeField] private float remainingTime;
    private SceneChanger changer;
    [SerializeField] private float Banyak_sampah;
    public float current_sampahK;
    public float current_completionK;
    public float current_completionK1;
    
    void Start()
    {
        current_sampahK = 0f;
        current_completionK = 0f;
        GameObject obj = GameObject.Find("SceneManager"); 
        changer = obj.GetComponent<SceneChanger>();
    }
    
    public void CorrectLR()
    {
        current_sampahK += 1;
        current_completionK += 100 / Banyak_sampah;
        current_completionK1 = (float)System.Math.Round(current_completionK,2);
        CompletionManager.Instance.current_completionK = current_completionK1;
    }

    public void WrongK()
    {
        current_sampahK += 1;
    }



    

    
    // Update is called once per frame
    void Update()
    {
        if(remainingTime > 11 && current_sampahK < Banyak_sampah)
        {
            remainingTime -= Time.deltaTime;
            timerText.color = Color.white;
        }
        else if( remainingTime <= 11 && remainingTime > 6 && current_sampahK < Banyak_sampah)
        {
           remainingTime -= Time.deltaTime;
           timerText.color = Color.white;
        }
        else if( remainingTime <= 6 && remainingTime > 0 && current_sampahK < Banyak_sampah)
        {
           remainingTime -= Time.deltaTime;
           timerText.color = Color.red;
        }
        else if( remainingTime <= 0 || current_sampahK >= Banyak_sampah)
        {
            remainingTime = 0;
            changer.ChangeScene("Dining Room");
        }
        
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}",minutes ,seconds);
        CompletionText.text = "Completion:\n " + current_completionK1 +"%";
    }

}

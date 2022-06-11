using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public float timeSpent;
    public Image star1;
    public Image star2;
    public Image star3;
    public Text UITimer;
    private int time1=60;
    private int time2=90;
    private int time3=180;
    public Sprite hollowStar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSpent +=Time.deltaTime;
        if (timeSpent > time1){
            star3.sprite=hollowStar;
        } 
         if (timeSpent > time2){
            star2.sprite=hollowStar;
        } 
         if (timeSpent > time3){
            star1.sprite=hollowStar;
        }
        UITimer.text = timeSpent.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UserInterface : MonoBehaviour
{
    float timeScale;
    public Slider timeScaleSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPlay()
    {
        Debug.Log("play");
        if(Time.timeScale==0)
            Time.timeScale = timeScale;
    }
    public void OnPause()
    {
        Debug.Log("pause");
        if(Time.timeScale!=0)
            timeScale = Time.timeScale;
        Time.timeScale = 0;
    }
    public void OnRestart()
    {
        Debug.Log("restart");
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }
    public void OnTimeScaleChanged()
    {
        float value = timeScaleSlider.value;
        Debug.Log("change time scale");
        Time.timeScale = Mathf.Exp(6 * (value - 0.5f));
    }
    public void OnTimeScaleSetDefault()
    {
        Debug.Log("apply default time scale");
        timeScaleSlider.value = 0.5f;
    }
}

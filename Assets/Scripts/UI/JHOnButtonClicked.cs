﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class JHOnButtonClicked : MonoBehaviour
{
    public static JHOnButtonClicked instance;

    private void Awake()
    {
        instance = this;
    }

    GameObject _Pause;
    GameObject _Clear;
    GameObject _Hint;
    const int MAX_STAGE_BUILD_ID = 6;
    const int MIN_STAGE_BUILD_ID = 2;
    private void Start()
    {
        _Pause = transform.Find("Panels").Find("PausePanel").gameObject;
        _Pause.SetActive(false);
        _Clear = transform.Find("Panels").Find("ClearPanel").gameObject;
        _Hint = transform.Find("Hint").GetChild(0).gameObject;

        if (SceneManager.GetActiveScene().buildIndex >= MAX_STAGE_BUILD_ID)
        {//만약 최대씬 도달하면 next버튼 비활성화
            transform.Find("Panels").Find("ClearPanel").Find("Buttons").Find("Next").gameObject.SetActive(false);
            transform.Find("Panels").Find("PausePanel").Find("Buttons").Find("Next").gameObject.SetActive(false);
        }
        if (SceneManager.GetActiveScene().buildIndex <= MIN_STAGE_BUILD_ID)
        {//만약 최소씬 도달하면 prev버튼 비활성화
            transform.Find("Panels").Find("ClearPanel").Find("Buttons").Find("Prev").gameObject.SetActive(false);
            transform.Find("Panels").Find("PausePanel").Find("Buttons").Find("Prev").gameObject.SetActive(false);

        }
    }

    /// <summary>
    /// 힌트 버튼 
    /// </summary>
    public void OnClick_Hint()
    {
        if (_Hint == null)
        {
            Debug.Log("Error - Hint 패널 어디감?");
        }

        if (_Hint.activeSelf !=true)
        {
            Time.timeScale = 0;
            Debug.Log("is Hint, TimeScale set to " + Time.timeScale.ToString());

            _Hint.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            _Hint.SetActive(false);
        }
        
    }

    /// <summary>
    /// 정지 버튼 
    /// </summary>
    public void OnClick_Pause()
    {
        if (_Pause == null)
        {
            Debug.Log("Error - Pause 패널 어디감?");
        }

        Time.timeScale = 0;
        Debug.Log("is Paused, TimeScale set to " + Time.timeScale.ToString());
        _Pause.SetActive(true);
    }

    /// <summary>
    /// 다시 시작 버튼
    /// </summary>
    public void OnClick_Restart()
    {
        Time.timeScale = 1;
        Debug.Log("is Restarted, TimeScale set to " + Time.timeScale.ToString());
        _Pause.SetActive(false);
        _Clear.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
    }

    /// <summary>
    /// 일시 정지 해제 버튼
    /// </summary>
    public void OnClick_Resume()
    {
        Time.timeScale = 1;
        Debug.Log("is Resumed, TimeScale set to " + Time.timeScale.ToString());
        _Pause.SetActive(false);
    }

    /// <summary>
    /// 스태이지 선택으로 넘어가는 버튼
    /// </summary>
    public void OnClick_SlectStage()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SelectStage");
    }

    /// <summary>
    /// 다음 스태이지 선택 버튼
    /// </summary>
    public void OnClick_NextStage()
    {
        Time.timeScale = 1;
        //다음 씬 있는지 확인해야됨
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// 이전 스태이지 선택 버튼
    /// </summary>
    public void OnClick_PrevStage()
    {
        Time.timeScale = 1;
        //이전 씬 있는지 확인해야됨
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    /// <summary>
    /// 어플 종료
    /// </summary>
    public void OnClick_Quit()
    {
        Application.Quit();
    }
}

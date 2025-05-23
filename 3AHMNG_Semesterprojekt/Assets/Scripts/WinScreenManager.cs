using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject ExitBtn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator StartRoutine()
    {
        yield return null;
        yield return new WaitForSeconds(2);
        ExitBtn.SetActive(true);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Start");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboFeedback : MonoBehaviour
{
    public GameObject FeedbackTXT;
    public static ComboFeedback instance;

    public Sprite perfectTXT;
    public Sprite missTXT;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator PerfectHit(Sprite TXT)
    {
        yield return null;
        int rndX = Random.Range(100, 1800);
        int rndY = Random.Range(100, 1000);
        Vector3 rndPos = new Vector3(rndX, rndY, 0);
        GameObject FeedBackGO = Instantiate(FeedbackTXT, rndPos, Quaternion.identity, transform);
        FeedBackGO.GetComponent<Image>().sprite = TXT;
        FeedBackGO.GetComponent<Image>().SetNativeSize();
        FeedBackGO.transform.localScale = Vector3.one;
        yield return new WaitForSeconds(1);
        Destroy(FeedBackGO);
    }
}

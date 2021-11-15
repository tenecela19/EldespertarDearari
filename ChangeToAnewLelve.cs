using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeToAnewLelve : MonoBehaviour
{
    public string levelname;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(levelname);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

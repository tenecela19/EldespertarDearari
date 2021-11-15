using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalGame : MonoBehaviour
{
    #region Singleton
    private static FinalGame _instance;
    public static FinalGame Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<FinalGame>();
            }

            return _instance;
        }
    }
    #endregion
   public bool FinalGameIN;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("FINAL");
        FinalGameIN = true;
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}

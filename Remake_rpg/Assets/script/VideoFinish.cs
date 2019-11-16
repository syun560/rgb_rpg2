using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoFinish : MonoBehaviour
{
    [SerializeField] VideoPlayer VP;
    // Start is call ed before the first frame update
    float time = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (!VP.isPlaying&& time>10)
        {
            SceneManager.LoadScene("title");
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMAnager : MonoBehaviour
{
    public List<GameObject> list_Player;
    public void CheckWin() 
    {
        int alivecount = 0;
        foreach(GameObject player in list_Player)
        {
            if(player.activeSelf)
            {
                alivecount++;
            }
            if(alivecount<=1)
            {
                Debug.Log("EndGame");
                Invoke(nameof(NewRound), 5f);
            }
        }
    }
    void NewRound() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

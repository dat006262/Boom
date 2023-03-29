using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VatCan : MonoBehaviour
{
  
    public float destruciontime = 1f;
    [Range(0f, 1f)] public float itemspawnchance=0.2f;
    public List<GameObject> listItem;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destruciontime);
    }
    private void OnDestroy()
    {
        if (listItem.Count > 0 && Random.value <= itemspawnchance)
            Instantiate(listItem[Random.Range(0, listItem.Count)], this.transform.position, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

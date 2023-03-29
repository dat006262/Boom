using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public AnimaSprite _Start;
    public AnimaSprite _Middle;
    public AnimaSprite _End;
  
    public void SetActiveAnimation(AnimaSprite Ani) 
    {
        _Start.enabled = _Start == Ani;
        _Middle.enabled = _Middle == Ani;
        _End.enabled = _End == Ani;
    }
    public void SetDirection(Vector2 direc) 
    {
        float truc = Mathf.Atan2(direc.y, direc.x);
        transform.rotation = Quaternion.AngleAxis(truc*Mathf.Rad2Deg, Vector3.forward);
    }
    public void Destroyaftersecond(float second) 
    {
        Destroy(gameObject, second);
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

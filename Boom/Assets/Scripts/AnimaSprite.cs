using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimaSprite : MonoBehaviour
{
    public List<Sprite> _list_sprite;
    public Sprite IdleSprite;
    SpriteRenderer _spriteRenderer;

    public bool loop = true;
    public bool idle = true;
    public float _animationtime=0.1f;   
    private int frame=0;
    // Start is called before the first frame update
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        InvokeRepeating(nameof(NextFarme), _animationtime, _animationtime);
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    void NextFarme() 
    {
        frame++;
        if (loop & frame >= _list_sprite.Count)
            frame = 0;
        if (idle)
            _spriteRenderer.sprite = IdleSprite;
        else if(frame >= 0 && frame < _list_sprite.Count)
        _spriteRenderer.sprite = _list_sprite[frame];
            
    }

    private void OnEnable()
    {
        _spriteRenderer.enabled = true;
    }
    private void OnDisable()
    {
        _spriteRenderer.enabled = false;
    }
}

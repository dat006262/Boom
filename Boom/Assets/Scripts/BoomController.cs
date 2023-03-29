using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BoomController : MonoBehaviour
{
    public GameObject _boomprefabs;
    public float _timeboom = 3f;
    public int _countboom= 1;
    public KeyCode DatBom=KeyCode.Space;

    [Header("Explosion") ]
    public GameObject _explosionprefabs;
    public LayerMask _explosionLayerMask;
    public float _Explosiontime=1f;
    public int _ExplotionRadius = 1;
    private int _remainboom ;

    [Header("VatCan")]
    public Tilemap _tilemap;
    public GameObject _vatcanprefabs;
    private void OnEnable()
    {
        _remainboom = _countboom;
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (_remainboom > 0 && Input.GetKeyDown(DatBom)) 
        { 
            StartCoroutine(PlaceBomp()); 
        }
           
    }
    private IEnumerator PlaceBomp() 
    {
        Vector2 position = this.transform.position;
        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);
        GameObject _newboom = Instantiate<GameObject>(_boomprefabs,position,Quaternion.identity);
        _remainboom--;
        yield return new WaitForSeconds(_timeboom);
        position = _newboom.transform.position;
        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);

        GameObject _explosion = Instantiate<GameObject>(_explosionprefabs, position, Quaternion.identity);
        Explosion scrips = _explosion.GetComponent<Explosion>();
        scrips.SetActiveAnimation(scrips._Start);
        scrips.Destroyaftersecond(_Explosiontime);

        Exploding(position, Vector2.up, _ExplotionRadius);
        Exploding(position, Vector2.down, _ExplotionRadius);
        Exploding(position, Vector2.left, _ExplotionRadius);
        Exploding(position, Vector2.right, _ExplotionRadius);



        Destroy(_newboom);
        _remainboom++;

        
        

    }
    void Exploding(Vector2 position, Vector2 direction, int length)

    {
        if (length <= 0) { return; }

        position += direction;

        if (Physics2D.OverlapBox(position, Vector2.one / 2, 0f, _explosionLayerMask))
        {
            NotungVatCan(position);
            return;
        }

        GameObject _explosion = Instantiate<GameObject>(_explosionprefabs, position, Quaternion.identity);
        Explosion scrips = _explosion.GetComponent<Explosion>();
        scrips.SetActiveAnimation(length>1? scrips._Middle:scrips._End);
        scrips.SetDirection(direction);
        scrips.Destroyaftersecond(_Explosiontime);

        Exploding(position, direction, length - 1);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Boom")) 
        {
            collision.isTrigger = false;
        }
    }

    private void NotungVatCan(Vector2 position) 
    {
        Vector3Int cell = _tilemap.WorldToCell(position);
        TileBase tile = _tilemap.GetTile(cell);

        if(tile!=null)
        {
            Instantiate<GameObject>(_vatcanprefabs,position,Quaternion.identity);

            _tilemap.SetTile(cell,null);
        }    
    }
    public void AddBoom() 
    {
        _countboom ++;
        _remainboom++;

    }
}

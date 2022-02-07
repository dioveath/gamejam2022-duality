using UnityEngine;

public class PositionRendererSorter : MonoBehaviour
{

    [SerializeField]
    private int _sortingOrderBase = 50000;
    [SerializeField]
    private int offset = 0;
    [SerializeField]
    private bool runOnlyOnce = true;

    public int sortingOrder;

    private SpriteRenderer _renderer;

    void Start(){
        _renderer = GetComponent<SpriteRenderer>();
    }

    void LateUpdate(){
        _renderer.sortingOrder = _sortingOrderBase - (int) (transform.position.y * 10) - offset;
        sortingOrder = _renderer.sortingOrder;
        if(runOnlyOnce) Destroy(this);
    }

}

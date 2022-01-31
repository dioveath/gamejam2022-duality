using UnityEngine;

public class PositionRendererSorter : MonoBehaviour
{

    [SerializeField]
    private int _sortingOrderBase = 5000;
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
        _renderer.sortingOrder = Mathf.CeilToInt(_sortingOrderBase - transform.position.y - offset);
        sortingOrder = _renderer.sortingOrder;
        if(runOnlyOnce) Destroy(this);
    }

}

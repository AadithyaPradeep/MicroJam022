
using UnityEngine;


public class TooltipManager : MonoBehaviour
{
    public GameObject tooltip;
    public static TooltipManager instance;
    public GameObject player;
    public float offset;

    public void Awake()
    {
        if(instance != null && instance == this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    private void Start()
    {
        tooltip.gameObject.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        tooltip.transform.position = new Vector2(player.transform.position.x,player.transform.position.y + offset) ;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            tooltip.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tooltip.gameObject.SetActive(false);
        }
    }
  
}

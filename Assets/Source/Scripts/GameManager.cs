using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private bool canDrag = true;
    private int startIndex = 0;

    private int currentIndex;
    [SerializeField] List<GameObject> particleVFXs;
    [SerializeField] private List<Level> levels;
    [SerializeField] private Transform tay;
    
    private int id1 = 0;
    private int id2 = 0;
    private int id3 = 0;
    private int id4 = 0;
    private int id5 = 0;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        currentIndex = startIndex;
        levels[currentIndex].gameObject.SetActive(true);
    }

    public void CheckLevelUp()
    {
        canDrag = false;
        tay.gameObject.SetActive(false);
        /*if (GetCurLevel().gameObjects.Count == 0)
        {
            canDrag = false;
            GameObject explosion = Instantiate(particleVFXs[Random.Range(0,particleVFXs.Count)], transform.position, transform.rotation);
            Destroy(explosion, .75f);
            Invoke(nameof(NextLevel),1.0f);
        }*/
        GameObject explosion = Instantiate(particleVFXs[Random.Range(0,particleVFXs.Count)], transform.position, transform.rotation);
        Destroy(explosion, .75f);
        Invoke(nameof(NextLevel),1.0f);
    }

    void NextLevel()
    {
        levels[currentIndex].gameObject.SetActive(false);
        currentIndex++;
        if (currentIndex >= 3)
        {
            currentIndex = startIndex;
            canDrag = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            levels[currentIndex].gameObject.SetActive(true);
            canDrag = true;
        }
        
    }
    

    void Update()
    {
        if(!canDrag) return;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        if (Input.GetMouseButtonDown(0))
        {
            tay.transform.position = mousePosition;
            tay.gameObject.SetActive(true);
        }

        if (Input.GetMouseButton(0))
        {
            tay.transform.position = mousePosition;
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            tay.gameObject.SetActive(false);
        }
    }
    public Level GetCurLevel()
    {
        return levels[currentIndex];
    }
}
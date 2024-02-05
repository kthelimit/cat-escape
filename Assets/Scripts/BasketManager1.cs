using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BasketManager1 : MonoBehaviour
{
    enum Basket
    {
        Red, Yellow, Blue
    }
    AppleCatchGameDataManager gameDataManager;
    [SerializeField] Basket basket;
    [SerializeField] Image redArrow;
    [SerializeField] Image yellowArrow;
    [SerializeField] Image blueArrow;
    void Start()
    {
        gameDataManager = GameObject.FindAnyObjectByType<AppleCatchGameDataManager>();
        TurnOffAllArrow();
        redArrow.enabled = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction, Color.red, 5);
            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit, 20))
            {
                if (hit.transform.gameObject.name == "Red")
                {
                    basket = Basket.Red;
                    TurnOffAllArrow();
                    redArrow.enabled = true;
                }
                else if (hit.transform.gameObject.name == "Yellow")
                {
                    basket = Basket.Yellow;
                    TurnOffAllArrow();
                    yellowArrow.enabled = true;
                }
                else if (hit.transform.gameObject.name == "Blue")
                {
                    basket = Basket.Blue;
                    TurnOffAllArrow();
                    blueArrow.enabled = true;
                }
                Debug.Log(basket);
            }
        }
    }

    void TurnOffAllArrow()
    {
        redArrow.enabled = false;
        yellowArrow.enabled = false;
        blueArrow.enabled = false;
    }

    public void Regame()
    {

        gameDataManager.appleScore = 100f;
        gameDataManager.leftTimeMax = 60f;
        gameDataManager.bombPenalty = 0.5F;
        gameDataManager.score = 0;
        gameDataManager.appleCount = 0;
        gameDataManager.bombCount = 0;

            switch (basket)
            {
                case Basket.Red:
                gameDataManager.appleScore = 110f;
                    break;
                case Basket.Yellow:
                gameDataManager.leftTimeMax = 70f;
                    break;
                case Basket.Blue:
                gameDataManager.bombPenalty = 0.6F;
                    break;
            }

        
        SceneManager.LoadScene("AppleCatch");
    }
}

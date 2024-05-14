using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private LifeCounter _lifeCounter;
    [SerializeField] private CoinCounter _coinCounter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);

            _coinCounter.AddCoins(1);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            _lifeCounter.DecreaseLife();

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Heart"))
        {
            _lifeCounter.IncreaseLife();

            Destroy(collision.gameObject);
        }
    }
}
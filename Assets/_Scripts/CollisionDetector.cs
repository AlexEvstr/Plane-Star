using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private LifeCounter _lifeCounter;
    [SerializeField] private CoinCounter _coinCounter;

    [SerializeField] private GameObject _enemyExplosion;
    [SerializeField] private GameButton _gameButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            StartCoroutine(ObjectCollision(collision.gameObject));

            _gameButton.PlayCoinSound();

            _coinCounter.AddCoins(1);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            _lifeCounter.DecreaseLife();

            _gameButton.PlayExplosionSound();

            GameObject explosion = Instantiate(_enemyExplosion);
            explosion.transform.position = collision.gameObject.transform.position;
            Destroy(explosion, 0.75f);


            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Heart"))
        {
            _lifeCounter.IncreaseLife();

            _gameButton.PlayHeartSound();

            StartCoroutine(ObjectCollision(collision.gameObject));
        }
    }

    private IEnumerator ObjectCollision(GameObject gameObject)
    {
        gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        Destroy(gameObject, 0.25f);
        while (gameObject != null)
        {
            gameObject.transform.Translate(Vector2.up * Time.deltaTime * 30);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
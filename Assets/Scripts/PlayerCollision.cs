using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    public List<FruitData> fruitList;
    [SerializeField]
    private AudioClip checkpointClip,fruitClip, hitClip;
    private PlayerController playerController;
    private GameManager gameManager;
    private bool isHitted;
    [SerializeField]
    private float waitOnHit=0.5f;
    
    // Use this for initialization
    private void Start()
    {
        gameManager = GameManager.Instance;
        playerController = GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si el jugador entra en contacto con un objeto con el tag "Respawn"
        if (collision.gameObject.CompareTag("Respawn"))
        {
            Checkpoint checkpoint = collision.gameObject.GetComponent<Checkpoint>();
            // Comprobamos si el checkpoint está desactivado.
            if (!checkpoint.isActive)
            {
                // Reproducimos sonido y activamos el checkpoint
                playerController.audioSource.PlayOneShot(checkpointClip);
                gameManager.ActivateCheckpoint(collision.gameObject);
            }
        }
        // Si el jugador entra en contacto con un objeto con el tag "Fruit"
        if (collision.gameObject.CompareTag("Fruit"))
        {
            FruitController fruitController = collision.gameObject.GetComponent<FruitController>();
            Debug.Log(fruitController.fruitType);
            this.CollectFruit(fruitController);
        }
        
        // Si el jugador entra en contacto con un objeto con el tag "Finish"
        if (collision.gameObject.CompareTag("Finish"))
        {
            GameManager.Instance.FinishGame();
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si el jugador entra en contacto con un objeto con el tag "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (isHitted) return;
            StartCoroutine(ManageHit());
        }
    }


    private void CollectFruit(FruitController fruitController)
    {
        foreach (FruitData fruit in fruitList)
        {
            if (fruit.type == fruitController.fruitType)
            {
                fruit.count++;
                fruitController.CollectFruit();
                Debug.Log(fruit.ToString());
            }
        }
    }
    IEnumerator ManageHit()
    {
        isHitted = true;
        
        playerController.animator.SetTrigger("Hit");
        playerController.audioSource.PlayOneShot(hitClip);
        // Desactivamos el rigidbody, para que no le afecten las físicas.
        playerController.rb.Sleep();
        // Esperamos unos segundos.
        yield return new WaitForSeconds(waitOnHit);

        if(playerController.health<=0)
        { 
            playerController.ManageDeath();
        }else
        {
            playerController.health--;
        }
        playerController.rb.WakeUp();
        isHitted = false;
    }

}

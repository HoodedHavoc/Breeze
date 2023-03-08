using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemies : MonoBehaviour
{
    public PlayerFlowerControl player;
    float enemySpeed = 0f;

    private void Awake()
    {
        enemySpeed = OrbSpawner.speedMaster;
        Destroy(gameObject, 7);
    }


    void Update()
    {
        transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);

        transform.Rotate(0, 0, 40 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeadZone"))
        {
            //Debug.Log("hit Dead Zone");
            Destroy(this.gameObject);
        }

        if (other.CompareTag("Player"))
        {
            Debug.Log("Hit player with " + gameObject);
            Kill(other);
            Destroy(gameObject);
            player.dead = true;

            
        }
    }

    void Kill(Collider player)
    {
        PlayerFlowerControl death = player.GetComponent<PlayerFlowerControl>();
        Destroy(death.gameObject);




    }
    
    /*IEnumerator Kill(Collider player)
    {
        PlayerFlowerControl death = player.GetComponent<PlayerFlowerControl>();
        //Destroy(player.gameObject);
        death.gameObject.SetActive(false);
        //player.gameObject.SetActive(false);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eating : MonoBehaviour
{
    public GameObject[] foods;
    private int foodDamage = 1;

    public AudioSource audioSource;
    // private AudioClip hamham;

    private PlayerStats _playerStats;
    private Bcgkky _playerMutluluk;

    // Start is called before the first frame update
    void Start()
    {
        _playerStats = GetComponent<PlayerStats>();
        _playerMutluluk = GetComponent<Bcgkky>();
    }

    // Update is called once per frame
    void Update()
    {

     // Ray ray = new Ray(transform.position, transform.forward);
     // RaycastHit hit;
     //  if (Input.GetKeyDown(KeyCode.E))
     //  {
     //      Debug.Log("num num");
     // 
     //      if (Physics.Raycast(ray, out hit))
     //      {
     //          Debug.Log("Vurulan nesnenin etiketi tanýmlý deðil: " + hit.collider.tag);
     //          Debug.Log("num num cast attým");
     //          foreach (GameObject food in foods)
     //          {
     //              Debug.Log("num num foreach");
     // 
     //              if (hit.collider.CompareTag("Food"))
     //              {
     //                  audioSource.Play();
     //                  Debug.Log("num num2");
     //                  Destroy(hit.collider.gameObject);
     //                  _playerStats.Damage(foodDamage);
     //                  _playerStats.ImproveKorku(1);
     //                  _playerMutluluk.forMutlulukBar.value -= .1f;
     //                 
     // 
     // 
     //              }
     // 
     //              else if (hit.collider.CompareTag("HealthFood"))
     //              {
     //                  audioSource.Play();
     //                  Destroy(hit.collider.gameObject);
     //                  _playerStats.AddHealthFood(1);
     //                  _playerStats.DescreaseKorku(1);
     //                  _playerMutluluk.forMutlulukBar.value += .1f;
     //                  Debug.Log("num num3");
     // 
     //              }
     //          }
     //      }
           
     //  }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            Debug.Log("ye beni bitir beni parçala beni recep");
            if (Input.GetKeyDown(KeyCode.E))
            {
                audioSource.Play();
                Destroy(other.gameObject);
                _playerStats.Damage(foodDamage);
                _playerStats.ImproveKorku(1);
                _playerMutluluk.forMutlulukBar.value -= .1f;
            }
        }
        else if (other.gameObject.CompareTag("HealthFood"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                audioSource.Play();
                Destroy(other.gameObject);
                _playerStats.AddHealthFood(1);
                _playerStats.DescreaseKorku(1);
                _playerMutluluk.forMutlulukBar.value += .1f;
            }
            
        }
    }
}

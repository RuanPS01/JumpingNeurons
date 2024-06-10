using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumperCreatorController : MonoBehaviour
{
    [SerializeField]
    GameObject prefabToCreate;
    [SerializeField]
    GameObject animationToFire;

    [SerializeField]
    AudioSource audioSourceShoot;

    public int limitOfJumpers = 2;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSourceShoot.Play();
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                StartCoroutine(AnimateFire());
                if (hit.collider != null && hit.collider.CompareTag("ValidSurface"))
                {
                    GameObject[] jumpers = GameObject.FindGameObjectsWithTag("Jumper");
                    if (jumpers.Length < limitOfJumpers)
                    {
                        GameObject newPrefab = Instantiate(prefabToCreate, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                        newPrefab.name = "Jumper" + jumpers.Length;
                    } else
                    {
                        Destroy(jumpers[0]);
                        GameObject newPrefab = Instantiate(prefabToCreate, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                        newPrefab.name = "Jumper" + jumpers.Length;
                    }
                }
            }
        }
    }
    private IEnumerator AnimateFire()
    {
        animationToFire.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        animationToFire.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Bonus - make this class a Singleton!

[System.Serializable]
public class BulletPoolManager : MonoBehaviour
{
    public GameObject bullet;

    public int poolAmount = 10;
    //TODO: create a structure to contain a collection of bullets

    private Queue<GameObject> m_bulletQueue = new Queue<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        //bulletController.bulletPoolManager = this;

        // TODO: add a series of bullets to the Bullet Pool
        for (int i = 0; i < poolAmount; i++)
        {
            GameObject bulletCopy = Instantiate(bullet);

            bulletCopy.GetComponent<BulletController>().bulletPoolManager = this;

            bulletCopy.transform.SetParent(this.gameObject.transform);
            bulletCopy.SetActive(false);
            m_bulletQueue.Enqueue(bulletCopy);
        }

        Debug.Log(m_bulletQueue.Count);

    }

    // Update is called once per frame
    void Update()
    {

    }

    //TODO: modify this function to return a bullet from the Pool
    public GameObject GetBullet()
    {
        Debug.Log(m_bulletQueue.Count);
        GameObject bulletCopy = m_bulletQueue.Dequeue();
        bulletCopy.SetActive(true);
        return bulletCopy;

    }

    //TODO: modify this function to reset/return a bullet back to the Pool 
    public void ResetBullet(GameObject bullet)
    {
        Debug.Log(m_bulletQueue.Count);
        bullet.SetActive(false);
        m_bulletQueue.Enqueue(bullet);
    }
}

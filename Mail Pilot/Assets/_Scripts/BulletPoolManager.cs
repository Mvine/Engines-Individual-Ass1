using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletPoolManager : MonoBehaviour
{
    public GameObject bullet;

    public int poolAmount = 10;
    //create a structure to contain a collection of bullets

    private Queue<GameObject> m_bulletQueue = new Queue<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        //bulletController.bulletPoolManager = this;

        //adds a series of bullets to the Bullet Pool
        _BuildBulletPool(poolAmount);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //this function returns a bullet from the pool
    public GameObject GetBullet()
    {
        if (BulletPoolEmpty())
        {
            GameObject bulletCopy = Instantiate(bullet);

            bulletCopy.GetComponent<BulletController>().bulletPoolManager = this;
            bulletCopy.transform.SetParent(this.gameObject.transform);
            bulletCopy.SetActive(true);
            return bulletCopy;
        }
        else
        {
            GameObject bulletCopy = m_bulletQueue.Dequeue();
            bulletCopy.SetActive(true);
            return bulletCopy;
        }
    }

    //this function resets/returns a bullet back to the pool 
    public void ResetBullet(GameObject bullet)
    {
        Debug.Log(m_bulletQueue.Count);
        bullet.SetActive(false);
        m_bulletQueue.Enqueue(bullet);
    }

    public int BulletPoolSize()
    {
        return m_bulletQueue.Count;
    }

    public bool BulletPoolEmpty()
    {
        if (m_bulletQueue.Count == 0)
            return true;
        else
            return false;
    }

    private void _BuildBulletPool(int p_poolAmount)
    {
        for (int i = 0; i < p_poolAmount; i++)
        {
            GameObject bulletCopy = Instantiate(bullet);

            bulletCopy.GetComponent<BulletController>().bulletPoolManager = this;

            bulletCopy.transform.SetParent(this.gameObject.transform);
            bulletCopy.SetActive(false);
            m_bulletQueue.Enqueue(bulletCopy);
        }
    }

}

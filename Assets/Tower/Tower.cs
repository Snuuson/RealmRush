using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] int cost = 75;
    [SerializeField] float refundPercent = 0.5f;
    
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CreateTower(Tower tower,Vector3 position) 
    {
        Audio audio = FindObjectOfType<Audio>();
        
        Bank bank = FindObjectOfType<Bank>();
        if (bank == null) 
        {
            return false;
        }
        if (bank.CurrentBalance >= cost)
        {
            bank.Withdraw(cost);
            Instantiate(tower.gameObject, position, Quaternion.identity);
            return true;
        }
        else 
        {
            //Play Sound 
            audio.PlayNotEnoughMinerals();
            
        }

        return false;
        
    }

   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    BuildManager buildManager;
    public Blueprints Turret1;
    public Blueprints Turret2;
    public Blueprints Turret3;
    public Blueprints Turret4;
    public Blueprints Turret5;
    public Blueprints Turret6;
    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectTurret1()
    {
        Debug.Log("1");
        buildManager.SelectTurretToBuild(Turret1);
        FindObjectOfType<AudioManager>().Play("MenuButton");
    }
    public void PurchaseTurret2()
    {
        Debug.Log("2");
        buildManager.SelectTurretToBuild(Turret2);
        FindObjectOfType<AudioManager>().Play("MenuButton");
    }
    public void PurchaseTurret3()
    {
        Debug.Log("3");
        buildManager.SelectTurretToBuild(Turret3);
        FindObjectOfType<AudioManager>().Play("MenuButton");
    }
    public void PurchaseTurret4()
    {
        Debug.Log("4");
        buildManager.SelectTurretToBuild(Turret4);
        FindObjectOfType<AudioManager>().Play("MenuButton");
    }
    public void PurchaseTurret5()
    {
        Debug.Log("5");
        buildManager.SelectTurretToBuild(Turret5);
        FindObjectOfType<AudioManager>().Play("MenuButton");
    }
    public void PurchaseTurret6()
    {
        Debug.Log("6");
        buildManager.SelectTurretToBuild(Turret6);
        FindObjectOfType<AudioManager>().Play("MenuButton");
    }
    public void PurchaseAnotherTurret()
    {
        Debug.Log("Standard Turret Purchased");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        instance = this;
    }

    private Blueprints turretToBuild;


    public GameObject Turret1Prefab;
    public GameObject Turret2Prefab;
    public GameObject Turret3Prefab;
    public GameObject Turret4Prefab;
    public GameObject Turret5Prefab;
    

    public bool CanBuild { get { return turretToBuild != null; } }

    public void BuildTurretOn(Node node)
    {
        if (Money.Points < turretToBuild.cost)
        {
            Debug.Log("not enough money");
            return;
        }
        Money.Points -= turretToBuild.cost;
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.transform.position + node.offset, Quaternion.identity);
        node.turret = turret;
        FindObjectOfType<AudioManager>().Play("TurretPlaced");
        Debug.Log("Turret Built");
    }
    public void SelectTurretToBuild(Blueprints turret) {
        turretToBuild = turret;
    }

}

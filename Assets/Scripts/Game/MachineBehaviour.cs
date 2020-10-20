using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineBehaviour : MonoBehaviour
{
    public GameObject SodaPrefab;

    public float ExplosionForce = 20f;
    public float ExplosionRadius = 2f;

    private VendingMachineContext context;

    private WindowController windowController;

    void Start()
    {
        context = new VendingMachineContext();
        windowController = FindObjectOfType<WindowController>();
        windowController.MachineContext = context;

        windowController.Btn_AddCocaCola.onClick.AddListener(() =>
        {
            context.AddRefri();
            windowController.UpdateTexts();
        });

        windowController.Btn_AddCredit.onClick.AddListener(() =>
        {
            context.AddCredit();
            windowController.UpdateTexts();
        });

        windowController.Btn_BuyCocaCola.onClick.AddListener(() =>
        {
            BuyRefri();
        });
    }

    public void BuyRefri()
    {
        bool success = context.BuyRefri();

        if (success)
        {
            InstantiateRefri();
        }

        windowController.UpdateTexts();
    }

    public void InstantiateRefri()
    {
        GameObject _object = GameObject.Instantiate(SodaPrefab);
        Rigidbody rigid = _object.GetComponent<Rigidbody>();
        rigid.AddExplosionForce(20f, transform.position, 2f);
    }
}

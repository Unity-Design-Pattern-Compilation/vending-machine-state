using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WindowController : MonoBehaviour
{

    [SerializeField] private GameObject AdminContainer;
    [SerializeField] private GameObject UserContainer;

    public Button Btn_AddCocaCola;
    public Button Btn_AddCredit;
    public Button Btn_BuyCocaCola;
    [SerializeField] private TextMeshProUGUI Text_Credits;
    [SerializeField] private TextMeshProUGUI Text_RefriQntd;
    [SerializeField] private TextMeshProUGUI Text_Message;

    public string CreditsText {
        get {
            return $"{MachineContext.Credits}$";
        }
    }

    public string RefriText {
        get {
            return $"{MachineContext.Soda}x";
        }
    }

    public string MessageText {
        get {
            return $"{MachineContext.Message}";
        }
    }

    public VendingMachineContext MachineContext;

    public void UpdateTexts()
    {
        Text_Credits.text = CreditsText;
        Text_RefriQntd.text = RefriText;
        Text_Message.text = MessageText;
    }

    public void SwitchWindow()
    {
        UserContainer.SetActive(!UserContainer.activeInHierarchy);
        AdminContainer.SetActive(!AdminContainer.activeInHierarchy);
    }
}

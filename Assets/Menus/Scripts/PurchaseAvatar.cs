using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;
using System.Collections.Generic;

public class PurchaseAvatar : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    public int cost;
    public int amount;
    private Text costText;
    private Text amountText;
    private Bank bank;
    private Inventory inventory;
    private VishnuStateController.Avatar avatarEnum;
    private string avatarString;
    Dictionary<VishnuStateController.Avatar, AvatarPassiveStats> avatarPassives;

    private GameObject statLaunch;
    private GameObject statBounce;
    private GameObject statAir;
    private GameObject statObs;
    private GameObject statMagnet;
    private GameObject activeDesc;
    
    private float timeToUpdate = 0;
    private float updateIntMs = 0.200f;
   
    struct AvatarPassiveStats {
        public GameObject textGO;
        public string stat1;
        public string stat2;
        public string desc;

        public AvatarPassiveStats(GameObject value0, string value1, string value2, string value3) {
            textGO = value0;
            stat1 = value1;
            stat2 = value2;
            desc = value3;
        }
    }

    void Start() {
        statLaunch = GameObject.Find("StatLaunch");
        statBounce = GameObject.Find("StatBounce");
        statAir = GameObject.Find("StatAir");
        statObs = GameObject.Find("StatObs");
        statMagnet = GameObject.Find("StatMagnet");
        activeDesc = GameObject.Find("ActiveDescription");
        avatarPassives = new Dictionary<VishnuStateController.Avatar, AvatarPassiveStats>();
        avatarPassives[VishnuStateController.Avatar.MATSYA] = new AvatarPassiveStats(statBounce, "StatBounce", "StatObs", "Birds carry you");
        avatarPassives[VishnuStateController.Avatar.KURMA] = new AvatarPassiveStats(statAir, "StatAir", "StatObs", "Prevents momentum loss");
        avatarPassives[VishnuStateController.Avatar.VARAHA] = new AvatarPassiveStats(statLaunch, "StatLaunch", "StatObs", "Runs on the ground and jumps at the end");
        avatarPassives[VishnuStateController.Avatar.NARASIMHA] = new AvatarPassiveStats(statBounce, "StatBounce", "StatMagnet", "Eats animals for power");
        avatarPassives[VishnuStateController.Avatar.VAMANA] = new AvatarPassiveStats(statBounce, "StatBounce", "StatAir", "Floats with umbrella");
        avatarPassives[VishnuStateController.Avatar.PARASHURAMA] = new AvatarPassiveStats(statLaunch, "StatLaunch", "StatMagnet", "Dives down with attack");
        avatarPassives[VishnuStateController.Avatar.RAMA] = new AvatarPassiveStats(statMagnet, "StatMagnet", "StatObs", "Jumps upward");
        avatarPassives[VishnuStateController.Avatar.KRISHNA] = new AvatarPassiveStats(statLaunch, "StatLaunch", "StatAir", "Increase money gained");
        avatarPassives[VishnuStateController.Avatar.BUDDHA] = new AvatarPassiveStats(statLaunch, "StatLaunch", "StatBounce", "Big bounce");
        avatarPassives[VishnuStateController.Avatar.KALKI] = new AvatarPassiveStats(statLaunch, "", "", "The FINAL FORM!");
        avatarString = transform.FindChild("Avatar").GetComponent<Text>().text;
        avatarEnum = Utilities.EnumUtils<VishnuStateController.Avatar>.StringToEnum(avatarString.ToUpper());
        inventory = GameObject.Find("Singletons").GetComponent<Inventory>();
        bank = GameObject.Find("Singletons").GetComponent<Bank>();
        try {
            amount = inventory.GetAvatarInventory(avatarEnum);
        } catch (Exception e) {
            Debug.Log(e.ToString());
            Debug.Log(avatarEnum);
        }
        UpdateCost();

        costText = transform.FindChild("Cost").GetComponent<Text>();
        amountText = transform.FindChild("Amount").GetComponent<Text>();
    }

    void LateUpdate() {
        if(Time.time > timeToUpdate) {
            timeToUpdate = Time.time + updateIntMs; //no need to update text values at 120fps
            if (cost == 0)
        	    costText.text = @"";
        	else
        	    costText.text = string.Format(@"${0}", cost);

        	amountText.text = string.Format(@"{0}", amount);
        	UpdateStats();
        }
    }

    private void UpdateStats() {
        statLaunch.GetComponent<Text>().text = @"Launch power: " + VishnuStateController.instance.GetLaunchPower().ToString();
        statBounce.GetComponent<Text>().text = @"Bounce: " + VishnuStateController.instance.GetBounciness().ToString();
        statAir.GetComponent<Text>().text = @"Air resistance: " + VishnuStateController.instance.GetDrag().ToString();
        statObs.GetComponent<Text>().text = @"Obstacle resistance: " + VishnuStateController.instance.GetMass().ToString();
        statMagnet.GetComponent<Text>().text = @"Rupee multiplier: +" + (VishnuStateController.instance.GetMoneyGain() * 10).ToString() + "%";
    }

    private void UpdateCost() {
        switch (avatarEnum) {
            case VishnuStateController.Avatar.KALKI:
                cost = 10000;
                break;
            default:
                cost = (amount + 1) * (amount + 2) * 25;
                if (cost > 1000)
                    cost = 1000;
                break;
        }
        if (inventory.GetAvatarInventory(avatarEnum) == 10)
            cost = 0;
        UpdateStats();
    }

    public void Purchase() {
        if (bank.TotalMoney > cost && amount < 10 && cost > 0) {
            bank.Subtract(cost);
            inventory.IncrementAvatar(avatarEnum);
            amount = inventory.GetAvatarInventory(avatarEnum);
            VishnuStateController.instance.updateAvatars(inventory.GetAvatarsInInventory());
            UpdateCost();
        }
    }

    public void OnPointerEnter(PointerEventData dataName) {
        Debug.Log("Im in " + gameObject.name);
        VishnuStateController.Avatar avatarHover = Utilities.EnumUtils<VishnuStateController.Avatar>.StringToEnum(gameObject.name.ToUpper());
        try {
            activeDesc.GetComponent<Text>().text = "Description\n" + avatarPassives[avatarHover].desc;
            activeDesc.GetComponent<Text>().color = Color.cyan;
            transform.FindChild("Avatar").GetComponent<Text>().color = Color.cyan;
            //not sure what this is supposed to highlight??
            HighlightPower(avatarPassives[avatarHover].textGO, avatarPassives[avatarHover].stat1, Color.cyan);
            HighlightPower(avatarPassives[avatarHover].textGO, avatarPassives[avatarHover].stat2, Color.cyan);
        } catch (Exception) {
            Debug.Log("Exception in " + gameObject.name);
        }
        if (avatarEnum == VishnuStateController.Avatar.KALKI) {
            HighlightPower(statLaunch, "StatLaunch", Color.cyan);
            HighlightPower(statBounce, "StatBounce", Color.cyan);
            HighlightPower(statAir, "StatAir", Color.cyan);
            HighlightPower(statObs, "StatObs", Color.cyan);
            HighlightPower(statMagnet, "StatMagnet", Color.cyan);
        }
    }

    public void OnPointerExit(PointerEventData dataName) {
        Debug.Log("Exiting " + gameObject.name);
        activeDesc.GetComponent<Text>().text = "Description";
        activeDesc.GetComponent<Text>().color = Color.black;
        HighlightPower(statLaunch, "StatLaunch", Color.black);
        HighlightPower(statBounce, "StatBounce", Color.black);
        HighlightPower(statAir, "StatAir", Color.black);
        HighlightPower(statObs, "StatObs", Color.black);
        HighlightPower(statMagnet, "StatMagnet", Color.black);
        transform.FindChild("Avatar").GetComponent<Text>().color = Color.black;
    }

    private void HighlightPower(GameObject textGO, string stat, Color color) {
        textGO.GetComponent<Text>().color = color;
    }

}

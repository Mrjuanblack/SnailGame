using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeItem : MonoBehaviour
{
    public TextMeshProUGUI upgradeName;
    public TextMeshProUGUI upgradeDescription;
    public Button buyButton;
    public TextMeshProUGUI buyText;
    public TextMeshProUGUI upgradeEffectText;

    public void Setup(int newGenIndex, UpgradeItem upgradeItem, Snail snail, BaseGenerator baseGenerator)
    {
        upgradeItem.upgradeName.text = baseGenerator.Name;
        upgradeItem.upgradeDescription.text = baseGenerator.Description;

        upgradeItem.buyText.text = $"Buy {baseGenerator.GetCurrentCost():0.00}";

        upgradeItem.upgradeEffectText.text = (baseGenerator as IGenerator).GetEffectText();

        upgradeItem.buyButton.onClick.AddListener(() =>
        {
            if (snail.GetFood() >= baseGenerator.GetCurrentCost())
            {
                snail.UpdateFoodAmount(snail.GetFood() - baseGenerator.GetCurrentCost());
                var updatedGen = baseGenerator;
                updatedGen.AddGenerator(1);
                upgradeItem.upgradeEffectText.text = (updatedGen as IGenerator).GetEffectText();
                upgradeItem.buyText.text = $"Buy {updatedGen.GetCurrentCost():0.00}";

                baseGenerator = updatedGen;
            }
        });
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierShootableYear : ModifierBase
{
    [SerializeField] private int yearToAdd = 2;
    [SerializeField] private ModifierView modifierView;

    private void Start()
    {
        var isPositive = yearToAdd > 0;
        modifierView.SetVisuals(isPositive, yearToAdd);
    }

    public override void Modify(PlayerController playerController)
    {
        var playerCrowd = playerController.GetComponent<PlayerCrowd>();
        playerCrowd.AddYearToCrowd(yearToAdd);
    }
}
using BepInEx;
using Utilla;
using HarmonyLib;
using GorillaNetworking;
using UnityEngine;

[BepInPlugin("com.yourname.modmenu", "Your Mod Menu", "1.0.0")]
[ModdedGamemode]
public class YourModMenu : BaseUnityPlugin
{
    Harmony harmony;

    public static bool unlockCosmetics = true; // Optional toggle

    void Awake()
    {
        harmony = new Harmony("com.yourname.modmenu");
        harmony.PatchAll();
        Debug.Log("[YourModMenu] Harmony patches applied.");
    }

    void OnDestroy()
    {
        harmony.UnpatchSelf();
    }

    [HarmonyPatch(typeof(GorillaNetworking.CosmeticsController), "GetUserCosmeticsAllowed")]
    class Patch_GetUserCosmeticsAllowed
    {
        static void Postfix(ref bool __result)
        {
            if (unlockCosmetics)
            {
                __result = true;
                Debug.Log("[YourModMenu] Cosmetics unlocked.");
            }
        }
    }
}
// sorry, my commits seem like they replace every line, because im lazy

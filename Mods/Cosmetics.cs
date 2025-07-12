using BepInEx;
using Utilla;
using HarmonyLib;
using GorillaNetworking;

[BepInPlugin("com.yourname.modmenu", "Your Mod Menu", "1.0.0")]
[ModdedGamemode]
public class YourModMenu : BaseUnityPlugin
{
    Harmony harmony;

    void Awake()
    {
        harmony = new Harmony("com.yourname.modmenu");
        harmony.PatchAll(); // This will auto-apply your patches below
    }

    void OnDestroy()
    {
        harmony.UnpatchSelf();
    }

    // Cosmetic Unlock Patch
    [HarmonyPatch(typeof(CosmeticsController), "GetUserCosmeticsAllowed")]
    class Patch_GetUserCosmeticsAllowed
    {
        static void Postfix(ref bool __result)
        {
            __result = true;
        }
    }
}

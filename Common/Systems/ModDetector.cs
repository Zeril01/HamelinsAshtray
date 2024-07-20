namespace HamelinsAshtray.Common.Systems
{
    internal class ModDetector : ModSystem
    {
        public static bool calamityIsEnabled, wayfairIsEnabled;

        public override void PostSetupContent()
        {
            calamityIsEnabled = ModLoader.TryGetMod("CalamityMod", out _);
            wayfairIsEnabled = ModLoader.TryGetMod("WAYFAIRContent", out _);
        }
    }
}

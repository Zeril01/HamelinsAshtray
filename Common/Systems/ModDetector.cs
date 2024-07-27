namespace HamelinsAshtray.Common.Systems
{
    class ModDetector : ModSystem
    {
        public static bool calamityIsEnabled;

        public override void PostSetupContent() => calamityIsEnabled = ModLoader.TryGetMod("CalamityMod", out _);
    }
}

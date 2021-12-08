namespace ProSwapperValorant
{
    public static class Loadout
    {

        public static bool SetLoadout(ValorantAPI.RiotClientAPI.RiotJsonStructs.Loadout.Root value)
        {
                Config.SaveConfig();
                return Main.riotClient.SetPlayerLoadout(value);
        }

    }
}

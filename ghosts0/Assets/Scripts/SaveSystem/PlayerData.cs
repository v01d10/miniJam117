[System.Serializable]
public class PlayerData
{
    public float PlayerMaxHealth;
    public float PlayerLevel;
    public float PlayerExp;
    public float PlayerExpNeeded;
    public float PlayerAtPoints;
    public float PlayerEndurance;
    public float PlayerSpeed;

    public float Money;
    public float Ectoplasm;
    public float Bullets;

    public int NightsSurvived;
    public int TotalEnemiesKilled;
    public int CurrentWave;


    public void SavePlayerData(PlayerLevels player, ResourceManager res, StatManager stats, EnemySpawner spawner)
    {
        PlayerMaxHealth = player.MaxHealth;
        PlayerLevel = player.Lvl;
        PlayerExp = player.Exp;
        PlayerExpNeeded = player.ExpNeeded;
        PlayerAtPoints = player.AtPoints;
        PlayerEndurance = player.Endurance;
        PlayerSpeed = player.Speed;

        Money = res.Money;
        Ectoplasm = res.Ectoplasm;
        Bullets = res.Bullets;

        NightsSurvived = stats.survivedNights;
        TotalEnemiesKilled = stats.enemiesKilled;
        CurrentWave = spawner.currWave;
    }

}

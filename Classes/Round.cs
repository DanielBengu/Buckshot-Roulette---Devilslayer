namespace Buckshot_Roulette_Devilslayer.Classes
{
    public class Round(int startingLife)
    {
        public int PlayerLife { get; set; } = startingLife;
        public int DealerLife { get; set; } = startingLife;

        public bool[] ShotgunShells { get; set; } = [];

        public void DealDamage(bool damagePlayer, bool deal2)
        {
            int damageToDeal = deal2 ? 2 : 1;

            if (damagePlayer)
                PlayerLife -= damageToDeal;
            else
                DealerLife -= damageToDeal;
        }

        public void Heal(bool healPlayer)
        {
            if (healPlayer)
                PlayerLife++;
            else
                DealerLife++;
        }

        public void ReloadShotgun(int liveRounds, int blankRounds)
        {
            int maxCapacity = liveRounds + blankRounds;
            ShotgunShells = new bool[maxCapacity];

            for (int i = 0; i < liveRounds; i++)
            {
                ShotgunShells[i] = true;
            }

            for (int i = liveRounds; i < maxCapacity; i++)
            {
                ShotgunShells[i] = false;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner
{
    public GameObject Fireball { get; set; }
    public float TimeToNextSpawn { get; set; }

    public Spawner(GameObject fireball, float timeToNextSpawn)
    {
        Fireball = fireball;
        TimeToNextSpawn = timeToNextSpawn;
    }
}

public class Round
{
    public int RoundNumber { get; set; }
    public List<Spawner> Fireballs { get; set; }

    public Round(int roundNumber, List<Spawner> fireballs)
    {
        RoundNumber = roundNumber;
        Fireballs = fireballs;
    }
}

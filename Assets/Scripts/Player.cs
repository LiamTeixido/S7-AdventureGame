using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance;

    public static Player Instance => instance;

    public event Action<int> OnHealthChange = (value) => { };

    public new string name;
    public int strength;
    public int dexterity;
    public int health;

    public string PlayerName => name;
    public int Strength => strength;
    public int Dexterity => dexterity;
    public int Health => health;

    private void Awake()
    {
        instance = this;
    }

    public void CreatePlayer(string name, int strength, int dexterity, int remainingPoints, int health)
    {
        this.name = name;
        this.strength = strength;
        this.dexterity = dexterity;
        this.health = 100 - (strength + dexterity);
    }

    public void ChangeHealth(int value)
    {
        health += value;
        OnHealthChange?.Invoke(health);
    }

    public string GetStats()
    {
        return $"Nombre: {name}\nFuerza: {Strength}\nDestreza: {dexterity}\nVida: {health}";
    }
}

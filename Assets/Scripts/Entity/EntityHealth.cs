using System;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    private int _health;
    private bool _isDead;

    private Action _onDeath;
    public event Action OnDeath
    {
        add => _onDeath += value;
        remove => _onDeath -= value;
    }
    public int Health => _health;
    private void Awake() => Heal(_maxHealth);
    public void Damage(int damage) => ChangeHealth(-damage);
    public void Heal(int heal) => ChangeHealth(heal);
    private void ChangeHealth(int value)
    {
        if (_isDead)
            return;

        _health = Mathf.Clamp(_health + value, 0, _maxHealth);

        if (_health == 0)
            Die();
    }
    private void Die()
    {
        _isDead = true;
        _onDeath?.Invoke();
    }
}

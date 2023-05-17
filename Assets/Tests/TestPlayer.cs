using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;

public class TestPlayer
{

    private GameObject gameObject;
    private Player player;
    private SpriteRenderer graphics;
    private HealthBar healthBar;
    private Slider slider;
    private Gradient gradient;
    private Image fill;

    [SetUp]
    public void Setup()
    {
        gameObject= new GameObject();
        player = gameObject.AddComponent<Player>();
        graphics = gameObject.AddComponent<SpriteRenderer>();
        player.graphics = graphics;
        healthBar = gameObject.AddComponent<HealthBar>();
        slider = gameObject.AddComponent<Slider>();
        gradient = new Gradient();
        fill = gameObject.AddComponent<Image>();
        healthBar.slider = slider;
        healthBar.gradient = gradient;
        healthBar.fill = fill;
        player.healthBar = healthBar;
    }
    [TearDown]
    public void TearDown()
    {
        gameObject= null;
        player = null;
        healthBar = null;
        graphics = null;
        slider = null;
        gradient = null;
        fill = null;
    }
    [UnityTest]
    public IEnumerator invincibilityFlash()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
    
    [Test]
    public void TakeDamage1()
    {
        
        // Arrange
        player.healthBar = healthBar;
        player.currentHealth = 100;
        int initialHealth = player.currentHealth;
        int damage = 20;

        // Act
        player.TakeDamage(damage);

        // Assert
        //Assert.AreEqual(initialHealth - damage, player.currentHealth);
        Assert.AreEqual(initialHealth-damage, player.currentHealth);
    }
    

    
}


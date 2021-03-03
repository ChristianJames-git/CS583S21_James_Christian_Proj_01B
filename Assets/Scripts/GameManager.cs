using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerStats playerStats;
    public List<Race> raceList = new List<Race>();
    public List<Class> classList = new List<Class>();
    public bool rolledCharacter = false;
    public static GameManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else { Destroy(gameObject); }
        // Cache references to all desired variables
        playerStats = FindObjectOfType<PlayerStats>();
    }

    private void Start()
    {
        //change race speeds
        raceList.Add(new Race() { raceName = "Dragonborn", raceSummary = "Your draconic heritage manifests in a variety of traits you share with other dragonborn.", raceSpeeds = new List<float>() { 30, 60, 5 } });
        raceList.Add(new Race() { raceName = "Dwarf", raceSummary = "Your dwarf character has an assortment of in abilities, part and parcel of dwarven nature.", raceSpeeds = new List<float>() { 25, 50, 5 } });
        raceList.Add(new Race() { raceName = "Elf", raceSummary = "Your elf character has a variety of natural abilities, the result of thousands of years of elven refinement.", raceSpeeds = new List<float>() { 30, 60, 5 } });
        raceList.Add(new Race() { raceName = "Gnome", raceSummary = "Your gnome character has certain characteristics in common with all other gnomes.", raceSpeeds = new List<float>() { 25, 50, 5 } });
        raceList.Add(new Race() { raceName = "Half-Elf", raceSummary = "Your half-elf character has some qualities in common with elves and some that are unique to half-elves.", raceSpeeds = new List<float>() { 30, 60, 5 } });
        raceList.Add(new Race() { raceName = "Half-Orc", raceSummary = "Your half - orc character has certain traits deriving from your orc ancestry.", raceSpeeds = new List<float>() { 30, 60, 5 } });
        raceList.Add(new Race() { raceName = "Halfling", raceSummary = "Your halfling character has a number of traits in common with all other halflings.", raceSpeeds = new List<float>() { 25, 50, 5 } });
        raceList.Add(new Race() { raceName = "Human", raceSummary = "It's hard to make generalizations about humans, but your human character has these traits.", raceSpeeds = new List<float>() { 30, 60, 5 } });
        raceList.Add(new Race() { raceName = "Tiefling", raceSummary = "Tieflings share certain racial traits as a result of their infernal descent.", raceSpeeds = new List<float>() { 30, 60, 5 } });
        classList.Add(new Class() { className = "Barbarian", classSummary = "In battle, you fight with primal ferocity. For some barbarians, rage is a means to an end–that end being violence.", classMainStats = "Strenth", hitDie = 12 });
        classList.Add(new Class() { className = "Bard", classSummary = "Whether singing folk ballads in taverns or elaborate compositions in royal courts, bards use their gifts to hold audiences spellbound.", classMainStats = "Charisma", hitDie = 8 });
        classList.Add(new Class() { className = "Cleric", classSummary = "Clerics act as conduits of divine power.", classMainStats = "Wisdom", hitDie = 8 });
        classList.Add(new Class() { className = "Druid", classSummary = "Druids venerate the forces of nature themselves. Druids holds certain plants and animals to be sacred, and most druids are devoted to one of the many nature deities.", classMainStats = "Wisdom", hitDie = 10 });
        classList.Add(new Class() { className = "Fighter", classSummary = "Different fighters choose different approaches to perfecting their fighting prowess, but they all end up perfecting it.", classMainStats = "Strength or Dexterity", hitDie = 10 });
        classList.Add(new Class() { className = "Monk", classSummary = "Coming from monasteries, monks are masters of martial arts combat and meditators with the ki living forces.", classMainStats = "Dexterity", hitDie = 8 });
        classList.Add(new Class() { className = "Paladin", classSummary = "Paladins are the ideal of the knight in shining armor; they uphold ideals of justice, virtue, and order and use righteous might to meet their ends.", classMainStats = "Strenth", hitDie = 10 });
        classList.Add(new Class() { className = "Ranger", classSummary = "Acting as a bulwark between civilization and the terrors of the wilderness, rangers study, track, and hunt their favored enemies.", classMainStats = "Dexterity", hitDie = 10 });
        classList.Add(new Class() { className = "Rogue", classSummary = "Rogues have many features in common, including their emphasis on perfecting their skills, their precise and deadly approach to combat, and their increasingly quick reflexes.", classMainStats = "Dexterity", hitDie = 8 });
        classList.Add(new Class() { className = "Sorcerer", classSummary = "An event in your past, or in the life of a parent or ancestor, left an indelible mark on you, infusing you with arcane magic. As a sorcerer the power of your magic relies on your ability to project your will into the world.", classMainStats = "Charisma", hitDie = 6 });
        classList.Add(new Class() { className = "Warlock", classSummary = "You struck a bargain with an otherworldly being of your choice: the Archfey, the Fiend, or the Great Old One who has imbued you with mystical powers, granted you knowledge of occult lore, bestowed arcane research and magic on you and thus has given you facility with spells.", classMainStats = "Charisma", hitDie = 8 });
        classList.Add(new Class() { className = "Wizard", classSummary = "The study of wizardry is ancient, stretching back to the earliest mortal discoveries of magic. As a student of arcane magic, you have a spellbook containing spells that show glimmerings of your true power which is a catalyst for your mastery over certain spells.", classMainStats = "Intelligence", hitDie = 6 });
        playerStats.currentXP = 0;
        playerStats.maxXP = 300;
        playerStats.armorClass = 23;
    }
}

public class Race
{
    public string raceName { get; set; }
    public string raceSummary { get; set; }
    public List<float> raceSpeeds { get; set; }
}
public class Class
{
    public string className { get; set; }
    public string classSummary { get; set; }
    public string classMainStats { get; set; }
    public int hitDie { get; set; }
}

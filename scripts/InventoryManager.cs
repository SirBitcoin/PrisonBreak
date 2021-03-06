﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
	public static InventoryManager instance;

	//properties
	public int weightLimit = 20;
	public int currentWeight = 0;
	List<Item> inventory;

	void Awake()
	{
		if(instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
			inventory = new List<Item>();
		}
		else
		{
			Destroy(gameObject);
		}
	}

	//methods
	void Start () {

	}

	void Update () {
		
	}

	public bool AddItem(Item item)
	{
		if(currentWeight + item.weight <= weightLimit)
		{
			inventory.Add(item);
			currentWeight += item.weight;
			return true;
		}

		return false;
	}

	public bool RemoveItem(Item item)
	{
		
		bool success = inventory.Remove(item);

		if(success)
		{
			currentWeight -= item.weight;
		}

		return success;
	}

	public void PrintToConsole()
	{
		Debug.Log(inventory.Count + " items on the inventory");

		for(int i=0; i<inventory.Count; i++)
		{
			Debug.Log("The first item is called: " + inventory[i].name);
		}
	}
}

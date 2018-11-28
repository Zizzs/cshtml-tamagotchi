using System.Collections.Generic;
using System;

namespace Tamagotchi.Models
{
    public class Item
    {
        private string _name;
        private int _food;
        private int _sleep;
        private int _happiness;
        private bool _life;
        private int _id;

        private static List<Item> _instances = new List<Item> { };

        public Item(string name)
        {
            _name = name;
            _food = 10;
            _sleep = 10;
            _happiness = 10;
            _life = true;
            _instances.Add(this);
            _id = _instances.Count;
        }

        public string GetName()
        {
            return _name;
        }

        public int GetFood()
        {
            return _food;
        }

        public int GetSleep()
        {
            return _sleep;
        }

        public int GetHappiness()
        {
            return _happiness;
        }

        public bool GetLife()
        {
            return _life;
        }

        public int GetId()
        {
            return _id;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public void SetFood(int food)
        {
            _food = food;
        }

        public void SetSleep(int sleep)
        {
            _sleep = sleep;
        }

        public void SetHappiness(int happiness)
        {
            _happiness = happiness;
        }

        public void SetLife(bool life)
        {
            _life = life;
        }

        public void SetId(int id)
        {
            _id = id;
        }

        public static List<Item> GetAll()
        {
            return _instances;
        }

        public static void ClearAll()
        {
            _instances.Clear();
        }

        public static Item Find(int searchId)
        {
            return _instances[searchId - 1];
        }

    }
}
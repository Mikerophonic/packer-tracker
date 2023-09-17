using System.Collections.Generic;
using System.Linq;

namespace PackerTracker.Models
{
    public class Gear
    {
        public string Description { get; set; }
        public int Id { get; private set; }
        private static List<Gear> _instances = new List<Gear> { };
        public bool IsChecked { get; set; }

        public Gear(string description)
        {
            Description = description;
            _instances.Add(this);
            Id = _instances.Count;
        }

        public static List<Gear> GetAll()
        {
        return _instances;
        }

        public static void ClearAll()
        {
        _instances.Clear();
        }

        public static Gear Find(int searchId)
        {
          return _instances.FirstOrDefault(g => g.Id == searchId);
        }

        public static void Remove(Gear gear)
        {
            _instances.Remove(gear);
        }


    }
}
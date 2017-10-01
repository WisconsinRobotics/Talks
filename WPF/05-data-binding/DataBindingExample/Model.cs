using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingExample
{
    /// <summary>
    /// This is a generic "Model" class. Think of this class as being responsible
    /// for your business data only. It performs actions on your data, but has no 
    /// responsibilities or relationship to the UI.
    /// 
    /// The following properties are arbitrary. Feel free to add more!
    /// Just make sure you update the constructor & ToString() as well!
    /// </summary>
    public class Model
    {
        public Model(string name, int value, List<string> foods)
        {
            Name = name;
            Value = value;
            FavoriteFoods = foods;
        }

        public string Name
        {
            get; set;
        }

        public int Value
        {
            get; set;
        }

        public List<string> FavoriteFoods
        {
            get; set;
        }

        public override string ToString()
        {
            var dict = new Dictionary<string, string>();
            dict["Name"] = Name;
            dict["Value"] = Value.ToString();
            dict["FavoriteFoods"] = string.Join(", ", FavoriteFoods.ToArray());

            StringBuilder sb = new StringBuilder();
            foreach (var pair in dict)
                sb.Append(string.Format("{0}: {1}, ", pair.Key, pair.Value));

            return sb.ToString();
        }
    }
}

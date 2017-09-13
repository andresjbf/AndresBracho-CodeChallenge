using System;

namespace Animals
{
    ///<summary>
    ///Class to create each animal with three atributes name, color and noise 
    ///</summary>
    [Serializable]
    public class Animal
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string Noise { get; set; }

        public Animal(string name, string color, string noise)
        {
            this.Name = name;
            this.Color = color;
            this.Noise = noise;
        }

    }
}

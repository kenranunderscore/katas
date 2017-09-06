namespace Logic
{
    using System.Collections.Generic;
    using static Logic.Material;
    using static Logic.ItemType;

    public class Day11
    {
        public Day11()
        {
            var floors = new Floor[4];
            floors[0] = new Floor
            {
                HasElevator = true,
                Items = new List<Item>
                {
                    new Item { Material = Thulium, Type = Generator },
                    new Item { Material = Thulium, Type = Microchip },
                    new Item { Material = Plutonium, Type = Generator },
                    new Item { Material = Strontium, Type = Generator },
                }
            };
            floors[1] = new Floor
            {
                HasElevator = false,
                Items = new List<Item>
                {
                    new Item { Material = Plutonium, Type = Microchip },
                    new Item { Material = Strontium, Type = Microchip },
                }
            };
            floors[2] = new Floor
            {
                HasElevator = false,
                Items = new List<Item>
                {
                    new Item { Material = Promethium, Type = Generator },
                    new Item { Material = Promethium, Type = Microchip },
                    new Item { Material = Ruthenium, Type = Generator },
                    new Item { Material = Ruthenium, Type = Microchip },
                }
            };
            floors[3] = new Floor
            {
                HasElevator = false,
                Items = new List<Item>()
            };
        }
    }

    internal struct Floor
    {
        internal bool HasElevator { get; set; }
        internal IList<Item> Items { get; set; }
    }

    internal struct Item
    {
        internal ItemType Type { get; set; }
        internal Material Material { get; set; }
    }

    internal enum ItemType
    {
        Microchip,
        Generator,
    }

    internal enum Material
    {
        Thulium,
        Plutonium,
        Strontium,
        Promethium,
        Ruthenium
    }
}
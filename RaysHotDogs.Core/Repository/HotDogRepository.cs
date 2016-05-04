using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaysHotDogs.Core.Model;

namespace RaysHotDogs.Core.Repository
{
    public class HotDogRepository
    {
        private static List<HotDogGroup> hotDogGroups = new List<HotDogGroup>()
        {
            new HotDogGroup()
            {
                HotDogGroupId = 1, Title = "Meat Lovers", ImagePath = "", HotDogs = new List<HotDog>()
                {
                    new HotDog()
                    {
                        HotDogId = 1,
                        Name = "Regular Hot Dog",
                        ShortDescription = "The best there is on this planet",
                        Description = "Manchego smelly cheese",
                        ImagePath = "hotdog1",
                        Available = true,
                        PrepTime = 10,
                        Ingredients = new List<string>() {"Bun", "relish", "hotdog" },
                        Price = 8,
                        IsFavorite = true
                    },
                    new HotDog()
                    {
                        HotDogId = 2,
                        Name = "Haute Dog",
                        ShortDescription = "The classy one",
                        Description = "Bacon ipsum",
                        ImagePath = "hotdog2",
                        Available = true,
                        PrepTime = 15,
                        Ingredients = new List<string>() {"Bun", "relish", "hotdog" },
                        Price = 10,
                        IsFavorite = false
                    },
                    new HotDog()
                    {
                        HotDogId = 3,
                        Name = "Extra Long",
                        ShortDescription = "When regular isn't enough",
                        Description = "Capicola",
                        ImagePath = "hotdog3",
                        Available = true,
                        PrepTime = 10,
                        Ingredients = new List<string>() {"Bun", "relish", "hotdog" },
                        Price = 10,
                        IsFavorite = false
                    }
                }
            },
            new HotDogGroup()
            {
                HotDogGroupId = 2, Title = "Veggie Lovers", ImagePath = "", HotDogs = new List<HotDog>()
                {
                    new HotDog()
                    {
                        HotDogId = 4,
                        Name = "Veggie Hot Dog",
                        ShortDescription = "The best there is on this planet",
                        Description = "Manchego smelly cheese",
                        ImagePath = "hotdog4",
                        Available = true,
                        PrepTime = 10,
                        Ingredients = new List<string>() {"Bun", "relish", "veggie hotdog" },
                        Price = 8,
                        IsFavorite = false
                    },
                    new HotDog()
                    {
                        HotDogId = 5,
                        Name = "Long Veggie Hot Dog",
                        ShortDescription = "The best there is on this planet",
                        Description = "Manchego smelly cheese",
                        ImagePath = "hotdog5",
                        Available = true,
                        PrepTime = 10,
                        Ingredients = new List<string>() {"Bun", "relish", "long veggie hotdog" },
                        Price = 8,
                        IsFavorite = true
                    },
                    new HotDog()
                    {
                        HotDogId = 6,
                        Name = "Longer Veggie Hot Dog",
                        ShortDescription = "The best there is on this planet",
                        Description = "Manchego smelly cheese",
                        ImagePath = "hotdog6",
                        Available = true,
                        PrepTime = 10,
                        Ingredients = new List<string>() {"Bun", "relish", "longer veggie hotdog" },
                        Price = 10,
                        IsFavorite = false
                    }
                }
            }
        };

        public List<HotDog> GetAllHotDogs()
        {
            IEnumerable<HotDog> hotDogs = from hotDogGroup in hotDogGroups
                                          from hotDog in hotDogGroup.HotDogs
                                          select hotDog;

            return hotDogs.ToList<HotDog>();
        }

        public HotDog GetHotDogById(int hotDogId)
        {
            IEnumerable<HotDog> hotDogs = from hotDogGroup in hotDogGroups
                                          from hotDog in hotDogGroup.HotDogs
                                          where hotDog.HotDogId == hotDogId
                                          select hotDog;
            return hotDogs.FirstOrDefault();
        }

        public List<HotDogGroup> GetGroupedHotDogs()
        {
            return hotDogGroups;
        }

        public List<HotDog> GetHotDogsForGroup(int hotDogGroupId)
        {
            var group = hotDogGroups.FirstOrDefault(h => h.HotDogGroupId == hotDogGroupId);

            if (group != null)
            {
                return group.HotDogs;
            }

            return null;
        }

        public List<HotDog> GetFavoriteHotDogs()
        {
            IEnumerable<HotDog> hotDogs = from hotDogGroup in hotDogGroups
                                          from hotDog in hotDogGroup.HotDogs
                                          where hotDog.IsFavorite
                                          select hotDog;

            return hotDogs.ToList<HotDog>();
        }
    }
}


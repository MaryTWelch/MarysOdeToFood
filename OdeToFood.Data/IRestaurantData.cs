﻿using MarysOdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Mary's Pizza", Location = "Missouri", Cuisine = CuisineType.Italian},
                new Restaurant { Id = 2, Name = "Cinnamon Club", Location = "Washington D.C.", Cuisine = CuisineType.None},
                new Restaurant { Id = 3, Name = "Taco Cabana", Location = "California", Cuisine = CuisineType.Mexican},
                new Restaurant { Id = 4, Name = "India Palace", Location = "Missouri", Cuisine = CuisineType.Indian}
            };
        }
        
        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}

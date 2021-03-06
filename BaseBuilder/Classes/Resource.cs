﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBuilder.Classes
{
    class Resource : GameObject
    {
        public Resource()   {   }

        public Resource(int _id, string _name, string _desc, string _suffix, double _baseValue)
        {
            Id = _id;
            Name = _name;
            Text = _desc;

            suffix = _suffix;
            baseValue = _baseValue;
        }

        string suffix;
        double baseValue;
        double amount;
        double income;
        
        public static Resource Clone(Resource input)
        {
            return new Resource()
            {
                Amount = input.Amount,
                BaseValue = input.BaseValue,
                Id = input.Id,
                Income = input.Income,
                Name = input.Name,
                Suffix = input.Suffix,
                Text = input.Text,
                Title = input.Title
            };
        }

        public static Resource Clone(Resource input, int amount)
        {
            return new Resource()
            {
                Amount = amount,
                BaseValue = input.BaseValue,
                Id = input.Id,
                Income = input.Income,
                Name = input.Name,
                Suffix = input.Suffix,
                Text = input.Text,
                Title = input.Title
            };
        }

        public string GetAmount()
        {
            return Math.Round(amount, 2) + ' ' + suffix;
        }

        public string Name { get => Title; set => Title = value; }
        public double BaseValue { get => baseValue; set => baseValue = value; }
        public string Suffix { get => suffix; set => suffix = value; }
        public double Amount { get => amount; set => amount = value; }
        public double Income { get => income; set => income = value; }
    }
}

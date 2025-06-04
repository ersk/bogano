using Ersk.Simulation.DataTypes;
using LocationMap.Logging;
using LocationMap.Map.Terrain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LocationMap.PhysicalEntities.Animals.AnimalNeeds
{

    public interface IValidatable
    {
        bool IsValid(ref CodingReport? codingReport);
    }

    internal class ProvideNeed_Definition : IValidatable
    {
        //[JsonIgnore]
        //public NeedEnum Need_Parsed 
        //{
        //    get
        //    {
        //        if (IsValid(out _))
        //        {
        //            throw new InvalidOperationException("ProvideNeed_Definition is invalid.");
        //        }
        //        return (NeedEnum)Need!;
        //    } 
        //}

        public NeedEnum? Need { get; set; }
        public int100? Amount { get; set; }

        public bool IsValid(ref CodingReport? codingReport)
        {
            if (Need == null)
            {
                codingReport ??= new();
                codingReport.AddErrors("Invalid_Need_Missing", $"{Need} was missing/empty.");
            }
            //else
            //{
            //    bool canConvert = NeedEnum.TryConvert(Need, out _);

            //    if (canConvert == false)
            //    {
            //        codingReport.AddErrors("Invalid_Need_Cast", $"Need '{Need}' could not cast to Needs enum (class)");
            //    }
            //}

            if (Amount == null)
            {
                codingReport ??= new();
                codingReport.AddErrors("Invalid_Amount_Missing", $"{Amount} was missing/empty.");
            }

            return codingReport == null || codingReport.HasErrors == false;
        }
    }
}

using Ersk.Simulation.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LocationMap.PhysicalEntities.Animals.AnimalNeeds
{
    //internal class NeedEnum
    //{
    //    private readonly int index;
    //    private readonly string name;

    //    private static int indexInitializer = 0;

    //    private static Dictionary<string, NeedEnum> needsDictionary = new();

    //    public static NeedEnum Air = new(indexInitializer++, "Air");
    //    public static NeedEnum Water = new(indexInitializer++, "Water");
    //    public static NeedEnum Food = new(indexInitializer++, "Food");
    //    public static NeedEnum Temperature = new(indexInitializer++, "Temperature");
    //    public static NeedEnum Excretion = new(indexInitializer++, "Excretion");
    //    public static NeedEnum Recreation = new(indexInitializer++, "Recreation");

    //    private NeedEnum(int index, string name)
    //    {
    //        this.index = index;
    //        this.name = name;

    //        needsDictionary.Add(this.name, this);
    //    }

    //    public static explicit operator NeedEnum(string needsString)
    //    {
    //        bool canCast = needsDictionary.ContainsKey(needsString);

    //        if(!canCast)
    //        {
    //            throw new InvalidCastException($"Could not cast string '{needsString}' to Needs static enum class instance.");
    //        }

    //        return needsDictionary[needsString];
    //    }

    //    public static NeedEnum Convert(string needsString)
    //    {
    //        return (NeedEnum)needsString;
    //    }

    //    public static bool TryConvert(string needsString, out NeedEnum? need)
    //    {
    //        bool canCast = needsDictionary.ContainsKey(needsString);

    //        if (!canCast)
    //        {
    //            need = null;
    //            return false;
    //        }

    //        need = needsDictionary[needsString];
    //        return true;
    //    }
    //}









    [JsonConverter(typeof(DictionaryTKeyEnumTValueConverter))]
    internal class NeedEnum : ComplexEnumBase<NeedEnum>
    {
        public static NeedEnum Air = new("Air");
        public static NeedEnum Water = new("Water");
        public static NeedEnum Food = new("Food");
        public static NeedEnum Temperature = new( "Temperature");
        public static NeedEnum Excretion = new("Excretion");
        public static NeedEnum Recreation = new("Recreation");

        // Names have no spaces - so just pass in identity as name.
        private NeedEnum(string identity)
            : base(identity, identity) { }

        //public static explicit operator NeedEnum(string needsString)
        //{
        //    bool canCast = needsDictionary.ContainsKey(needsString);

        //    if (!canCast)
        //    {
        //        throw new InvalidCastException($"Could not cast string '{needsString}' to Needs static enum class instance.");
        //    }

        //    return needsDictionary[needsString];
        //}

        //public static NeedEnum Convert(string needsString)
        //{
        //    return (NeedEnum)needsString;
        //}

        //public static bool TryConvert(string needsString, out NeedEnum? need)
        //{
        //    bool canCast = needsDictionary.ContainsKey(needsString);

        //    if (!canCast)
        //    {
        //        need = null;
        //        return false;
        //    }

        //    need = needsDictionary[needsString];
        //    return true;
        //}
    }




    /**
     * Needs
     * 
     * Physiological needs
     *      Air - underwater / toxic gas
     *      Sleep 
     *      Water
     *      Food
     *      Temperature - safe (hyperthermia)
     *          => Energy = (sleep, food, sitting, running)
     *      Excrete Waste - Bladder/Bowls
     *      
     * Safety
     *      Shelter - temperature / sense-rain/wind/sun
     *      Air - pollution free
     *      Safety against society (laws)
     *      Safety against external threats - big animals, military/guards
     * 
     * Social
     *      Love
     *      Frienships
     *      Respect - Important job/role
     *      
     * Esteem
     *      Respect - professionalism
     *      Achievement
     *      Mastery
     *      Independance - competency
     *      Status/Prestige
     *      
     * Cognitive
     *      Knowledge
     *      Curiosity
     *      Exploration
     *      Logic/Meaningfulness
     *      Prectictability - structure/schedule
     *      Reproduce?
     *      
     *  Aestetic
     *      Beauty - art, music
     *      
     *  Self Actualization
     *      Fulfill potential
     *      Personal goals
     *      
     *  Transendence
     *      Altering culture of society
     *       
     *       
     * Short-term goals
     * Long-term goals
     * Bladdder/Bowels
     * 
     * 
     **/
}

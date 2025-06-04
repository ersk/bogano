using Ersk.Simulation.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LocationMap.Map.Terrain
{
    [JsonConverter(typeof(DictionaryTKeyEnumTValueConverter))]
    public class SoilTypeEnum : ComplexEnumBase<SoilTypeEnum>
    {
        public static SoilTypeEnum Clay = new("Clay");
        public static SoilTypeEnum SandyClay = new("SandyClay", "Sandy Clay");
        public static SoilTypeEnum SiltyClay = new("SiltyClay", "Silty Clay");
        public static SoilTypeEnum ClayLoam = new( "ClayLoam", "Clay Loam");
        public static SoilTypeEnum SiltyClayLoam = new("SiltyClayLoam", "Silty Clay Loam");
        public static SoilTypeEnum SandyClayLoam = new("SandyClayLoam", "Sandy Clay Loam");
        public static SoilTypeEnum Loam = new("Loam");
        public static SoilTypeEnum SiltLoam = new("SiltLoam", "Silt Loam");
        public static SoilTypeEnum Silt = new("Silt");
        public static SoilTypeEnum SandyLoam = new("SandyLoam", "Sandy Loam");
        public static SoilTypeEnum LoamySand = new("LoamySand", "Loamy Sand");
        public static SoilTypeEnum Sand = new("Sand");

        // Names have no spaces - so just pass in identity as name.
        private SoilTypeEnum(string identity)
            : base(identity, identity) { }
        private SoilTypeEnum(string identity, string name)
           : base(identity, name) { }


    }

}

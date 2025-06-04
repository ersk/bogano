using LocationMap.Map.Terrain;
using System.Text;


namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Dictionary<SoilTypeEnum, int> dic = new();

            foreach (var kvp in SoilTypeEnum.EnumDictionary)
            {
                dic.Add((SoilTypeEnum)kvp.Value, 0);
            }

            for (int i = 0; i < 101; i++)
            {
                //for (int j = 0; j < 101; j++)
                //{
                //    Soil soil = new Soil(100, 0);
                //}
                Soil soil = new Soil(i, 100-i);
                dic[soil.GetSoilType()]++;

                soil = new Soil(i, 0);
                dic[soil.GetSoilType()]++;

                soil = new Soil(0, i);
                dic[soil.GetSoilType()]++;
            }

            StringBuilder result = new();
            foreach (var kvp in SoilTypeEnum.EnumDictionary)
            {
                result.Append(kvp.Key + " => " + dic[(SoilTypeEnum)kvp.Value] + "\r\n");
            }

            string s = result.ToString();
            Console.WriteLine(s);
        }
    }
}
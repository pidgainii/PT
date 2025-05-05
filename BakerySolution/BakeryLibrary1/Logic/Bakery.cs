using BakeryLibrary1.Data;

namespace BakeryLibrary1.Logic
{
    public class Bakery
    {
        DataLayerAbstract data = DataLayerAbstract.CreateLinq2SQL();

        public int BakeBread(int flourKg, int yeastGrams)
        {
            return Math.Min(flourKg, yeastGrams / 10);
        }

        public int SellBread(int bakedLoaves, int requestedLoaves)
        {
            return Math.Min(bakedLoaves, requestedLoaves);
        }

        public int RestockFlour(int currentKg, int addedKg)
        {
            return currentKg + addedKg;
        }

        public double PricePerLoaf(double totalRevenue, int loavesSold)
        {
            if (loavesSold == 0)
                return double.PositiveInfinity;

            return totalRevenue / loavesSold;
        }
    }
}

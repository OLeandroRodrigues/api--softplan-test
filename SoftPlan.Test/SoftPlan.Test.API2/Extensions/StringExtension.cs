
namespace SoftPlan.Test.API2.Extensions
{
    public static class StringExtension
    {
        public static string ToMoneyBRLWith2Decimal(this decimal valor)
        {
            return string.Format("{0:0.00}", valor).Replace(".",",");
        }
    }
}

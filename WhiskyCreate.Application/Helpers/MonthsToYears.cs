using System;

namespace WhiskyCrate.Application.Helpers
{
    public static class MonthsToYears
    {
        public static string Resolve(int months) => months switch
        {
            1 => "1 month",
            int n when n <= 11 => $"{months} months",
            int n when n <= 23 => $"1 year",
            _ => $"{Math.Floor((decimal)months / 12)} years",
        };
    }
}
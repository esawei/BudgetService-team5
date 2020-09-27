﻿using System;

namespace Budget
{
    public class Period
    {
        public Period(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        private DateTime Start { get; set; }
        private DateTime End   { get; set; }

        public int OverlappingDays(Budget budget)
        {
            var overlappingEnd = End<budget.LastDay()
                ?End
                :budget.LastDay();
            var overlappingStart = Start > budget.FirstDay()
                ?Start
                :budget.FirstDay();

            if (Start.ToString("yyyyMM") == End.ToString("yyyyMM"))
            {
                if (budget.YearMonth == Start.ToString("yyyyMM"))
                {
                    // overlappingEnd = End;
                }
            }
            else
            {
                if (budget.YearMonth == Start.ToString("yyyyMM"))
                {
                    // overlappingEnd = budget.LastDay();
                }
                else if (budget.YearMonth == End.ToString("yyyyMM"))
                {
                    // overlappingEnd = End;
                }
                else if (budget.FirstDay() >= Start && budget.FirstDay() <= End)
                {
                    // overlappingEnd = budget.LastDay();
                }
            }

            return (overlappingEnd - overlappingStart).Days + 1;
        }
    }
}
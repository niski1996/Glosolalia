﻿using Glosolalia.Common.Entities;

namespace Glosolalia.API.DTOs.SheetDTOs
{
    public class CalcualtedSheetDTO:BaseSheetDTO
    {
        public int Begginer { get; set; }
        public int Medium { get; set; }
        public int Pro { get; set; }
        public int Points { get; set; }
        public Language LanguageOne { get; set; } = null!;
        public Language LanguageTwo { get; set; } = null!;
        public int TranslationAmount { get 
            {
                return Begginer + Medium + Pro;
            } }
        public float Progress
        {
            get
            {
                try
                {
                    return (Points / (10 * TranslationAmount));
                }
                catch (DivideByZeroException)
                {

                    return 0;
                }
                
            }
        }
    }
}

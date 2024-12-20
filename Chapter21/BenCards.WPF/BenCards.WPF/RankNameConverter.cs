﻿using System;
using System.Globalization;
using System.Security.AccessControl;
using System.Windows;
using System.Windows.Data;

namespace BenCards.WPF
{
    [ValueConversion(typeof(Ch13CardLib.Rank), typeof(string))]
    public class RankNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int source = (int)value;
            if (source == 1 || source > 10)
            {
                switch (source)
                {
                    case 1:
                        return "Ace";
                    case 11:
                        return "Jack";
                    case 12:
                        return "Queen";
                    case 13:
                        return "King";
                    default:
                        return DependencyProperty.UnsetValue;
                }
            }
            else
                return source.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}

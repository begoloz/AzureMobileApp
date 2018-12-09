﻿using System;
using System.Globalization;
using Xamarin.Forms;

namespace GeoLocApp_v2
{
    /// <summary>
    /// Converts an Entry's Text.Length into a 'flag'
    ///  * Entry is empty, returns f
    /// 
    /// </summary>
    public class PositiveLengthToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if ((int)value > 0)
                return true;    // data has been entered
            else
                return false;   // input is empty
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}


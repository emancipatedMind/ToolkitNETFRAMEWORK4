﻿namespace ToolkitNFW4.XAML {
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class IsNullConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return value == null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
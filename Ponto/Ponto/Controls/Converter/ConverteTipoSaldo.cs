using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Ponto.Controls.Converter
{
    public class ConverteTipoSaldo : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var tipoSaldo = value as string;

            if (tipoSaldo == "True")
            {
                return "Hora Extra";
            }
            else            
            {
                return "Hora Faltante";
            }                       
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab6Wpf
{
    class WeatherControl:DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty;
        private int temp;
        private string direction;
        private int speed;
       

        public int Temperature
        {
            get =>(int) GetValue(TemperatureProperty);

            set => SetValue(TemperatureProperty, value);
            
            
        }
        public string Direction
        {
            get 
            {
                return direction;
            }
            set 
            { 
            if(value=="Южный"||value=="Северный"||value=="Западный"||value=="Восточный"||value=="Юго-Западный"||value=="Юго-Восточный"||value=="Северо-Западный"||value=="Северо-Восточный")
                {
                    direction = value;
                }
                else 
                {
                    direction = "Не корректное значение";
                }
            }
        }
        public int Speed
        {
            get 
            {
                return speed;
            }
            set 
            { 
            if(value>0&&value<35)
                {
                    speed = value;
                }
                else 
                {
                    speed = 0;
                }
            }
        }
        public void Precipitat(string precipitat)
        {

            int n = 0;
            switch (n)
            {
                case 0:
                    {
                        precipitat = "Солнечно";
                    }
                    break;
                case 1:
                    {
                        precipitat = "Облачно";
                    }
                    break;
                case 2:
                    {
                        precipitat = "Дождь";
                    }
                    break;
                case 3:
                    {
                        precipitat = "Снег";
                    }
                    break;
            }
        }
        public WeatherControl(int temp, string direction, int speed)

        {
            this.Temperature = temp;
            this.Direction = direction;
            this.Speed = speed;
        }
        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerseTemperature)),
                new ValidateValueCallback(ValidateTemperature));
        }

        private static bool ValidateTemperature(object value)
        {
            int v = (int)value;
            if (v >= -50 && v <= 50)
                return true;
            else
                return false;
        }

        private static object CoerseTemperature(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v >= -50 && v <= 50)
                return v;
            else
                return 0;
        }
    }

}




using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    internal class MainPageViewModel :INotifyPropertyChanged
    {
        private double weight = 70;
        private double height = 150;
        private const double Step = 1.0;

        public event PropertyChangedEventHandler PropertyChanged;

        public double Height
        {
            get => height; set
            {
                height = NextStep(value);

                UpdateVki();
            }
        }

        public double Weight
        {
            get => weight; set
            {
                weight = NextStep(value);

                UpdateVki();
            }

        }
        public double Vki
          => Math.Round(weight / Math.Pow(Height / 100, 2), 2);

        public string Classifiction
        {
            get
            {
                if (Vki<= 16) return "Ileri Düzeyde Zayıf";
                else if (Vki < 16.99)
                    return "OrtaDüzeyde  Zayıf";

                else if (Vki<18.49) return "Hafif Düzey Zayıf";

                else if (Vki <= 24.9) return "Normal kilolu";

                else if (Vki <= 29.99) return "Hafif Şişman /Fazla kilolu";

                else if (Vki<= 34.99) return "1.Derecede";

                else if (Vki <=39.99) return "2.Dereced Obez";

                else 
                    return "3.Derecede Obez /Morbid Obez";
            }
        }
        private void UpdateVki()
        {
            RaisePropertyChanged(nameof(Vki));

            RaisePropertyChanged(nameof(Classifiction));
        }
       
       // public PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        private double NextStep(double value)
        => Math.Round(value / Step) * Step;
    }
}

using SalaryCalculatorApp.Models;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;


namespace SalaryCalculatorApp.ViewModels
{
    public class SalaryCalculatorViewModel : INotifyPropertyChanged
    {
        private Salary _salary;
        private Deductions _deductions;


        public Salary Salary
        {
            get => _salary;
            set
            {
                _salary = value;
                OnPropertyChanged(nameof(Salary));
                OnPropertyChanged(nameof(NetSalary));
                OnPropertyChanged(nameof(DeductionsBaseSalary));
                OnPropertyChanged(nameof(CCSSDeduction));
                OnPropertyChanged(nameof(CostaRixanISRDeduction));
                OnPropertyChanged(nameof(AsosacionSolidaristaDeduction));
            }
        }



        public double NetSalary => Salary.NetIncome;
        public double DeductionsBaseSalary => Salary.Deductions;
        public double CCSSDeduction => Salary.CCSSDeduction;
        public double CostaRixanISRDeduction => Salary.CostaRicanISRDeduction;
        public double AsosacionSolidaristaDeduction => Salary.AsociacionSolidaristaDeduction;

        

        public ICommand CalculateCommand { get; }

        public SalaryCalculatorViewModel()
        {
            Salary = new Salary();
            CalculateCommand = new Command(OnCalculate);
        }

        private void OnCalculate()
        {
            OnPropertyChanged(nameof(DeductionsBaseSalary));
            OnPropertyChanged(nameof(NetSalary));
            OnPropertyChanged(nameof(CCSSDeduction));
            OnPropertyChanged(nameof(CostaRixanISRDeduction));
            OnPropertyChanged(nameof(AsosacionSolidaristaDeduction));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

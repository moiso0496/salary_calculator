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
                _deductions = new Deductions(Salary.NetIncome, Salary.AsociacionPercentage);
            }
        }


        public double NetSalary => Salary.NetIncome;
        public double DeductionsBaseSalary => Salary.Deductions;
        public double CCSSDeduction => _deductions.CCSSDeduction;
        public double CostaRixanISRDeduction => (double)_deductions.CostaRixanISRDeduction();
        public double AsosacionSolidaristaDeduction => _deductions.AsosacionSolidaristaDeduction;

        

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

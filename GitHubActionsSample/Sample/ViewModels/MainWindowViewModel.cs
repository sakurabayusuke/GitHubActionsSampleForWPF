using Livet;
using Livet.Commands;
using Sample.Enums;

namespace Sample.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private Method _method;

        public Method Method
        {
            get => _method;
            set
            {
                _method = value;
                RaisePropertyChanged();
            }
        }

        public string Value1 { get; set; }

        public string Value2 { get; set; }

        private string _result;

        public string Result
        {
            get => _result;
            set
            {
                _result = value;
                RaisePropertyChanged();
            }
        }

        public ViewModelCommand CalCommand { get; set; }

        public MainWindowViewModel()
        {
            CalCommand = new ViewModelCommand(Cal);
        }

        private void Cal()
        {
            var test = "aa";
            var valid1 = int.TryParse(Value1, out var num1);
            var valid2 = int.TryParse(Value2, out var num2);
            if (!valid1 || !valid2)
            {
                Result = "Error";
                return;
            }

            switch (Method)
            {
                case Method.Addition:
                    Result = (num1 + num2).ToString();
                    break;
                case Method.Subtraction:
                    Result = (num1 - num2).ToString();
                    break;
                case Method.Multiplication:
                    Result = (num1 * num2).ToString();
                    break;
                case Method.Division:
                    Result = num2 == 0 ? "Error" : (num1 / num2).ToString();
                    break;
                default:
                    Result = "Error";
                    break;
            }
        }
    }
}

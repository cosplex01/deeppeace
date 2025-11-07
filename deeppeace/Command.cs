using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace deeppeace
{
    public class Command : ICommand
    {
        //필드 선언 - 델리게이트로 선언
        private readonly Action<object> _executeMethod;
        private readonly Func<object, bool> _canexecuteMethod; //null 허용
        //생성자 선언 - 델리게이트 매개변수로 받음
        public Command(Action<object> executeMethod, Func<object, bool> canexecuteMethod) //canexecuteMethod는 null 허용
        {
            this._executeMethod = executeMethod ?? throw new ArgumentException(nameof(executeMethod));
            this._canexecuteMethod = canexecuteMethod;
        }
        public Command(Action<object> executeMethod) : this(executeMethod, null!) { }

        public bool CanExecute(object? parameter)
        {
            //canexecuteMethod가 null이면 true 반환
            return _canexecuteMethod == null || _canexecuteMethod(parameter!);
        }
        public void Execute(object? parameter)
        {
            _executeMethod(parameter!); //null 아님을 단언하여 컴파일러에게 전달
        }
        public event EventHandler? CanExecuteChanged //CommandManager에 이벤트 등록/해제
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}

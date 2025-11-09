using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;
using deeppeace.PeaceModel;
using Microsoft.Win32;
using System.Windows;

namespace deeppeace
{
    public class PeaceModelView : INotifyPropertyChanged
    {
        //필드 선언 - INotifyPropertyChanged 구현부
        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand MyCommand { get; set; }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public PeaceModelView()
        {
            MyCommand = new Command(ExecuteMethod, CanExecuteMethod);
        }

        private bool CanExecuteMethod(object arg)
        {
            return true;
            //throw new NotImplementedException();
        }

        private void ExecuteMethod(object obj)
        {
            MessageBox.Show(Application.Current.MainWindow, "운영체제 종료해서 평안을 얻어요","deeppeace", MessageBoxButton.OK);
            System.Diagnostics.Process.Start("shutdown.exe", "-s");
            //throw new NotImplementedException();
        }
    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace radkov_pr10
{
    public class TaskItem : INotifyPropertyChanged
    {
        private string _title;
        public string Title
        {
            get => _title;
            set 
            {
                _title = value;
                OnPropertyChanged();
            }
        }
        private bool _isCompleted;
        public bool IsCompleted 
        {
            get => _isCompleted;
            set 
            {
               _isCompleted = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

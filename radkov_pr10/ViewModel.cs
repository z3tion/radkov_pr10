using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace radkov_pr10
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TaskItem> Tasks { get; set; }

        public RelayCommand AddTaskCommand { get; }
        public RelayCommand DeleteTaskCommand { get; }
        private string _newTaskTitle { get; set; }
        public string NewTaskTitle
        {
            get => _newTaskTitle;
            set
            {
                _newTaskTitle = value;
                OnPropertyChanged();
                AddTaskCommand?.RaiseCanExecuteChanged();
            }
        }
        
        private TaskItem _selectedTask;
        public TaskItem SelectedTask
        {
            get => _selectedTask;
            set 
            { 
                _selectedTask = value;
                OnPropertyChanged();
                DeleteTaskCommand?.RaiseCanExecuteChanged();
            }
        }

        public ViewModel()
        {
            Debug.Write(_newTaskTitle);
            Tasks = new ObservableCollection<TaskItem>();
            AddTaskCommand = new RelayCommand(AddTask, CanAddTask);
            DeleteTaskCommand = new RelayCommand(DeleteTask, () => SelectedTask != null);
        }
        public void AddTask() 
        {
            Tasks.Add(new TaskItem { Title = _newTaskTitle, IsCompleted = false});
            NewTaskTitle = string.Empty;

        }
        private bool CanAddTask() => !string.IsNullOrWhiteSpace(_newTaskTitle);
        public void DeleteTask() 
        { 
            Tasks.Remove(_selectedTask);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

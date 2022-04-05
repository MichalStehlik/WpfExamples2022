using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Wpf05Collection.Models;

namespace Wpf05Collection.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Student> _students = new ObservableCollection<Student>();
        private int _selectedStudentIndex;
        private Student _selectedStudent;

        public RelayCommand Add { get; set; }
        public RelayCommand Remove { get; set; }

        public MainViewModel()
        {
            Students.Add(new Student { Firstname = "Adam", Lastname = "Antoš", Average = 2.05, Gender = Gender.Male, Examined = false });
            Students.Add(new Student { Firstname = "Boris", Lastname = "Bohatý", Average = 4.4, Gender = Gender.Male, Examined = true });
            Students.Add(new Student { Firstname = "Ctirad", Lastname = "Culík", Average = 1.4, Gender = Gender.Male, Examined = false });
            Students.Add(new Student { Firstname = "Daniela", Lastname = "Dvořáková", Average = 3.0, Gender = Gender.Female, Examined = false });
            Students.Add(new Student { Firstname = "Eva", Lastname = "Ebenová", Average = 3.0, Gender = Gender.Female, Examined = false });
            Students.Add(new Student { Firstname = "Filip", Lastname = "Fiala", Average = 2.5, Gender = Gender.Other, Examined = true });
            Add = new RelayCommand(
                () => { Students.Add(new Student { Firstname = "Nový", Lastname = "Student" }); },
                () => true
            );
            Remove = new RelayCommand(
                () => { Students.Remove(SelectedStudent); },
                () => { return SelectedStudent != null; }
            );
        }

        public List<Gender> Genders
        {
            get
            {
                return Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            }
        }
        public ObservableCollection<Student> Students { get { return _students; } set { _students = value; NotifyPropertyChanged(); } }
        public int SelectedStudentIndex { get { return _selectedStudentIndex + 1; } set { _selectedStudentIndex = value; NotifyPropertyChanged(); Remove.RaiseCanExecuteChanged(); } }
        public Student SelectedStudent { get { return _selectedStudent; } set { _selectedStudent = value; NotifyPropertyChanged(); } }
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

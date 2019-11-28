﻿using MVVM_FIRST.Model;
using SDK.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM_FIRST.ViewModel
{
    class UserLoginViewModel : INotifyPropertyChanged
    {
        private UnitOfWork _UnitOfWork = new UnitOfWork();
        public UserLoginViewModel()
        { 
            Users = new ObservableCollection<User>(_UnitOfWork.UsersRepository.GetAll());
            LoginCommand = new RelayCommand(Login , CanLogin);
        

        }

        private bool CanLogin(object obj)
        {

           return ((System.Windows.Controls.PasswordBox)obj).Password != null &&
                Email != null ;
        }

        public RelayCommand LoginCommand { get; set; }

        private void Login(Object obj)
        {
            String password = ((System.Windows.Controls.PasswordBox)obj).Password;
        
             IEnumerable<User> us = Users.Where( l => l.Mail.ToLower().Contains(Email.ToLower()) && l.Password==password);
            
            if (us.Count() != 0)
            {

                Window objPopupwindow = new MainWindow();
                objPopupwindow.Show();
                Window.GetWindow(((System.Windows.Controls.PasswordBox)obj)).Close();
            }
         
            else
            {
                MessageBox.Show("Your email or your password doesn't correct!");
            }
        
        }

        private ObservableCollection<User> _Users;
        public ObservableCollection<User> Users
        {
            get
            {
                return _Users;
            }
            set
            {
                _Users = value;
                OnPropertyChanged("Users");
            }
        }

        private String _Email;
        public String Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
                OnPropertyChanged("Email");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}

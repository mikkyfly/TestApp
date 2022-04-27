using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TestApp.Models
{
    class Model :INotifyPropertyChanged
    {
        private string _provider;
        private bool _isDone;
        private string _product;
        private string _type;
        private decimal _price;
        private DateTime _date;
        private string _comment;

        public string Provider
        {
            get { return _provider; }
            set 
            {
                if (_provider==value)
                {
                    return;
                }
                    
                _provider = value;
                OnPropertyChanged("Provider");
            }
        }
        public bool IsDone
        {
            get { return _isDone; }
            set 
            {
                if (_isDone==value)
                {
                    return;
                }
                    

                _isDone = value;
                OnPropertyChanged("IsDone");
            }
        }
        public string Product
        {
            get { return _product; }
            set 
            {
                
                if (_product == value)
                {
                    return;
                }
                   

                _product = value;
                OnPropertyChanged("Product");
            }
        }
        public string Type
        {
            get { return _type; }
            set 
            {
                if (_type==value)
                {
                    return;
                }
                _type = value;
                OnPropertyChanged("Type");
            }
        }
        public decimal Price
        {
            get { return _price; }
            set 
            {
                if (_price==value)
                {
                    return;
                }
                _price = value;
                OnPropertyChanged("Price");
            }
        }
        public DateTime Date
        {
            get { return _date; }
            set 
            {
                if (_date==value)
                {
                    return;
                }
                _date = value;
                OnPropertyChanged("Date");
            }
        }
        public string Comment
        {
            get { return _comment; }
            set 
            {
                if (_comment==value)
                {
                    return;
                }
                _comment = value; 
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string propertyName="")
        {
            if (PropertyChanged !=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            
        }
    }
}

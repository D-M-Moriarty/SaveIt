using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;

/**
 * this class represents
 * a users bank account
 */

namespace SaveIt
{
    public class Account : ObservableObject
    {
        public const string NameNotTheCorrectlengthExceptionMessage = "The Account name provided is the wrong length";
        public const string BalanceMinusValueExceptionMessage = "The Account balance cannot be a minus value";
        public const string AsOfDateExceptionMessage = "The Account as of date cannot be in the future";

        public ObservableCollection<string> TypeList
        {
            get { return _typeList; }
        }
        //SelectedItem="{Binding Account.TypeList, Mode=TwoWay}"

        public Account()
        {
            _typeList = new ObservableCollection<string>()
            {
                "Checking",
                "Savings",
                "Credit",
                "Debit",
                "Cash",
                "Other"
            };
        }


        public int Id { get; set; }
        // TODO make type predifined array of values eventually pull from database
        public string Type { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    if (value.Length <= 1 || value.Length >= 50)
                    {
                        base.AddError("Name", NameNotTheCorrectlengthExceptionMessage);
                    }
                    else
                        base.RemoveError("Name");
                    
                    _name = value;
                }
            }
        }

        private double _initialBalance;
        public double InitialBalance
        {
            get { return _initialBalance; }
            set
            {
                if (_initialBalance != value)
                {
                    if (value < 0.00)
                        base.AddError("InitialBalance", BalanceMinusValueExceptionMessage);
                    //throw new Exception(BalanceMinusValueExceptionMessage);
                    else
                    {
                        base.RemoveError("InitialBalance");
                    }

                    _initialBalance = value;
                }
            }
        }


        // TODO maybe validate at controller level
        private DateTime _asOfDate;

        private readonly ObservableCollection<string> _typeList;

        public DateTime AsOfDate
        {
            get { return _asOfDate; }
            set
            {
                if (_asOfDate != value)
                {
                    if (value > DateTime.Now)
                        base.AddError("AsOfDate", AsOfDateExceptionMessage);
                        //throw new Exception(AsOfDateExceptionMessage);
                    else
                        base.RemoveError("AsOfDate");

                    _asOfDate = value;
                }
                    
                
            }
        }
    }
}
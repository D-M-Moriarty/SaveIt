using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text.RegularExpressions;

/**
 * this class represents the 
 * person that is paying the user
 * or the person the user is paying
 */

namespace SaveIt
{
    public class Payee : ObservableObject
    {

        private static Regex Nameregex = new Regex(
            @"^[a-zA-Z ,.'-]+$",
            RegexOptions.IgnoreCase
            | RegexOptions.CultureInvariant
            | RegexOptions.IgnorePatternWhitespace
            | RegexOptions.Compiled
        );

        // TODO might remove this
        private static Regex Phoneregex = new Regex (
                @"^\d{3}((\-\ )|\-|(\ \-\ |\ -))\d{7}$",
                RegexOptions.IgnoreCase
                | RegexOptions.CultureInvariant
                | RegexOptions.Compiled
            );
      
            
        public int Id { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    if (string.IsNullOrEmpty(value))
                        base.AddError("Name", "The Name cannot be left empty");
                    else if (value.Length > 20)
                        base.AddError("Name", "The Name must be under 20 characters");
                    else if (!Nameregex.IsMatch(value))
                        base.AddError("Name", "The Name is not a valid format");
                    else
                        base.RemoveError("Name");

                    _name = value;

                }
            }
        }


        private string _telephone;
        public string Telephone
        {
            get { return _telephone; }
            set
            {
                if (_telephone != value)
                {
                    if (string.IsNullOrEmpty(value))
                        base.AddError("Telephone", "The Name cannot be left empty");
                    else if (value.Length < 13)
                        base.AddError("Telephone", "Phone number cannot be that long");
                    else if (!Phoneregex.IsMatch(value))
                        base.AddError("Telephone", "The Number is not a valid format");
                    else
                        base.RemoveError("Telephone");

                    _telephone = value;

                }
            }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set
            {
                if (_address != value)
                {
                    if (value.Length > 30)
                        base.AddError("Address", "The Address must be under 30 characters");
                    else
                        base.RemoveError("Address");

                    _address = value;
                    
                }
            }
        }

        //private DateTime _asOfDate;
        public DateTime AsOfDate { get; set; }
        
        public bool IsPayee { get; set; }

        
    }
}
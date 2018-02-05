using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveIt;
using SaveIt.Annotations;

/**
 * This class is responsible for
 * for recoring the users income
 */

namespace SaveIt
{
    public class Income : ObservableObject
    {

        public const string DescriptionIsTooLong = "The description is too long";
        public const string AmountLessThanZero = "The amount is less than zero";

        public Income()
        {
            Date = DateTime.Now;
        }

        public int Id { get; set; }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    if (value.Length > 60)
                        base.AddError("Description", DescriptionIsTooLong);
                    else
                        base.RemoveError("Description");

                    _description = value;
                }
               
            }
        }

        private double _amount;
        public double Amount
        {
            get { return _amount; }
            set
            {
                if (_amount != value)
                {
                    if (value < 0)
                        base.AddError("Amount", AmountLessThanZero);
                    else
                        base.RemoveError("Amount");

                    _amount = value;
                }
            }
        }

        // TODO possibly add a new field instead of this one and ignore this
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? Date { get; set; }
        [CanBeNull]
        public Payee Payer { get; set; }
        [CanBeNull]
        public Account Account { get; set; }
        public string Comment { get; set; }

    }
}

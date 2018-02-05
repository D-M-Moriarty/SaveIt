using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveIt;

namespace Controllers
{
    public class AddCategoryController : ObservableObject
    {
        private Category _category;

        public Category Category
        {
            get { return _category; }
            set
            {
                if (value != _category)
                {
                    _category = value;
                    OnPropertyChanged("Category");
                }
            }
        }

        public bool IsUpdating { get; set; }

        public AddCategoryController()
        {
            Category = new Category();
        }

        // method to update an existing category
        public void UpdateCategory()
        {
            using (var db = new EntitySaveItContext())
            {
                var result = db.Categories.SingleOrDefault(b => b.Id == Category.Id);
                if (result != null)
                {
                    result.Budget = Category.Budget;
                    result.Description = Category.Description;
                    db.SaveChanges();

                }
            }
        }

        public void SaveCategory()
        {
            if (IsUpdating)
            {
                UpdateCategory();
            }
            else
            {
                using (var db = new EntitySaveItContext())
                {
                    db.Categories.Add(Category);
                    db.SaveChanges();
                }

            }
        }
    }
}

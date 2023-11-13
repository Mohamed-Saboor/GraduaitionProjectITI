using GraduaitionProjectITI.Models.Context;
using GraduaitionProjectITI.Models.Entity;
using GraduaitionProjectITI.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace GraduaitionProjectITI.Reprository.CategoryReprositry
{
    public class CategoryReprository : ICategoryReprositry
    {


        private readonly ECcontext context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public CategoryReprository(ECcontext context, IWebHostEnvironment webHostEnvironment )
        {
            this.context= context;
            this.webHostEnvironment= webHostEnvironment;
        }

        public bool CheckCategoryExist(string Name)
        {
           return context.Categories.SingleOrDefault(c => c.Name.ToLower() == Name.ToLower()) == null;
        }

        public bool CheckCategoryExistEdit(string Name, int Id)
        {
            return context.Categories.SingleOrDefault(c => c.Id != Id && c.Name.ToLower() == Name.ToLower()) == null;
        }

        public void Delete(int id)
        {
            var category = GetCategory(id);
                
            context.Categories.Remove(category);
            string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "CategoryImages");
            string uniqueFileName = category.Image;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }

        public IEnumerable<Category> GetAll()
        {
            return context.Categories.ToList();
        }

        public Category GetCategory(int Id)
        {
            return context.Categories.SingleOrDefault(c => c.Id == Id);
        }

        public Category GetCategoryWithProducts(int Id)
        {
           return context.Categories.Where(c => c.Id == Id).Include(c => c.Products).SingleOrDefault();
        }

        public void Insert(AddCategoryViewModel addCategoryViewModel)
        {
            string uniqueFileName = UploadedFile(addCategoryViewModel.CategoryImage, addCategoryViewModel.Name);
            var category = new Category();
            category.Name = addCategoryViewModel.Name;
            category.Image = uniqueFileName;
            context.Categories.Add(category);
            
        }

        public void Save()
        {
            context.SaveChanges();
        }
        public void Update(EditCategoryViewModel editCategoryViewModel)
        {
            string uniqueFileName = UploadedFile(editCategoryViewModel.CategoryImage, editCategoryViewModel.Name);
            var category = GetCategory(editCategoryViewModel.Id);
            if (uniqueFileName is null)
            {
                category.Name = editCategoryViewModel.Name;
            }
            else
            {
                category.Name = editCategoryViewModel.Name;
                category.Image = uniqueFileName;
            }
        }

        public string UploadedFile(IFormFile model, string CatName)
        {
            string uniqueFileName = null;


            if (model != null)
            {

                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "CategoryImages");
                uniqueFileName = CatName + System.IO.Path.GetExtension(model.FileName).ToString();

                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}


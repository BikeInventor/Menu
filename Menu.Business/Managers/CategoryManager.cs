using System;
using System.Collections.Generic;
using AutoMapper;
using Menu.Business.Core;
using Menu.Business.Exceptions;
using Menu.Business.ManagersInterfaces;
using Menu.Contracts.DataContracts;
using Menu.Data;
using Menu.DAL.Core.Interfaces;

namespace Menu.Business.Managers
{
    public class CategoryManager : ManagerBase, ICategoryManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public long AddCategory(CategoryDto category)
        {
            var newCategory = Mapper.Map<CategoryDto, Category>(category);
            newCategory.Created = DateTime.Now;
            newCategory.LastEdited = DateTime.Now;

            _unitOfWork.Categories.Add(newCategory);
            _unitOfWork.Save();

            return newCategory.Id;
        }

        public CategoryDto GetCategory(long id)
        {
            var category = _unitOfWork.Categories.Get(id);

            if (category == null)
            {
                throw new ObjectNotFoundException()
                {
                    Title = "Ошибка при обращении к объекту",
                    Message = "Объект не найден."
                };

            }

            return Mapper.Map<Category, CategoryDto>(category);
        }

        public IEnumerable<CategoryDto> GetCategories()
        {
            return Mapper.Map<IEnumerable<Category>,
                    IEnumerable<CategoryDto>>(_unitOfWork.Categories.GetAll());
        }

        public void UpdateCategory(CategoryDto updatedCategory)
        {
            var categoryToUpdate = _unitOfWork.Categories.Get(updatedCategory.Id);

            if (categoryToUpdate == null)
            {
                throw new ObjectNotFoundException
                {
                    Title = "Ошибка при попытке редактирования объекта",
                    Message = "Объект не найден."
                };
            }

            updatedCategory.Created = categoryToUpdate.Created;
            updatedCategory.LastEdited = DateTime.Now;

            _unitOfWork.Categories.Update(Mapper.Map<CategoryDto, Category>(updatedCategory));
            _unitOfWork.Save();
        }

        public void DeleteCategory(long id)
        {
            var categoryToDelete = _unitOfWork.Categories.Get(id);

            if (categoryToDelete != null)
            {
                _unitOfWork.Categories.Delete(categoryToDelete);
                _unitOfWork.Save();
            }
            else
            {
                throw new ObjectNotFoundException
                {
                    Title = "Ошибка при попытке удаления объекта",
                    Message = "Объект не найден."
                };
            }
        }
    }
}

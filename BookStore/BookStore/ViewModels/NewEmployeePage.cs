using BookStore.ViewModels.Abstract;
using BookStoreApi;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.ViewModels
{
    public class NewEmployeePage : ANewViewModel<Employee>
    {
        public NewEmployeePage()
        {
        }

        #region Fields
        private string name;
        private string surname;
        private string address;
        private string email;
        private string phoneNumber;
        private string position;
        private double salary;
        #endregion

        #region Properties
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Surname
        {
            get => surname;
            set => SetProperty(ref surname, value);
        }

        public string Address
        {
            get => address;
            set => SetProperty(ref address, value);
        }

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public string PhoneNumber
        {
            get => phoneNumber;
            set => SetProperty(ref phoneNumber, value);
        }

        public string Position
        {
            get => position;
            set => SetProperty(ref position, value);
        }

        public double Salary
        {
            get => salary;
            set => SetProperty(ref salary, value);
        }
        #endregion

        public override Employee SetItem()
        {
            return new Employee
            {
                Name = this.Name,
                Surname = this.Surname,
                Address = this.Address,
                Email = this.Email,
                PhoneNumber = this.PhoneNumber,
                Position = this.Position,
                Salary = this.Salary,
                IsActive = true,
                CretionDate = DateTime.Now,
                MmodifDate = DateTime.Now
            };
        }

        public override bool ValidateSave()
        {
            return !string.IsNullOrEmpty(name)
                && !string.IsNullOrEmpty(surname)
                && !string.IsNullOrEmpty(address)
                && !string.IsNullOrEmpty(email)
                && !string.IsNullOrEmpty(position)
                && salary > 0;
        }
    }
}

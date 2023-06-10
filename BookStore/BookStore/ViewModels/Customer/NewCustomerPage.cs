using BookStore.ViewModels.Abstract;
using BookStoreApi;
using System;

namespace BookStore.ViewModels.Customer
{
    public class NewCustomerPage : ANewViewModel<CustomerForView>
    {
        public NewCustomerPage()
            : base()
        {
        }

        #region Fields
        private string name = "";
        private string surname = "";
        private string address = "";
        private string email = "";
        private string phoneNumber = "";
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
        #endregion

        public override CustomerForView SetItem()
        {
            return new CustomerForView
            {
                CretionDate = DateTime.Now,
                MmodifDate = DateTime.Now,
                IsActive = true,
                Name = Name,
                Surname = Surname,
                Address = Address,
                Email = Email,
                PhoneNumber = PhoneNumber
            };
        }

        public override bool ValidateSave()
        {
            return !string.IsNullOrEmpty(name)
                && !string.IsNullOrEmpty(surname)
                && !string.IsNullOrEmpty(address)
                && !string.IsNullOrEmpty(email);
        }
    }
}

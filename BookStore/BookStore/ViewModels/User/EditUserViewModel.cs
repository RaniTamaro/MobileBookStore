using BookStore.Helpers.Constants;
using BookStore.ViewModels.Abstract;
using BookStoreApi;
using System;
using System.Collections.Generic;

namespace BookStore.ViewModels.User
{
    public class EditUserViewModel : AEditItemViewModel<UserForView>
    {
        public EditUserViewModel()
            : base()
        {
            roles = RoleConstants.GetRoles();
        }

        #region Fields
        private int id;
        private string name;
        private string surname;
        private string address;
        private string email;
        private string phoneNumber;
        private string nickname;
        private string password;
        private string selectedRole;
        private List<string> roles;
        private DateTime creationDate;
        #endregion

        #region Properties
        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

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

        public string Nickname
        {
            get => nickname;
            set => SetProperty(ref nickname, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public string SelectedRole
        {
            get => selectedRole;
            set => SetProperty(ref selectedRole, value);
        }

        public List<string> Roles
        {
            get => roles;
            set => SetProperty(ref roles, value);
        }

        public DateTime CreationDate
        {
            get => creationDate;
            set => SetProperty(ref creationDate, value);
        }
        #endregion

        public override void LoadProperties(UserForView item)
        {
            Id = item.Id;
            Name = item.Name;
            Surname = item.Surname;
            Address = item.Address;
            Email = item.Email;
            PhoneNumber = item.PhoneNumber;
            Nickname = item.Nickname;
            SelectedRole = item.Role;
            CreationDate = DateTime.Parse(item.CretionDate.ToString());
        }

        public override UserForView SetItem()
        {
            return new UserForView
            {
                CretionDate = CreationDate,
                MmodifDate = DateTime.Now,
                IsActive = true,
                Id = Id,
                Name = Name,
                Surname = Surname,
                Address = Address,
                Email = Email,
                PhoneNumber = PhoneNumber,
                Nickname = Nickname,
                Password = Password,
                Role = SelectedRole
            };
        }

        public override bool ValidateSave()
        {
            return !string.IsNullOrEmpty(name)
                && !string.IsNullOrEmpty(surname)
                && !string.IsNullOrEmpty(address)
                && !string.IsNullOrEmpty(email)
                && !string.IsNullOrEmpty(nickname)
                && !string.IsNullOrEmpty(password);
        }
    }
}

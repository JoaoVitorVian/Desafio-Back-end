using Core.Exceptions;
using Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : Base
    {
        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            _errors = new List<string>();

            Validate();
        }

        //EF
        protected User() { }

        public string Name { get; private set; }

        public string Email { get; set; }

        public string Password { get; private set; }

        public void ChangeName(string name)
        {
            Name = name;
            Validate();
        }

        public void ChangePassword(string password)
        {
            Password = password;
            Validate();
        }

        public void ChangeEmail(string email)
        {
            Email = email;
            Validate();
        }

        public override bool Validate()
        {
           var validator = new UserValidator();
           var validation = validator.Validate(this);
           if (!validation.IsValid)
           {
                foreach(var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);

                throw new DomainExceptions("Alguns campos estão inválidos, corrija-os!", _errors);
           }

            return true;
        }
    }
}

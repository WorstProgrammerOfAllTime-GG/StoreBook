using BookStore.Auth;
using BookStore.Enums;
using BookStore.Models;
using BookStore.Services;
using BookStore.UI;



namespace BookStore.AuthorizationAndRegistration
{
    public class Authorization
    {
        private Store store;
        private Validator validator;
        private UIAuthorization uIAuthorization;

        public Authorization(Store store,Validator validator, UIAuthorization uIAuthorization)
        {
            this.store = store;
            this.validator = validator;
            this.uIAuthorization = uIAuthorization;
        }
        public void AuthorizationUser()
        {
            User ? user = validator.ValidationAuth("Введите логин : ", "Введите пароль: ");

            if (user.Roles.Count>1)
            {
                uIAuthorization.UI();
            } else
            {
                foreach (Role role in user.Roles)
                {
                    if (role == Role.Reader)
                    {
                        Console.WriteLine(""); // заглушка
                    }                    
                }
            }
                
            
        }
    }
}

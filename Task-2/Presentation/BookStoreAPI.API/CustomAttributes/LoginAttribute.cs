using BookStoreAPI.Application.DTOs.UserDTOs;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net.Mail;

namespace BookStoreAPI.API.CustomAttributes
{

    public class LoginAttribute: ActionFilterAttribute
    {
        public string Login { get; set; }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.ContainsKey(Login))
            {
                LoginUserDto user = context.ActionArguments[Login] as LoginUserDto;// context.ActionArguments dictionaryden Login keyine karşılık değeri alıyoruz

                if (user.Password == null || user.Password.Length < 3)//şifre boş ya da 3 karakterden az ise hata fırlatıyoruz
                    throw new Exception("Şifre ya da eposta yazım hatası!");  
                try
                {
                    MailAddress m = new MailAddress(user.Email); // Eposta adresi düzgün formatta mı diye try catch ile kontrol ediyoruz
                }
                catch
                {
                    throw new Exception("Şifre ya da eposta yazım hatası!");
                }  
            }
            base.OnActionExecuting(context);
        }
    }
}

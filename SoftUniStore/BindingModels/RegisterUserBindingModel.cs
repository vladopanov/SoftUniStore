namespace SoftUniStore.BindingModels
{
    public class RegisterUserBindingModel
    {
        public string Email { get; set; }

        public string Fullname { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}

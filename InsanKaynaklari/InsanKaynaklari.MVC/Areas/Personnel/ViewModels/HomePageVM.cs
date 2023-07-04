namespace InsanKaynaklari.MVC.Areas.Personnel.ViewModels
{
    public class HomePageVM
    {
        public string FirstName { get; set; }
        public string? SecondName { get; set; }
        public string LastName { get; set; }
        public string? SecondLastName { get; set; }
        public string Email { get; set; }

        private string _phoneNumber;

        public string PhoneNumber
        {
            get
            {
                // Daha sonra +90 gibi ülke kodu için düzenleme yapılacak mı
                if (!string.IsNullOrEmpty(_phoneNumber) && (_phoneNumber.Length == 11 || _phoneNumber.Length == 10))
                {
                    // Numaranın başında 0 olması durumu
                    string formattedNumber = _phoneNumber.StartsWith("0") ? _phoneNumber.Substring(1) : _phoneNumber;

                    if (formattedNumber.Length == 10)
                    {
                        return $"({formattedNumber.Substring(0, 3)}) {formattedNumber.Substring(3, 3)} {formattedNumber.Substring(6, 2)} {formattedNumber.Substring(8, 2)}";
                    }
                    else if (formattedNumber.Length == 11)
                    {
                        return $"({formattedNumber.Substring(0, 4)}) {formattedNumber.Substring(4, 3)} {formattedNumber.Substring(7, 2)} {formattedNumber.Substring(9, 2)}";
                    }
                    else
                    {
                        return _phoneNumber;
                    }
                }
                else
                {
                    return _phoneNumber;
                }
            }
            set
            {
                _phoneNumber = value;
            }
        }
        public string Profession { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string PhotoFileName { get; set; }

        public string DisplayPhotoPath
        {
            get
            {
                if (PhotoFileName == null)
                {
                    if (Gender == "Male")
                    {
                        return "~/images/20180125_001_1_.jpg";
                    }
                    else if (Gender == "Female")
                    {
                        return "~/images/20180129_002.jpg";
                    }
                }
                return PhotoFileName;
            }
        }
    }
}


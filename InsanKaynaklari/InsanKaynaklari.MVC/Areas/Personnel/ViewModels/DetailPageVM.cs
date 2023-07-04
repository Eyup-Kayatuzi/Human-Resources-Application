namespace InsanKaynaklari.MVC.Areas.Personnel.ViewModels
{
    public class DetailPageVM
    {
        public string FirstName { get; set; } = null!;
        public string? SecondName { get; set; }
        public string LastName { get; set; } = null!;
        public string? SecondLastName { get; set; }
        public string Email { get; set; }

        private string _phoneNumber;

        public string PhoneNumber
        {
            get
            {
                // Daha sonra +90 gibi ülke kodu için düzenleme gelebilir
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
        public DateTime DateOfBirth { get; set; }
        public string BirthPlace { get; set; } = null!;
        public string Tc { get; set; } = null!;
        public DateTime StartDateOfJob { get; set; }
        public DateTime LeaveDateOfJob { get; set; }
        public bool IsActive { get; set; }
        public string CompanyInfo { get; set; } = null!;// suan icin sirket adi
        public string Profession { get; set; } = null!; // meslegi
        public string Department { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string PicturePath { get; set; }
        
    }
}


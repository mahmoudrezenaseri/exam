namespace Exam.Core.ApplicationService.Common
{
    public static class CommonValidation
    {
        public static bool NationalCodeIsValid(string nationalCode) 
        {
            // TODO : add real national code validation rules
            if (nationalCode.Length == 10)
                return true;

            return false;
        }

        public static bool PhoneNumberIsValid(string phoneNumber)
        {
            // TODO : add real phone number validation rules
            if (phoneNumber.Length == 11)
                return true;

            return false;
        }
    }
}

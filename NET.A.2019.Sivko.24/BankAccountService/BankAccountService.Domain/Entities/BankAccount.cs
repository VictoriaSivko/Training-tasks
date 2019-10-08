using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BankAccountService.Domain.Entities
{
    public class BankAccount
    {
        [HiddenInput(DisplayValue = false)]
        public int BankAccountId { get; set; }
        [Display(Name="Balance")]
        public double Balance { get; set; }
        [Display(Name = "Bonus")]
        public int Bonus { get; set; }
        [Display(Name = "Open")]
        public bool OpenAcc { get; set; }
        [Display(Name = "Owner Name")]
        public string Name { get; set; }
    }
}

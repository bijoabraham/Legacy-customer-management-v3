using CustomersWebDemo.DbAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomersWebDemo.Models
{

    public enum CustomerTypeEnum
    {
        [Display(Name = "Person")]
        Person = 0,
        [Display(Name = "Corporation")]
        Corporation = 1
    }


    public class Customer
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "Maximum length is 50 characters")]
        public string CustomerName { get; set; }

        [DisplayName("Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please, enter a valid email")]
        [StringLength(100, ErrorMessage = "Maximum length is 100 characters")]
        public string Email { get; set; }


        [DisplayName("Location")]
        [StringLength(50, ErrorMessage = "Maximum length is 50 characters")]
        public string Location { get; set; }

        [DisplayName("Notes")]
        [StringLength(1500, ErrorMessage = "Maximum length is 1500 characters")]
        public string Notes { get; set; }

        [DisplayName("Contract date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:MM-dd-yyyy}")]
        public DateTime? ContractDate { get; set; }

        [DisplayName("Customer type")]
        public CustomerTypeEnum? CustomerType { get; set; }

        public int FlagDeleted { get; set; }


        // returns display name for the Enum
        [NotMapped]
        public string CustomerTypeDisplayName
        {
            get
            {
                if (CustomerType.HasValue)
                    return EnumNameHelper.GetDisplayName(CustomerType);
                else
                    return "";
            }
        }



    }
}
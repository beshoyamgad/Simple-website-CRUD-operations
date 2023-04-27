using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace learn.Models
{
    [Table("Employee", Schema = "dbo")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Employee ID")]
        public int EmployeeId { get; set; }

        [Required]
        [Column(TypeName = "int")]
        [Display(Name = "Employee Number")]

        public int EmployeeNumber { get; set; }

        [Required]
        [Column(TypeName = "varchar(150)")]
        [MaxLength(100)]
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Hiring Date")]
        [DisplayFormat(DataFormatString ="{0:dd-MMMM-yyyy}")]
        public DateTime HiringDate { get; set; }


        [Required]
        [Column(TypeName = "decimal(12,2)")]
        [Display(Name = "Gross Salary")]
        public decimal GrossSalary { get; set; }


        [Column(TypeName = "decimal(12,2)")]
        [Display(Name = "Net Salary")]
        public double NetSalary { get; set; }

        [ForeignKey("Department")]
        [Required]
        public int DepartmentId { get; set; }
      
       [Display(Name = "Department ")]
       [NotMapped]
        public string DepartmentName { get; set; }

     // public virtual Department Department { get; set; }
      



    }
}

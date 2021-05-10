using FTeam.Orm.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// News Table
/// </summary>
public record News
{
    public News()
    {

    }

    /// <summary>
    /// News Primary Key
    /// </summary>
    [FKey]
    [Key]
    public Guid NewsId { get; set; }

    /// <summary>
    /// News Title
    /// </summary>
    [Display(Name = "تیتر")]
    [Required(ErrorMessage = "{0} اجباری است")]
    [MaxLength(150, ErrorMessage = "{0} نمیتواند بزرگ تز از {1} کاراکتر باشد")]
    public string Title { get; set; }

    /// <summary>
    /// News Short Description
    /// </summary>
    [Display(Name = "لید")]
    [Required(ErrorMessage = "{0} اجباری است")]
    [MaxLength(500, ErrorMessage = "{0} نمیتواند بزرگ تز از {1} کاراکتر باشد")]
    [DataType(DataType.MultilineText)]
    public string ShortDescription { get; set; }

    /// <summary>
    /// News Text
    /// </summary>
    [Display(Name = "متن کامل")]
    [Required(ErrorMessage = "{0} اجباری است")]
    [DataType(DataType.MultilineText)]
    public string Text { get; set; }

    /// <summary>
    /// This News Is Show In Slider?
    /// </summary>
    [Display(Name = "نمایش در اسلایدر")]
    [Required]
    public bool ShowInSlider { get; set; }

    /// <summary>
    /// News Image Name
    /// </summary>
    [Display(Name = "تصویر")]
    public string ImageName { get; set; }

    /// <summary>
    /// Create News Date 
    /// </summary>
    [Display(Name = "تاریخ ثبت")]
    [Required]
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// Is Public News
    /// </summary>
    [Display(Name = "خبر عمومی")]
    [Required]
    public bool IsPublic { get; set; }

    //Navigation Property 
    //Relationhsips 

}
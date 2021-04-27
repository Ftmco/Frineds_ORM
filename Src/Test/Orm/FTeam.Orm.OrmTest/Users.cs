using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Users Data Base Table
/// </summary>
public record Users
{
    public Users()
    {

    }

    /// <summary>
    /// Primary Key
    /// </summary>
    public Guid UserId { get; set; }


    /// <summary>
    /// User Name
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// User First Name
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// User Last Name
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Email
    /// </summary>
    public string Email { get; set; }


    /// <summary>
    /// Phone Number
    /// </summary>
    public string PhoneNumber { get; set; }


    /// <summary>
    /// Password
    /// </summary>
    public string Password { get; set; }


    /// <summary>
    /// Active Code
    /// </summary>
    public string ActiveCode { get; set; }


    /// <summary>
    /// Actived (is Active)
    /// </summary>
    public bool IsActive { get; set; }


    /// <summary>
    /// Active Date
    /// </summary>
    public DateTime ActiveDate { get; set; }

    /// <summary>
    /// Image Name
    /// </summary>
    public string ImageName { get; set; }

    /// <summary>
    /// User Age
    /// </summary>
    public string Age { get; set; }

    /// <summary>
    /// User Citizen Code
    /// </summary>
    public string CitizenCode { get; set; }

    /// <summary>
    /// User Bio
    /// </summary>
    public string Bio { get; set; }

    /// <summary>
    /// User Type
    /// </summary>
    public int UserType { get; set; }

    /// <summary>
    /// Request Signup Description
    /// </summary>
    public string RequestDescription { get; set; }

}


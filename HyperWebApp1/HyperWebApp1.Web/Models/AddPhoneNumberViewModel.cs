// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddPhoneNumberViewModel.cs" company="EPAM Systems">
//   Copyright 2015
// </copyright>
// <summary>
//   The AddPhoneNumberViewModel.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HyperWebApp1.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// AddPhoneNumberViewModel
    /// </summary>
    public class AddPhoneNumberViewModel
    {
        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }
}
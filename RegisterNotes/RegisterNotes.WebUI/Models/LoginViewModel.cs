using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RegisterNotes.WebUI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessageResourceType = typeof(MUI.Language), ErrorMessageResourceName = "ModelUserNameRequired")]
        [Display(Name = "ModelUserNameDisplay", ResourceType = typeof(MUI.Language))]
        [EmailAddress(ErrorMessageResourceType = typeof(MUI.Language), ErrorMessageResourceName = "ModelEmailWrong")]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(MUI.Language), ErrorMessageResourceName = "ModelPasswordRequired")]
        [DataType(DataType.Password, ErrorMessageResourceType = typeof(MUI.Language), ErrorMessageResourceName = "ModelPasswordWrong")]
        [Display(Name = "ModelPasswordDisplay", ResourceType = typeof(MUI.Language))]
        public string Password { get; set; }

        [Display(Name = "ModelRememberMeDisplay", ResourceType = typeof(MUI.Language))]
        public bool RememberMe { get; set; }
    }
}
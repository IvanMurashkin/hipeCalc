using DBModel.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalc.Models {
    public class OperViewModel {

        public string OperName { get; set; }

        [Required]
        public string Args { get; set; }

        public double? Result { get; set; }

        [UIHint("ListFavorites")]
        public IList<Favorite> Favorites { get; set; }

    }
}
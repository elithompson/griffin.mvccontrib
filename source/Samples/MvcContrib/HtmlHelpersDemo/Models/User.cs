﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HtmlHelpersDemo.Models
{
    public class User
    {
        public int Id { get; set; }

        [Display(Description = "Simulate watermark metadata")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Speicies Speicies { get; set; }
        public bool IsHappy { get { return true; } }

        public static readonly User[] Users = new User[]
                                                  {
                                                      new User
                                                          {
                                                              Id = 1,
                                                              Age = 18,
                                                              FirstName = "Jonas",
                                                              LastName = "Gauffin",
                                                              Speicies = Speicies.Cow
                                                          },
                                                      new User
                                                          {
                                                              Id = 2,
                                                              Age = 92,
                                                              FirstName = "Arne",
                                                              LastName = "Umbug",
                                                              Speicies = Speicies.Human
                                                          },
                                                      new User
                                                          {
                                                              Id = 3,
                                                              Age = 981,
                                                              FirstName = "Zkdr",
                                                              LastName = "Koiae",
                                                              Speicies = Speicies.Marsian
                                                          },
                                                  };
    }

    public enum Speicies
    {
        Human,
        Dog,
        Cat,
        Cow,

        [Description("From planet Mars")]
        Marsian
    }
}
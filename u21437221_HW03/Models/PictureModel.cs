using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21437221_HW03.Models
{
    public class PictureModel
    {
        private string _Picture;

        public PictureModel(string picture)
        {
            _Picture = picture;
        }

        public string Picture
        {
            get { return _Picture; }
            set { _Picture = value; }
        }

    }
}
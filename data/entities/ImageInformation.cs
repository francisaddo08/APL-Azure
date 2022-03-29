using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APL_Technical_Test.data.entities
{
    public class ImageInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string ImageName { get; set; }
        public string Dimensions { get; set; }
        public DateTime UploadDate { get; set; }

    }
}

﻿namespace FileUploadApp.Models
{
    public class FileModel
    {

        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadDate { get; set; }
        public string UploadedBy { get; set; }


    }
}

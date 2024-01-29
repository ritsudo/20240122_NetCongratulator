using System;
using System.ComponentModel.DataAnnotations;

namespace NetCongratulator.Domain;

public class Image
{
    public int Id { get; set; }
    public string? FileName { get; set; }
    public string? ContentType { get; set; }
    public string? FilePath { get; set; }
    public DateTime UploadDate { get; set; }
}
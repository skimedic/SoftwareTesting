// Copyright Information
// ==================================
// SoftwareTesting - DALSample - BaseEntity.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace DALSample.Models.Base;

public abstract class BaseEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Timestamp]
    public byte[] TimeStamp { get; set; }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QL_KyTucXa
{
    using System;
    using System.Collections.Generic;
    
    public partial class DonXinTham
    {
        public string MaDon { get; set; }
        public string TenNguoiThan { get; set; }
        public string MaSV { get; set; }
        public string QuanHe { get; set; }
        public Nullable<System.DateTime> NgayXin { get; set; }
        public Nullable<System.DateTime> ThoiGian { get; set; }
        public string DuyetDon { get; set; }
    
        public virtual SinhVien SinhVien { get; set; }
    }
}

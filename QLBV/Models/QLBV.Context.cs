﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLBV.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<tblComment> tblComments { get; set; }
        public DbSet<tblContent> tblContents { get; set; }
        public DbSet<tblGroup> tblGroups { get; set; }
        public DbSet<tblUser> tblUsers { get; set; }
        public DbSet<tblUserGroup> tblUserGroups { get; set; }
    
        public virtual ObjectResult<SP_List_Accept_Result> SP_List_Accept(string cKey)
        {
            var cKeyParameter = cKey != null ?
                new ObjectParameter("cKey", cKey) :
                new ObjectParameter("cKey", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_List_Accept_Result>("SP_List_Accept", cKeyParameter);
        }
    
        public virtual ObjectResult<SP_List_Accepted_Result> SP_List_Accepted(Nullable<int> iUser, string cKey)
        {
            var iUserParameter = iUser.HasValue ?
                new ObjectParameter("iUser", iUser) :
                new ObjectParameter("iUser", typeof(int));
    
            var cKeyParameter = cKey != null ?
                new ObjectParameter("cKey", cKey) :
                new ObjectParameter("cKey", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_List_Accepted_Result>("SP_List_Accepted", iUserParameter, cKeyParameter);
        }
    
        public virtual ObjectResult<SP_List_Comment_Result> SP_List_Comment(Nullable<int> iUser, Nullable<int> iContent)
        {
            var iUserParameter = iUser.HasValue ?
                new ObjectParameter("iUser", iUser) :
                new ObjectParameter("iUser", typeof(int));
    
            var iContentParameter = iContent.HasValue ?
                new ObjectParameter("iContent", iContent) :
                new ObjectParameter("iContent", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_List_Comment_Result>("SP_List_Comment", iUserParameter, iContentParameter);
        }
    
        public virtual ObjectResult<SP_List_Content_Result> SP_List_Content(string cKey)
        {
            var cKeyParameter = cKey != null ?
                new ObjectParameter("cKey", cKey) :
                new ObjectParameter("cKey", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_List_Content_Result>("SP_List_Content", cKeyParameter);
        }
    
        public virtual ObjectResult<SP_List_Editing_Result> SP_List_Editing(Nullable<int> iUser, string cKey)
        {
            var iUserParameter = iUser.HasValue ?
                new ObjectParameter("iUser", iUser) :
                new ObjectParameter("iUser", typeof(int));
    
            var cKeyParameter = cKey != null ?
                new ObjectParameter("cKey", cKey) :
                new ObjectParameter("cKey", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_List_Editing_Result>("SP_List_Editing", iUserParameter, cKeyParameter);
        }
    
        public virtual ObjectResult<SP_List_Employee_Result> SP_List_Employee(string key)
        {
            var keyParameter = key != null ?
                new ObjectParameter("key", key) :
                new ObjectParameter("key", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_List_Employee_Result>("SP_List_Employee", keyParameter);
        }
    
        public virtual ObjectResult<SP_List_Noaccept_Result> SP_List_Noaccept(Nullable<int> iUser, string cKey)
        {
            var iUserParameter = iUser.HasValue ?
                new ObjectParameter("iUser", iUser) :
                new ObjectParameter("iUser", typeof(int));
    
            var cKeyParameter = cKey != null ?
                new ObjectParameter("cKey", cKey) :
                new ObjectParameter("cKey", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_List_Noaccept_Result>("SP_List_Noaccept", iUserParameter, cKeyParameter);
        }
    
        public virtual ObjectResult<SP_List_User_Result> SP_List_User(string key)
        {
            var keyParameter = key != null ?
                new ObjectParameter("key", key) :
                new ObjectParameter("key", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_List_User_Result>("SP_List_User", keyParameter);
        }
    
        public virtual ObjectResult<SP_List_WaitingForReview_Result> SP_List_WaitingForReview(Nullable<int> iUser, string cKey)
        {
            var iUserParameter = iUser.HasValue ?
                new ObjectParameter("iUser", iUser) :
                new ObjectParameter("iUser", typeof(int));
    
            var cKeyParameter = cKey != null ?
                new ObjectParameter("cKey", cKey) :
                new ObjectParameter("cKey", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_List_WaitingForReview_Result>("SP_List_WaitingForReview", iUserParameter, cKeyParameter);
        }
    
        public virtual ObjectResult<SP_Rpt_CountContent_Result> SP_Rpt_CountContent(Nullable<int> iUser, Nullable<int> iMonth, Nullable<int> iYear)
        {
            var iUserParameter = iUser.HasValue ?
                new ObjectParameter("iUser", iUser) :
                new ObjectParameter("iUser", typeof(int));
    
            var iMonthParameter = iMonth.HasValue ?
                new ObjectParameter("iMonth", iMonth) :
                new ObjectParameter("iMonth", typeof(int));
    
            var iYearParameter = iYear.HasValue ?
                new ObjectParameter("iYear", iYear) :
                new ObjectParameter("iYear", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Rpt_CountContent_Result>("SP_Rpt_CountContent", iUserParameter, iMonthParameter, iYearParameter);
        }
    
        public virtual ObjectResult<SP_Rpt_Top_Result> SP_Rpt_Top(Nullable<int> iMonth, Nullable<int> iYear)
        {
            var iMonthParameter = iMonth.HasValue ?
                new ObjectParameter("iMonth", iMonth) :
                new ObjectParameter("iMonth", typeof(int));
    
            var iYearParameter = iYear.HasValue ?
                new ObjectParameter("iYear", iYear) :
                new ObjectParameter("iYear", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Rpt_Top_Result>("SP_Rpt_Top", iMonthParameter, iYearParameter);
        }
    
        public virtual ObjectResult<SP_List_Active_Result> SP_List_Active(string cKey)
        {
            var cKeyParameter = cKey != null ?
                new ObjectParameter("cKey", cKey) :
                new ObjectParameter("cKey", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_List_Active_Result>("SP_List_Active", cKeyParameter);
        }
    
        public virtual ObjectResult<SP_List_Accept_ByEmployee_Result> SP_List_Accept_ByEmployee(string cKey, Nullable<int> iEmployee)
        {
            var cKeyParameter = cKey != null ?
                new ObjectParameter("cKey", cKey) :
                new ObjectParameter("cKey", typeof(string));
    
            var iEmployeeParameter = iEmployee.HasValue ?
                new ObjectParameter("iEmployee", iEmployee) :
                new ObjectParameter("iEmployee", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_List_Accept_ByEmployee_Result>("SP_List_Accept_ByEmployee", cKeyParameter, iEmployeeParameter);
        }
    
        public virtual ObjectResult<SP_List_Content_ByEmployee_Result> SP_List_Content_ByEmployee(string cKey, Nullable<int> iEmployee)
        {
            var cKeyParameter = cKey != null ?
                new ObjectParameter("cKey", cKey) :
                new ObjectParameter("cKey", typeof(string));
    
            var iEmployeeParameter = iEmployee.HasValue ?
                new ObjectParameter("iEmployee", iEmployee) :
                new ObjectParameter("iEmployee", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_List_Content_ByEmployee_Result>("SP_List_Content_ByEmployee", cKeyParameter, iEmployeeParameter);
        }
    
        public virtual ObjectResult<SP_List_Active_ByEmployee_Result> SP_List_Active_ByEmployee(string cKey, Nullable<int> iEmployee)
        {
            var cKeyParameter = cKey != null ?
                new ObjectParameter("cKey", cKey) :
                new ObjectParameter("cKey", typeof(string));
    
            var iEmployeeParameter = iEmployee.HasValue ?
                new ObjectParameter("iEmployee", iEmployee) :
                new ObjectParameter("iEmployee", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_List_Active_ByEmployee_Result>("SP_List_Active_ByEmployee", cKeyParameter, iEmployeeParameter);
        }
    }
}

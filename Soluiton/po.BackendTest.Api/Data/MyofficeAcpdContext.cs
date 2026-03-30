using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using po.BackendTest.Api.Models.Entities;

namespace po.BackendTest.Api.Data;

public partial class MyofficeAcpdContext : DbContext
{
    public MyofficeAcpdContext()
    {
    }

    public MyofficeAcpdContext(DbContextOptions<MyofficeAcpdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MyOfficeAcpd> MyOfficeAcpds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      => optionsBuilder.UseSqlServer("Server=ABAO\\SQLEXPRESS;Database=master;Trusted_Connection=True;TrustServerCertificate=True;");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MyOfficeAcpd>(entity =>
        {
            entity.HasKey(e => e.AcpdSid);

            entity.ToTable("MyOffice_ACPD");

            entity.Property(e => e.AcpdSid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ACPD_SID");
            entity.Property(e => e.AcpdCname)
                .HasMaxLength(60)
                .HasColumnName("ACPD_Cname");
            entity.Property(e => e.AcpdEmail)
                .HasMaxLength(60)
                .HasColumnName("ACPD_Email");
            entity.Property(e => e.AcpdEname)
                .HasMaxLength(40)
                .HasColumnName("ACPD_Ename");
            entity.Property(e => e.AcpdLoginId)
                .HasMaxLength(30)
                .HasColumnName("ACPD_LoginID");
            entity.Property(e => e.AcpdLoginPwd)
                .HasMaxLength(60)
                .HasColumnName("ACPD_LoginPWD");
            entity.Property(e => e.AcpdMemo)
                .HasMaxLength(600)
                .HasColumnName("ACPD_Memo");
            entity.Property(e => e.AcpdNowDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ACPD_NowDateTime");
            entity.Property(e => e.AcpdNowId)
                .HasMaxLength(20)
                .HasColumnName("ACPD_NowID");
            entity.Property(e => e.AcpdSname)
                .HasMaxLength(40)
                .HasColumnName("ACPD_Sname");
            entity.Property(e => e.AcpdStatus)
                .HasDefaultValue((byte)0)
                .HasColumnName("ACPD_Status");
            entity.Property(e => e.AcpdStop)
                .HasDefaultValue(false)
                .HasColumnName("ACPD_Stop");
            entity.Property(e => e.AcpdStopMemo)
                .HasMaxLength(60)
                .HasColumnName("ACPD_StopMemo");
            entity.Property(e => e.AcpdUpddateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ACPD_UPDDateTime");
            entity.Property(e => e.AcpdUpdid)
                .HasMaxLength(20)
                .HasColumnName("ACPD_UPDID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

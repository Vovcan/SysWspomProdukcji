using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SWPProjekt.Model;

public partial class ProductionDatabaseContext : DbContext
{
    public ProductionDatabaseContext()
    {
    }

    public ProductionDatabaseContext(DbContextOptions<ProductionDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Complaint> Complaints { get; set; }

    public virtual DbSet<Delivery> Deliveries { get; set; }

    public virtual DbSet<JobTitle> JobTitles { get; set; }

    public virtual DbSet<LostProduct> LostProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Production> Productions { get; set; }

    public virtual DbSet<ProductionDelivery> ProductionDeliveries { get; set; }

    public virtual DbSet<ProductionManager> ProductionManagers { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Response> Responses { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<TaskUser> TaskUsers { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    public virtual DbSet<WorkingHour> WorkingHours { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //Mateusz connection
        //=> optionsBuilder.UseMySQL("Server=127.0.0.1;User=root;Database=production_database;");
        //Włodzimiesz connection
       => optionsBuilder.UseMySQL("server=127.0.0.1;database=swp;user=root;password=root");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Complaint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("complaint");

            entity.HasIndex(e => e.Userid, "FKcomplaint481026");

            entity.HasIndex(e => e.Responseid, "FKcomplaint54396");

            entity.Property(e => e.Id)
                .HasColumnType("int(10)")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Responseid)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(10)");
            entity.Property(e => e.Subject)
                .HasMaxLength(200)
                .HasColumnName("subject");
            entity.Property(e => e.Userid)
                .HasColumnType("int(10)")
                .HasColumnName("userid");

            entity.HasOne(d => d.Response).WithMany(p => p.Complaints)
                .HasForeignKey(d => d.Responseid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FKcomplaint54396");

            entity.HasOne(d => d.User).WithMany(p => p.Complaints)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FKcomplaint481026");
        });

        modelBuilder.Entity<Delivery>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("delivery");

            entity.HasIndex(e => e.Unitid, "FKdelivery461467");

            entity.HasIndex(e => e.Warehouseid, "FKdelivery583613");

            entity.HasIndex(e => e.Productid, "FKdelivery833937");

            entity.Property(e => e.Id)
                .HasColumnType("int(10)")
                .HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.CurrentAmount)
                .HasColumnType("int(10)")
                .HasColumnName("current_amount");
            entity.Property(e => e.DeliveryDate)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp")
                .HasColumnName("delivery_date");
            entity.Property(e => e.DeliveryNumber)
                .HasColumnType("int(10)")
                .HasColumnName("delivery_number");
            entity.Property(e => e.ExpirationDate)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp")
                .HasColumnName("expiration_date");
            entity.Property(e => e.FullPrice).HasColumnName("full_price");
            entity.Property(e => e.PriceByUnit).HasColumnName("price_by_unit");
            entity.Property(e => e.Productid)
                .HasColumnType("int(10)")
                .HasColumnName("productid");
            entity.Property(e => e.Unitid)
                .HasColumnType("int(10)")
                .HasColumnName("unitid");
            entity.Property(e => e.Warehouseid)
                .HasColumnType("int(10)")
                .HasColumnName("warehouseid");

            entity.HasOne(d => d.Product).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.Productid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FKdelivery833937");

            entity.HasOne(d => d.Unit).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.Unitid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FKdelivery461467");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.Warehouseid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FKdelivery583613");
        });

        modelBuilder.Entity<JobTitle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("job_title");

            entity.Property(e => e.Id)
                .HasColumnType("int(10)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
        });

        modelBuilder.Entity<LostProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("lost_product");

            entity.HasIndex(e => e.Deliveryid, "FKlost_produ554171");

            entity.Property(e => e.Id)
                .HasColumnType("int(10)")
                .HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.Date)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("timestamp")
                .HasColumnName("date");
            entity.Property(e => e.Deliveryid)
                .HasColumnType("int(10)")
                .HasColumnName("deliveryid");

            entity.HasOne(d => d.Delivery).WithMany(p => p.LostProducts)
                .HasForeignKey(d => d.Deliveryid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FKlost_produ554171");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("product");

            entity.Property(e => e.Id)
                .HasColumnType("int(10)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.Producer)
                .HasMaxLength(30)
                .HasColumnName("producer");
        });

        modelBuilder.Entity<Production>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("production");

            entity.HasIndex(e => e.Projectid, "FKproduction880645");

            entity.Property(e => e.Id)
                .HasColumnType("int(10)")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.FinishDate)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp")
                .HasColumnName("finish_date");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.OtherPayments).HasColumnName("other_payments");
            entity.Property(e => e.PlannedFinishDate)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp")
                .HasColumnName("planned_finish_date");
            entity.Property(e => e.ProductionPrice).HasColumnName("production_price");
            entity.Property(e => e.Projectid)
                .HasColumnType("int(10)")
                .HasColumnName("projectid");
            entity.Property(e => e.StartDate)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp")
                .HasColumnName("start_date");

            entity.HasOne(d => d.Project).WithMany(p => p.Productions)
                .HasForeignKey(d => d.Projectid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FKproduction880645");
        });

        modelBuilder.Entity<ProductionDelivery>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("production_delivery");

            entity.HasIndex(e => e.Productionid, "FKproduction41029");

            entity.HasIndex(e => e.Deliveryid, "FKproduction529420");

            entity.Property(e => e.Id)
                .HasColumnType("int(10)")
                .HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("int(10)")
                .HasColumnName("amount");
            entity.Property(e => e.Date)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("timestamp")
                .HasColumnName("date");
            entity.Property(e => e.Deliveryid)
                .HasColumnType("int(10)")
                .HasColumnName("deliveryid");
            entity.Property(e => e.InOut)
                .HasColumnType("bit(1)")
                .HasColumnName("in_out");
            entity.Property(e => e.Productionid)
                .HasColumnType("int(10)")
                .HasColumnName("productionid");

            entity.HasOne(d => d.Delivery).WithMany(p => p.ProductionDeliveries)
                .HasForeignKey(d => d.Deliveryid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FKproduction529420");

            entity.HasOne(d => d.Production).WithMany(p => p.ProductionDeliveries)
                .HasForeignKey(d => d.Productionid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FKproduction41029");
        });

        modelBuilder.Entity<ProductionManager>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("production_manager");

            entity.HasIndex(e => e.Productionid, "FKproduction879533");

            entity.HasIndex(e => e.Userid, "FKproduction986531");

            entity.Property(e => e.Id)
                .HasColumnType("int(10)")
                .HasColumnName("id");
            entity.Property(e => e.Productionid)
                .HasColumnType("int(10)")
                .HasColumnName("productionid");
            entity.Property(e => e.Userid)
                .HasColumnType("int(10)")
                .HasColumnName("userid");

            entity.HasOne(d => d.Production).WithMany(p => p.ProductionManagers)
                .HasForeignKey(d => d.Productionid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FKproduction879533");

            entity.HasOne(d => d.User).WithMany(p => p.ProductionManagers)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FKproduction986531");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("project");

            entity.HasIndex(e => e.Userid, "FKproject739088");

            entity.Property(e => e.Id)
                .HasColumnType("int(10)")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.FinishDate)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp")
                .HasColumnName("finish_date");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.ProjectTime)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp")
                .HasColumnName("project_time");
            entity.Property(e => e.StartDate)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp")
                .HasColumnName("start_date");
            entity.Property(e => e.Userid)
                .HasColumnType("int(10)")
                .HasColumnName("userid");

            entity.HasOne(d => d.User).WithMany(p => p.Projects)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FKproject739088");
        });

        modelBuilder.Entity<Response>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("response");

            entity.HasIndex(e => e.Userid, "FKresponse751687");

            entity.Property(e => e.Id)
                .HasColumnType("int(10)")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Userid)
                .HasColumnType("int(10)")
                .HasColumnName("userid");

            entity.HasOne(d => d.User).WithMany(p => p.Responses)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FKresponse751687");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("sale");

            entity.HasIndex(e => e.Deliveryid, "FKsale798933");

            entity.Property(e => e.Id)
                .HasColumnType("int(10)")
                .HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.DateOfSale)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("timestamp")
                .HasColumnName("date_of_sale");
            entity.Property(e => e.Deliveryid)
                .HasColumnType("int(10)")
                .HasColumnName("deliveryid");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.Delivery).WithMany(p => p.Sales)
                .HasForeignKey(d => d.Deliveryid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FKsale798933");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("task");

            entity.HasIndex(e => e.Productionid, "FKtask741501");

            entity.Property(e => e.Id)
                .HasColumnType("int(10)")
                .HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp")
                .HasColumnName("creation_date");
            entity.Property(e => e.Deadline)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp")
                .HasColumnName("deadline");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.FinishDate)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp")
                .HasColumnName("finish_date");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.Priority)
                .HasColumnType("int(1)")
                .HasColumnName("priority");
            entity.Property(e => e.Productionid)
                .HasColumnType("int(10)")
                .HasColumnName("productionid");
            entity.Property(e => e.StartDate)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp")
                .HasColumnName("start_date");
            entity.Property(e => e.TaskStatus)
                .HasColumnType("int(1)")
                .HasColumnName("task_status");

            entity.HasOne(d => d.Production).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.Productionid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FKtask741501");
        });

        modelBuilder.Entity<TaskUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("task_user");

            entity.HasIndex(e => e.Taskid, "FKtask_user365171");

            entity.HasIndex(e => e.Userid, "FKtask_user476282");

            entity.Property(e => e.Id)
                .HasColumnType("int(10)")
                .HasColumnName("id");
            entity.Property(e => e.Taskid)
                .HasColumnType("int(10)")
                .HasColumnName("taskid");
            entity.Property(e => e.Userid)
                .HasColumnType("int(10)")
                .HasColumnName("userid");

            entity.HasOne(d => d.Task).WithMany(p => p.TaskUsers)
                .HasForeignKey(d => d.Taskid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FKtask_user365171");

            entity.HasOne(d => d.User).WithMany(p => p.TaskUsers)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FKtask_user476282");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("unit");

            entity.Property(e => e.Id)
                .HasColumnType("int(10)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.HasIndex(e => e.JobTitleid, "FKuser782828");

            entity.HasIndex(e => e.Login, "login").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10)")
                .HasColumnName("id");
            entity.Property(e => e.Active)
                .HasColumnType("bit(1)")
                .HasColumnName("active");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.JobTitleid)
                .HasColumnType("int(10)")
                .HasColumnName("job_titleid");
            entity.Property(e => e.Login)
                .HasMaxLength(30)
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(256)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasColumnType("int(15)")
                .HasColumnName("phone_number");
            entity.Property(e => e.Picture)
                .HasMaxLength(100)
                .HasColumnName("picture");
            entity.Property(e => e.SalaryByHour)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("salary_by_hour");
            entity.Property(e => e.SalaryByMonth)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(10)")
                .HasColumnName("salary_by_month");
            entity.Property(e => e.Surname)
                .HasMaxLength(30)
                .HasColumnName("surname");
            entity.Property(e => e.TemporaryPassword)
                .HasColumnType("bit(1)")
                .HasColumnName("temporary_password");

            entity.HasOne(d => d.JobTitle).WithMany(p => p.Users)
                .HasForeignKey(d => d.JobTitleid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FKuser782828");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("warehouse");

            entity.Property(e => e.Id)
                .HasColumnType("int(10)")
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.Full)
                .HasColumnType("int(1)")
                .HasColumnName("full");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.Zip)
                .HasMaxLength(10)
                .HasColumnName("zip");
        });

        modelBuilder.Entity<WorkingHour>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("working_hours");

            entity.HasIndex(e => e.Userid, "FKworking_ho212899");

            entity.HasIndex(e => e.Productionid, "FKworking_ho78965");

            entity.Property(e => e.Id)
                .HasColumnType("int(10)")
                .HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Hours)
                .HasColumnType("int(2)")
                .HasColumnName("hours");
            entity.Property(e => e.Productionid)
                .HasColumnType("int(10)")
                .HasColumnName("productionid");
            entity.Property(e => e.Userid)
                .HasColumnType("int(10)")
                .HasColumnName("userid");

            entity.HasOne(d => d.Production).WithMany(p => p.WorkingHours)
                .HasForeignKey(d => d.Productionid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FKworking_ho78965");

            entity.HasOne(d => d.User).WithMany(p => p.WorkingHours)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FKworking_ho212899");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
